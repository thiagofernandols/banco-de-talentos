using System;
using System.Collections.Generic;

namespace BancoDeTalentosAngular.Models
{
    public partial class TalentoConhecimentos
    {
        public int IdTalentoConhecimentos { get; set; }
        public int IdTalento { get; set; }
        public int IdConhecimentoEspecifico { get; set; }
        public int? Avaliacao { get; set; }

        public virtual ConhecimentoEspecifico IdConhecimentoEspecificoNavigation { get; set; }
        public virtual Talento IdTalentoNavigation { get; set; }
    }
}
