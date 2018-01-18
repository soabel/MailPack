using Soabel.MailSender.Application.Entitties;
using Soabel.MailSender.Application.Enums;
using Soabel.MailSender.Application.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Soabel.MailSender.Application.Helpers.EmailHelper;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;
using NPOI.HSSF.Util;

namespace Soabel.MailSender.Application
{
    public class CoreApplication
    {

        public event EventHandler<EmailSendEventArgs> EmailSendHandler;

        public event EventHandler<EmailSendEventArgs> EmailPreSendHandler;

        public event EventHandler<EmailSendEventArgs> EmailPostSendHandler;

        public CoreApplication() {

        }

        public void GuardarParametros(ICollection<Parametro> parametros) {

            using (var context = new MailingDbContext())
            {
                foreach (var parametroEditar in parametros)
                {
                    var parametroActual= context.Parametro.Where(x => x.Id == parametroEditar.Id).FirstOrDefault();
                    if (parametroActual != null && parametroActual.Valor != parametroEditar.Valor) {
                        parametroActual.Valor = parametroEditar.Valor;
                    }                    
                }

                context.SaveChanges();
            }

        }

        public ICollection<Parametro> ObtenerParametros() {
            ICollection<Parametro> resultado = new List<Parametro>();

            using (var context = new MailingDbContext())
            {
                resultado = context.Parametro.Where(x=>x.Editable==1).ToList();
            }

            return resultado;
        }

        public string ObtenerParametro(string codigo) {
            var parametros = this.ObtenerParametros();

            string valor = parametros.Where(x => x.Codigo == codigo).First().Valor;

            return valor;

        }

        public bool CrearArchivoEmail()
        {
            bool resultado = true;

            try
            {
                string tempFile = Path.GetTempPath() + Guid.NewGuid().ToString() + ".xlsx";

                XSSFWorkbook wb = new XSSFWorkbook();

                using (var ms = new MemoryStream()) {
                    
                    ISheet sheet = wb.CreateSheet("Destinatarios");

                    int indexCabecera = 0;

                    var rowCabecera = sheet.CreateRow(indexCabecera);

                    XSSFCellStyle cellStyle = (XSSFCellStyle)wb.CreateCellStyle();
                    
                    cellStyle.FillBackgroundColor = HSSFColor.DarkBlue.Index;

                    XSSFFont font = (XSSFFont)wb.CreateFont();
                    var color = new XSSFColor(new byte[] { 255, 255, 255 });
                    font.SetColor(color);
                    cellStyle.SetFont(font);

                    cellStyle.FillPattern = FillPattern.SolidForeground;

                    var cell1= rowCabecera.CreateCell(0);
                    var cell2= rowCabecera.CreateCell(1);

                    cell1.CellStyle = cellStyle;
                    cell1.SetCellValue(Enumeradores.EXCEL_CABECERA_CORREO);
                    cell2.CellStyle = cellStyle;
                    cell2.SetCellValue(Enumeradores.EXCEL_CABECERA_NOMBRE);

                    wb.Write(ms);
                    
                    File.WriteAllBytes(tempFile, ms.ToArray());
                    
                }

                

                System.Diagnostics.Process.Start(tempFile);
                
            }
            catch (Exception)
            {
                throw;
            }

          
            return resultado;
        }

        public bool ValidarArchivoEmail(string pathFile) {
            bool resultado = true;

            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(pathFile, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
                        
            ISheet sheet = hssfwb.GetSheetAt(0);
            if (sheet == null) {
                throw new ApplicationException("El archivo seleccionado no tiene hojas activas.");
            }

            //validar cabecera
            var rowNumCabecera = sheet.FirstRowNum;
            var rowCabecera = sheet.GetRow(rowNumCabecera);

            if (rowCabecera.GetCell(0)==null) {
                throw new ApplicationException("El formato de la plantilla excel es incorrecto.");
            }

            if (rowCabecera.GetCell(0).StringCellValue != "CORREO" || rowCabecera.GetCell(1).StringCellValue != "NOMBRE") {
                throw new ApplicationException("Error en el formato del archivo. Revisar las cabeceras.");
            }
         
            return resultado;
        }
        public ICollection<Persona> ObtenerDestinatarios(string pathFile) {
            ICollection<Persona> resultado = new List<Persona>();

            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(pathFile, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }

            ISheet sheet = hssfwb.GetSheet("Destinatarios");

            //No considerar la cabecera
            for (int filaIndice = sheet.FirstRowNum+1; filaIndice < sheet.LastRowNum; filaIndice++)
            {
                var filaData = sheet.GetRow(filaIndice);
                if (filaData.GetCell(0).StringCellValue != null 
                    && filaData.GetCell(0).StringCellValue.Length>0 
                    && IsValidEmail(filaData.GetCell(0).StringCellValue))
                {
                    resultado.Add(new Persona
                    {
                        Valido = true,
                        Fila = filaIndice,
                        Email = filaData.GetCell(0).StringCellValue,
                        Nombre = filaData.GetCell(1) != null ? filaData.GetCell(1).StringCellValue : null
                    });
                }
                else {
                    resultado.Add(new Persona
                    {
                        Valido = false,
                        Fila = filaIndice,
                        Email = filaData.GetCell(0).StringCellValue,
                        Nombre = filaData.GetCell(1) != null ? filaData.GetCell(1).StringCellValue : null
                    });
                }
            }
            
            return resultado;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<Template> ObtenerTemplates (){
            ICollection<Template> resultado = new List<Template>();

            //using (var context = new MailingDbContext())
            //{
            //    resultado = context.Template.ToList();
            //}


            return resultado;
        }

        public async void ConfirmarEnvioEmail(Publicacion publicacion) {
            ICollection<Parametro> parametros = new List<Parametro>();

            using (var context = new MailingDbContext())
            {
                parametros = context.Parametro.ToList();
            }
            
            var nombreServidor = parametros.Where(x => x.Codigo == Parametros.MAIL_SERVIDOR).First().Valor;
            var puertoServidor = parametros.Where(x => x.Codigo == Parametros.PORT_SERVIDOR).First().Valor;
            var usuario = parametros.Where(x => x.Codigo == Parametros.USER_NAME).First().Valor;
            var password = parametros.Where(x => x.Codigo == Parametros.USER_PASSWORD).First().Valor;
            var emailOrigenDefault = parametros.Where(x => x.Codigo == Parametros.EMAIL_ORIGEN).First().Valor;
            var emailNameDefault = parametros.Where(x => x.Codigo == Parametros.EMAIL_NAME).First().Valor;
            var factorAgrupador = parametros.Where(x => x.Codigo == Parametros.FACTOR_AGRUPADOR).First().Valor;

            var settings = new EmailSettings();

            settings.PrimaryDomain = nombreServidor;
            settings.PrimaryPort = int.Parse(puertoServidor);
            settings.Username = usuario;
            settings.Password = password;
            settings.FromEmail = emailOrigenDefault;
            settings.FromTitle = emailNameDefault;
            
            var mailKit = new Helpers.EmailHelper.MailKit(settings);
            
            var destinatariosFinal = publicacion.Destinatarios.Where(x => x.Valido)
                    .Select((x,index)=> new Persona { Correlativo=  index, Email=x.Email, Nombre= x.Nombre, Procesado=false }).ToList();


            int totalEnvios = Convert.ToInt32(Math.Round(Convert.ToDecimal(destinatariosFinal.Count) / Convert.ToDecimal(factorAgrupador), 0, MidpointRounding.AwayFromZero));
            if (destinatariosFinal.Count < int.Parse(factorAgrupador)) {
                totalEnvios = 1;
            }

            EmailSendEventArgs emailPreEventData = new EmailSendEventArgs();
            emailPreEventData.Correlativo = 0;
            emailPreEventData.Data = null;
            emailPreEventData.Total = totalEnvios;
            OnEmailPreSend(emailPreEventData);
                        
            string htmlBody = string.Empty;
            using (StreamReader SourceReader = System.IO.File.OpenText(publicacion.Template.Path))
            {
                htmlBody = SourceReader.ReadToEnd();
            }

            string asunto = publicacion.Subject;

            int c = 0;
            while (destinatariosFinal.Where(x => x.Procesado==false).Any()) {

                var grupo= destinatariosFinal.Where(x=>x.Procesado==false).Take(int.Parse(factorAgrupador)).ToList();

                List<KeyValuePair<string, string>> destinosGrupo = new List<KeyValuePair<string, string>>();

                foreach (var item in grupo)
                {
                    destinosGrupo.Add(new KeyValuePair<string, string>(item.Email, item.Nombre));
                }
                
                try
                {
                    await mailKit.SendEmailAsync(settings.FromEmail, settings.FromTitle, destinosGrupo, "", asunto, htmlBody, null, publicacion.Adjuntos.ToArray());
                    c++;

                    EmailSendEventArgs emailEventData = new EmailSendEventArgs();
                    emailEventData.Correlativo = c;
                    emailEventData.Data = grupo;
                    emailEventData.Total = totalEnvios;
                    OnEmailSend(emailEventData);

                    //actualizar procesados
                    foreach (var persona in grupo)
                    {
                        var destino= destinatariosFinal.Where(x => x.Correlativo == persona.Correlativo).FirstOrDefault();
                        destino.Procesado = true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                //System.Threading.Thread.Sleep(1000);
                await Task.Delay(1000);
                
            }

            EmailSendEventArgs emailPostEventData = new EmailSendEventArgs();
            emailPreEventData.Correlativo = 0;
            emailPreEventData.Data = null;
            emailPreEventData.Total = 0;
            OnEmailPostSend(emailPostEventData);

        }

        public void RestaurarDatabase() {
            DatabaseStartup.RestoreDatabase();
        }

        protected virtual void OnEmailPostSend(EmailSendEventArgs e)
        {
            EventHandler<EmailSendEventArgs> handler = EmailPostSendHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEmailPreSend(EmailSendEventArgs e)
        {
            EventHandler<EmailSendEventArgs> handler = EmailPreSendHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEmailSend(EmailSendEventArgs e)
        {
            EventHandler< EmailSendEventArgs> handler = EmailSendHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class EmailSendEventArgs : EventArgs {
        public int Correlativo { get; set; }
        public object Data { get; set; }
        public int Total { get; set; }
    }
}
