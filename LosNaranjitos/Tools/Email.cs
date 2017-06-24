using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.Tools
{
    public class Email
    {
        public List<string> Destinatarios { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
    }
}
