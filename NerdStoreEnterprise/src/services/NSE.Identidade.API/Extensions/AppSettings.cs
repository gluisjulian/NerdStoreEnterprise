using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Identidade.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; } //Chave
        public int ExpiracaoHoras { get; set; } //quanto tempo em horas
        public string Emissor { get; set; }//Emissor
        public string ValidoEm { get; set; }//onde ele é valido (Audience)
    }
}
