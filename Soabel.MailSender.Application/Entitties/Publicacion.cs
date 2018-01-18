using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.MailSender.Application.Entitties
{
    public class Publicacion
    {
        public Publicacion() {
            this.Adjuntos = new List<string>();
        }
        public string Id { get; set; }
        public string Subject { get; set; }
        public Template Template { get; set; }
        public ICollection<Persona> Destinatarios { get; set; }
        public ICollection<Persona> DestinatariosCC { get; set; }
        public ICollection<Persona> DestinatariosCCO { get; set; }
        public ICollection<string> Adjuntos { get; set; }
        public DateTime Fecha { get; set; }
    }
}
