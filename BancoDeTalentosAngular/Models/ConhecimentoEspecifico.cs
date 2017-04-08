using System;
using System.Collections.Generic;

namespace BancoDeTalentosAngular.Models
{
    public partial class ConhecimentoEspecifico
    {
        public ConhecimentoEspecifico()
        {
            TalentoConhecimentos = new HashSet<TalentoConhecimentos>();
        }

        public int IdConhecimentoEspecifico { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TalentoConhecimentos> TalentoConhecimentos { get; set; }
    }
}
