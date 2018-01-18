using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.MailSender.Application.Entitties
{
    public class Persona
    {
        public int Correlativo { get; set; }
        public int Fila { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Valido { get; set; }
        public bool Procesado { get; set; }

    }
    

}
