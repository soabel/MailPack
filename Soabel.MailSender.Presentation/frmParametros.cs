using Soabel.MailSender.Application;
using Soabel.MailSender.Application.Entitties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soabel.MailSender.Presentation
{
    public partial class frmParametros : Form
    {
        private CoreApplication _application;

        public frmParametros()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevaListaParametros = (ICollection<Parametro>)dgvLista.DataSource;
                this._application.GuardarParametros(nuevaListaParametros);

                MessageBox.Show("Se actualizó los parámetros correctamente." , "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al guardar los parámetros." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.Print(ex.Message);
                System.Diagnostics.Debug.Print(ex.StackTrace);
            }
            
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            try
            {
                this._application = new CoreApplication();

                var listaParametros = this._application.ObtenerParametros();

                dgvLista.AutoGenerateColumns = false;
                dgvLista.DataSource = listaParametros;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al cargar los parámetros." +  ex.Message + " " + Environment.CurrentDirectory , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.Print(ex.Message);
                System.Diagnostics.Debug.Print(ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                this._application.RestaurarDatabase();
                MessageBox.Show("Se restauró los valores predeterminados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var listaParametros = this._application.ObtenerParametros();                
                dgvLista.DataSource = listaParametros;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ha ocurrido un error al cargar los parámetros." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.Print(ex.Message);
                System.Diagnostics.Debug.Print(ex.StackTrace);
            }
            
        }
    }
}
