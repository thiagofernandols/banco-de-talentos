using System;
using System.Collections.Generic;

namespace BancoDeTalentosAngular.Models
{
    public partial class TalentoMelhorHorario
    {
        public int IdTalentoMelhorHorario { get; set; }
        public int? IdTalento { get; set; }
        public int? IdMelhorHorario { get; set; }

        public virtual MelhorHorario IdMelhorHorarioNavigation { get; set; }
        public virtual Talento IdTalentoNavigation { get; set; }
    }
}
