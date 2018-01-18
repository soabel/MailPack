using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.MailSender.Application.Enums
{
    public struct Parametros
    {
        public const string INDICADOR_INICIALIZADO = "INDICADOR_INICIALIZADO";
        public const string RUTA_TEMPLATES = "RUTA_TEMPLATES";
        public const string MAIL_SERVIDOR = "MAIL_SERVIDOR";
        public const string PORT_SERVIDOR = "PORT_SERVIDOR";
        public const string USER_NAME = "USER_NAME";
        public const string USER_PASSWORD = "USER_PASSWORD";
        public const string EMAIL_ORIGEN = "EMAIL_ORIGEN";
        public const string EMAIL_NAME = "EMAIL_NAME";
        public const string FACTOR_AGRUPADOR = "FACTOR_AGRUPADOR";
    }

    public struct Enumeradores {
        public const string EXCEL_CABECERA_CORREO = "CORREO";
        public const string EXCEL_CABECERA_NOMBRE = "NOMBRE";
    }
}
