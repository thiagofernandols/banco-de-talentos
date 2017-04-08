using System;
using System.Collections.Generic;

namespace BancoDeTalentosAngular.Models
{
    public partial class Disponibilidade
    {
        public Disponibilidade()
        {
            TalentoDisponibilidade = new HashSet<TalentoDisponibilidade>();
        }

        public int IdDisponibilidade { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TalentoDisponibilidade> TalentoDisponibilidade { get; set; }
    }
}