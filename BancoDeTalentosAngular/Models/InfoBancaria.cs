using System;
using System.Collections.Generic;

namespace BancoDeTalentosAngular.Models
{
    public partial class InfoBancaria
    {
        public int IdInfoBancaria { get; set; }
        public string Nome { get; set; }
        public int? Cpf { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string TipoConta { get; set; }
        public string NumeroConta { get; set; }
        public int? IdTalento { get; set; }

        public virtual Talento IdTalentoNavigation { get; set; }
    }
}
