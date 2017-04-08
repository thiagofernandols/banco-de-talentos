using System;
using System.Collections.Generic;

namespace BancoDeTalentosAngular.Models
{
    public partial class Talento
    {
        public Talento()
        {
            InfoBancaria = new HashSet<InfoBancaria>();
            TalentoConhecimentos = new HashSet<TalentoConhecimentos>();
            TalentoDisponibilidade = new HashSet<TalentoDisponibilidade>();
            TalentoMelhorHorario = new HashSet<TalentoMelhorHorario>();
        }

        public int IdTalento { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Skype { get; set; }
        public string Whatsapp { get; set; }
        public string Linkedin { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Portfolio { get; set; }
        public decimal Pretensao { get; set; }
        public string LinkCrud { get; set; }

        public virtual ICollection<InfoBancaria> InfoBancaria { get; set; }
        public virtual ICollection<TalentoConhecimentos> TalentoConhecimentos { get; set; }
        public virtual ICollection<TalentoDisponibilidade> TalentoDisponibilidade { get; set; }
        public virtual ICollection<TalentoMelhorHorario> TalentoMelhorHorario { get; set; }
    }
}
