using Soabel.MailSender.Application.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.MailSender.Application.Persistence.Database
{
    public class DatabaseStartup
    {
        public static void RestoreDatabase() {
            Limpiar();
            CargarParametros();
        }
        private static void Limpiar() {
            using (MailingDbContext context = new MailingDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Parametro");
                context.Database.ExecuteSqlCommand("DELETE FROM Template");
                context.SaveChanges();
            }
        }
        private static void CargarParametros() {
            using (MailingDbContext context = new MailingDbContext()) {

                context.Parametro.Add(new Parametro {  Codigo="INDICADOR_INICIALIZADO", Nombre="Indicador de inicialización", Valor="0", Editable= 0 });
                //context.Parametro.Add(new Parametro { Codigo = "RUTA_TEMPLATES", Nombre ="Ruta de Plantillas" , Valor = Environment.CurrentDirectory + @"\Templates\", Editable=1 });
                context.Parametro.Add(new Parametro {  Codigo = "MAIL_SERVIDOR", Nombre = "Servidor de Correo", Valor = "smtp.office365.com", Editable=1 });
                context.Parametro.Add(new Parametro { Codigo = "PORT_SERVIDOR", Nombre = "Puerto Servidor de Correo", Valor = "587", Editable=1 });
                context.Parametro.Add(new Parametro { Codigo = "USER_NAME", Nombre = "Nombre de Usuario", Valor = "alfredo.benaute@hundred.com.pe", Editable=1});
                context.Parametro.Add(new Parametro { Codigo = "USER_PASSWORD", Nombre = "Password de Usuario", Valor = "password123", Editable=1 });
                context.Parametro.Add(new Parametro { Codigo = "EMAIL_ORIGEN", Nombre = "Email origen de correo", Valor = "alfredo.benaute@hundred.com.pe", Editable=1 });
                context.Parametro.Add(new Parametro { Codigo = "EMAIL_NAME", Nombre = "Nombre de Remitente", Valor = "UPC Centro de estudios", Editable=1 });
                context.Parametro.Add(new Parametro { Codigo = "FACTOR_AGRUPADOR", Nombre = "Factor Agrupador", Valor = "2", Editable = 1 });

                context.SaveChanges();

            }

        }
        private static void CargarTemplate()
        {
           
        }

    }
}
