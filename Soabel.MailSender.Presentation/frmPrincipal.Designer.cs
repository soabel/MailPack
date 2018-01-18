namespace Soabel.MailSender.Presentation
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ofdArchivoExcel = new System.Windows.Forms.OpenFileDialog();
            this.txtArchivoExcel = new System.Windows.Forms.TextBox();
            this.btnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plantillasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plantillaExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSeleccionarPlantilla = new System.Windows.Forms.Button();
            this.txtPlantilla = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalDestinatario = new System.Windows.Forms.TextBox();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.lstAdjuntos = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ofdArchivosAdjuntos = new System.Windows.Forms.OpenFileDialog();
            this.txtEnvios = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Seleccionar Destinatarios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "2. Seleccionar Plantilla";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "3. Confirmar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Archivo (.xlsx)";
            // 
            // txtArchivoExcel
            // 
            this.txtArchivoExcel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtArchivoExcel.Location = new System.Drawing.Point(12, 104);
            this.txtArchivoExcel.Name = "txtArchivoExcel";
            this.txtArchivoExcel.ReadOnly = true;
            this.txtArchivoExcel.Size = new System.Drawing.Size(678, 22);
            this.txtArchivoExcel.TabIndex = 4;
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(696, 103);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(47, 23);
            this.btnSeleccionarArchivo.TabIndex = 5;
            this.btnSeleccionarArchivo.Text = "...";
            this.btnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(603, 500);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(96, 32);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(754, 28);
            this.menuStripPrincipal.TabIndex = 8;
            this.menuStripPrincipal.Text = "menuStrip1";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plantillasToolStripMenuItem,
            this.plantillaExcelToolStripMenuItem,
            this.parametrosToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.configuracionToolStripMenuItem.Text = "Configuración";
            // 
            // plantillasToolStripMenuItem
            // 
            this.plantillasToolStripMenuItem.Name = "plantillasToolStripMenuItem";
            this.plantillasToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.plantillasToolStripMenuItem.Text = "Plantillas Email";
            this.plantillasToolStripMenuItem.Visible = false;
            // 
            // plantillaExcelToolStripMenuItem
            // 
            this.plantillaExcelToolStripMenuItem.Name = "plantillaExcelToolStripMenuItem";
            this.plantillaExcelToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.plantillaExcelToolStripMenuItem.Text = "Plantilla Excel";
            this.plantillaExcelToolStripMenuItem.Click += new System.EventHandler(this.plantillaExcelToolStripMenuItem_Click);
            // 
            // parametrosToolStripMenuItem
            // 
            this.parametrosToolStripMenuItem.Name = "parametrosToolStripMenuItem";
            this.parametrosToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.parametrosToolStripMenuItem.Text = "Parámetros";
            this.parametrosToolStripMenuItem.Click += new System.EventHandler(this.parametrosToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // btnSeleccionarPlantilla
            // 
            this.btnSeleccionarPlantilla.Location = new System.Drawing.Point(696, 240);
            this.btnSeleccionarPlantilla.Name = "btnSeleccionarPlantilla";
            this.btnSeleccionarPlantilla.Size = new System.Drawing.Size(47, 23);
            this.btnSeleccionarPlantilla.TabIndex = 12;
            this.btnSeleccionarPlantilla.Text = "...";
            this.btnSeleccionarPlantilla.UseVisualStyleBackColor = true;
            this.btnSeleccionarPlantilla.Click += new System.EventHandler(this.btnSeleccionarPlantilla_Click);
            // 
            // txtPlantilla
            // 
            this.txtPlantilla.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPlantilla.Location = new System.Drawing.Point(9, 241);
            this.txtPlantilla.Name = "txtPlantilla";
            this.txtPlantilla.ReadOnly = true;
            this.txtPlantilla.Size = new System.Drawing.Size(681, 22);
            this.txtPlantilla.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Archivo (.html)";
            // 
            // txtAsunto
            // 
            this.txtAsunto.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtAsunto.Location = new System.Drawing.Point(12, 368);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(678, 22);
            this.txtAsunto.TabIndex = 14;
            this.txtAsunto.Text = "Esto es una prueba";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Asunto";
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(624, 137);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(66, 23);
            this.btnVer.TabIndex = 15;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total destinatarios :";
            // 
            // txtTotalDestinatario
            // 
            this.txtTotalDestinatario.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTotalDestinatario.Location = new System.Drawing.Point(141, 140);
            this.txtTotalDestinatario.Name = "txtTotalDestinatario";
            this.txtTotalDestinatario.ReadOnly = true;
            this.txtTotalDestinatario.Size = new System.Drawing.Size(119, 22);
            this.txtTotalDestinatario.TabIndex = 17;
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.Location = new System.Drawing.Point(327, 432);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(47, 23);
            this.btnAdjuntar.TabIndex = 18;
            this.btnAdjuntar.Text = "...";
            this.btnAdjuntar.UseVisualStyleBackColor = true;
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // lstAdjuntos
            // 
            this.lstAdjuntos.FormattingEnabled = true;
            this.lstAdjuntos.ItemHeight = 16;
            this.lstAdjuntos.Location = new System.Drawing.Point(9, 432);
            this.lstAdjuntos.Name = "lstAdjuntos";
            this.lstAdjuntos.Size = new System.Drawing.Size(312, 100);
            this.lstAdjuntos.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Archivos Adjuntos";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // ofdArchivosAdjuntos
            // 
            this.ofdArchivosAdjuntos.FileName = "openFileDialog1";
            // 
            // txtEnvios
            // 
            this.txtEnvios.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtEnvios.Location = new System.Drawing.Point(382, 140);
            this.txtEnvios.Name = "txtEnvios";
            this.txtEnvios.ReadOnly = true;
            this.txtEnvios.Size = new System.Drawing.Size(119, 22);
            this.txtEnvios.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Total envíos:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 588);
            this.Controls.Add(this.txtEnvios);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstAdjuntos);
            this.Controls.Add(this.btnAdjuntar);
            this.Controls.Add(this.txtTotalDestinatario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSeleccionarPlantilla);
            this.Controls.Add(this.txtPlantilla);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnSeleccionarArchivo);
            this.Controls.Add(this.txtArchivoExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripPrincipal);
            this.MainMenuStrip = this.menuStripPrincipal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Envío de Emails";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog ofdArchivoExcel;
        private System.Windows.Forms.TextBox txtArchivoExcel;
        private System.Windows.Forms.Button btnSeleccionarArchivo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plantillasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plantillaExcelToolStripMenuItem;
        private System.Windows.Forms.Button btnSeleccionarPlantilla;
        private System.Windows.Forms.TextBox txtPlantilla;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalDestinatario;
        private System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.ListBox lstAdjuntos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog ofdArchivosAdjuntos;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox txtEnvios;
        private System.Windows.Forms.Label label9;
    }
}

