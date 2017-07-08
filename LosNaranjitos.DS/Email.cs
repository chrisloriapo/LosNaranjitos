using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosNaranjitos.DS
{
    public class Email
    {
        public List<string> Destinatarios { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
    }
}
