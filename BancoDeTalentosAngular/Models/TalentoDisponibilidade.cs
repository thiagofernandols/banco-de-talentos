using System;
using System.Collections.Generic;

namespace BancoDeTalentosAngular.Models
{
    public partial class TalentoDisponibilidade
    {
        public int IdTalentoDisponibilidade { get; set; }
        public int IdTalento { get; set; }
        public int? IdDisponibilidade { get; set; }

        public virtual Disponibilidade IdDisponibilidadeNavigation { get; set; }
        public virtual Talento IdTalentoNavigation { get; set; }
    }
}
