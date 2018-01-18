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
    public partial class frmVerDestinatarios : Form
    {
        public frmVerDestinatarios()
        {
            InitializeComponent();
        }

        public IEnumerable<Persona> ListaPersona { get; set; }

        private void frmVerDestinatarios_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgvLista.AutoGenerateColumns = false;            
            dgvLista.DataSource = null;

            if (this.ListaPersona != null) {
                dgvLista.DataSource = this.ListaPersona;
            }
            this.Cursor = Cursors.Default;
        }

        private void dgvLista_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex >= 0) {
                var personaFila = (Persona)dgvLista.Rows[e.RowIndex].DataBoundItem;

                if (personaFila != null && personaFila.Valido == false)
                {
                    dgvLista.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
