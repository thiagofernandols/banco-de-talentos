using System;
using System.Collections.Generic;

namespace BancoDeTalentosAngular.Models
{
    public partial class MelhorHorario
    {
        public MelhorHorario()
        {
            TalentoMelhorHorario = new HashSet<TalentoMelhorHorario>();
        }

        public int IdMelhorHorario { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TalentoMelhorHorario> TalentoMelhorHorario { get; set; }
    }
}