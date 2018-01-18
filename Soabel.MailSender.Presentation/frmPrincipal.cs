using Soabel.MailSender.Application;
using Soabel.MailSender.Application.Entitties;
using Soabel.MailSender.Application.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soabel.MailSender.Presentation
{
    public partial class frmPrincipal : Form
    {

        private CoreApplication _application;

        private ICollection<Persona> personaSeleccionadas;

        private frmProgreso progreso;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {

            try
            {
                //TODO: Inicializar file dialog
                ofdArchivoExcel.Reset();
                ofdArchivoExcel.Multiselect = false;
                ofdArchivoExcel.Filter = "Excel Files|*.xlsx;*.xls;";
                if (ofdArchivoExcel.ShowDialog() == DialogResult.OK)
                {
                    txtArchivoExcel.Text = ofdArchivoExcel.FileName;

                    this.ValidarArchivo();

                    if (txtPlantilla.Text.Trim().Length > 0) {
                        btnConfirmar.Enabled = true;
                    }
                    
                }
                else
                {
                    this.personaSeleccionadas = null;
                    txtArchivoExcel.Clear();
                    btnVer.Enabled = false;
                    txtTotalDestinatario.Clear();
                    btnConfirmar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al seleccionar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.Print(ex.Message);
                System.Diagnostics.Debug.Print(ex.StackTrace);
            }
            
        }

        private void ValidarArchivo() {
            var resultado= this._application.ValidarArchivoEmail(ofdArchivoExcel.FileName);
            if (resultado)
            {
                btnVer.Enabled = true;
                
                this.personaSeleccionadas = this._application.ObtenerDestinatarios(txtArchivoExcel.Text);
                txtTotalDestinatario.Text = string.Format("{0}", this.personaSeleccionadas.Where(x=>x.Valido).Count());

                int factorGrupo = int.Parse( this._application.ObtenerParametro(Parametros.FACTOR_AGRUPADOR));
                decimal totalEnvios = 0;
                if (this.personaSeleccionadas.Where(x => x.Valido).Count() < factorGrupo)
                {
                    totalEnvios = 1;
                }
                else {
                    totalEnvios = Math.Round(Convert.ToDecimal(this.personaSeleccionadas.Where(x => x.Valido).Count()) / Convert.ToDecimal(factorGrupo), 0, MidpointRounding.AwayFromZero);
                }

                txtEnvios.Text = string.Format("{0}",totalEnvios) ;

                frmVerDestinatarios frm = new frmVerDestinatarios();
                frm.ListaPersona = this.personaSeleccionadas;
                frm.ShowDialog();
            }
            else {
                throw new ApplicationException(string.Format("Ha ocurrido un error al leer el archivo {0}", txtArchivoExcel.Text));
            }
        }
        

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.personaSeleccionadas = null;
            this._application = new CoreApplication();
            this._application.EmailPreSendHandler += _application_EmailPreSendHandler;
            this._application.EmailSendHandler += OnEmailSendHandler;
            this._application.EmailPostSendHandler += OnEmailPostSendHandler;
            
            btnConfirmar.Enabled = false;
        }

        private void OnEmailPostSendHandler(object sender, EmailSendEventArgs e)
        {
            if (this.progreso != null)
            {
                this.progreso.Hide();
                MessageBox.Show("Se ha completado el proceso de envío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;
                btnConfirmar.Enabled = true;
            }
        }

        private void _application_EmailPreSendHandler(object sender, EmailSendEventArgs e)
        {
            if (this.progreso == null)
            {
                this.progreso = new frmProgreso();
                this.progreso.Show(this);
                this.Enabled = false;
            }
            this.progreso.Mostrar(e.Correlativo, e.Total);
        }

        private void OnEmailSendHandler(object sender, EmailSendEventArgs e)
        {
            if (this.progreso == null) {
                this.progreso = new frmProgreso();
                this.progreso.Show(this);
                this.Enabled = false;
            }
            this.progreso.Mostrar(e.Correlativo, e.Total);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtAsunto.Text.Trim().Length == 0) {
                MessageBox.Show("Ingrese el asunto del mensaje.", "Pregunta", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtAsunto.Focus();
                return;
            }

            try
            {
                Publicacion publicacion = new Publicacion();

                publicacion.Subject = txtAsunto.Text;

                publicacion.Template = new Template() { Nombre = "", Path = txtPlantilla.Text };
                publicacion.Destinatarios = this.personaSeleccionadas;

                if ( lstAdjuntos.Items.Count>0 && ofdArchivosAdjuntos.FileNames.Length > 0) {
                    publicacion.Adjuntos = ofdArchivosAdjuntos.FileNames;
                }

                this._application.ConfirmarEnvioEmail(publicacion);

                btnConfirmar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al seleccionar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.Print(ex.Message);
                System.Diagnostics.Debug.Print(ex.StackTrace);
            }           
        }

        private void restaurarConfiguracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._application.RestaurarDatabase();
        }

        private void plantillaExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this._application.CrearArchivoEmail();
            this.Cursor = Cursors.Default;
        }

        private void btnSeleccionarPlantilla_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: Inicializar file dialog
                ofdArchivoExcel.Reset();
                ofdArchivoExcel.Multiselect = false;
                ofdArchivoExcel.Filter = "Html Files|*.html;*.htm;";
                if (ofdArchivoExcel.ShowDialog() == DialogResult.OK)
                {
                    txtPlantilla.Text = ofdArchivoExcel.FileName;

                    if (txtArchivoExcel.Text.Trim().Length > 0)
                    {
                        btnConfirmar.Enabled = true;
                    }
                }
                else
                {
                    txtPlantilla.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al seleccionar la plantilla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.Print(ex.Message);
                System.Diagnostics.Debug.Print(ex.StackTrace);
            }

        }
        

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (txtArchivoExcel.Text.Length > 0) {
                
                frmVerDestinatarios frm = new frmVerDestinatarios();
                frm.ListaPersona = this.personaSeleccionadas;
                frm.ShowDialog();
            }            
        }

        private void parametrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            frmParametros frm = new frmParametros();
            frm.ShowDialog();

            this.Cursor = Cursors.Default;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            ofdArchivosAdjuntos.Multiselect = true;
            if (ofdArchivosAdjuntos.ShowDialog() == DialogResult.OK)
            {
                foreach (var pathFile in ofdArchivosAdjuntos.FileNames)
                {
                    lstAdjuntos.Items.Add(Path.GetFileName(pathFile));                    
                }                
            }
            else
            {
                lstAdjuntos.Items.Clear();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
