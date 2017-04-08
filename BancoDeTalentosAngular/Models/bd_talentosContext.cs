using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BancoDeTalentosAngular.Models
{
    public partial class bd_talentosContext : DbContext
    {
        public virtual DbSet<ConhecimentoEspecifico> ConhecimentoEspecifico { get; set; }
        public virtual DbSet<Disponibilidade> Disponibilidade { get; set; }
        public virtual DbSet<InfoBancaria> InfoBancaria { get; set; }
        public virtual DbSet<MelhorHorario> MelhorHorario { get; set; }
        public virtual DbSet<Talento> Talento { get; set; }
        public virtual DbSet<TalentoConhecimentos> TalentoConhecimentos { get; set; }
        public virtual DbSet<TalentoDisponibilidade> TalentoDisponibilidade { get; set; }
        public virtual DbSet<TalentoMelhorHorario> TalentoMelhorHorario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=WOLF-PC\SQLEXPRESS;Database=bd_talentos;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConhecimentoEspecifico>(entity =>
            {
                entity.HasKey(e => e.IdConhecimentoEspecifico)
                    .HasName("PK__Conhecim__939C3BC5652A5B37");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Disponibilidade>(entity =>
            {
                entity.HasKey(e => e.IdDisponibilidade)
                    .HasName("PK__Disponib__BC5612FD9CDC5928");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<InfoBancaria>(entity =>
            {
                entity.HasKey(e => e.IdInfoBancaria)
                    .HasName("PK__InfoBanc__DDF3ED0E9F62613E");

                entity.Property(e => e.Agencia).HasMaxLength(100);

                entity.Property(e => e.Banco).HasMaxLength(50);

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.Nome).HasMaxLength(200);

                entity.Property(e => e.NumeroConta).HasMaxLength(50);

                entity.Property(e => e.TipoConta).HasMaxLength(50);

                entity.HasOne(d => d.IdTalentoNavigation)
                    .WithMany(p => p.InfoBancaria)
                    .HasForeignKey(d => d.IdTalento)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_InfoBancaria_Talento");
            });

            modelBuilder.Entity<MelhorHorario>(entity =>
            {
                entity.HasKey(e => e.IdMelhorHorario)
                    .HasName("PK__MelhorHo__64AE45DE9F99C2CE");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Talento>(entity =>
            {
                entity.HasKey(e => e.IdTalento)
                    .HasName("PK__Talento__3A665694547A399B");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LinkCrud)
                    .HasColumnName("LinkCRUD")
                    .HasMaxLength(100);

                entity.Property(e => e.Linkedin).HasMaxLength(100);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Portfolio).HasMaxLength(100);

                entity.Property(e => e.Pretensao).HasColumnType("decimal");

                entity.Property(e => e.Skype)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Whatsapp)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TalentoConhecimentos>(entity =>
            {
                entity.HasKey(e => e.IdTalentoConhecimentos)
                    .HasName("PK__TalentoC__554B140808A9CB23");

                entity.HasOne(d => d.IdConhecimentoEspecificoNavigation)
                    .WithMany(p => p.TalentoConhecimentos)
                    .HasForeignKey(d => d.IdConhecimentoEspecifico)
                    .HasConstraintName("fk_TalentoConh_Conhe");

                entity.HasOne(d => d.IdTalentoNavigation)
                    .WithMany(p => p.TalentoConhecimentos)
                    .HasForeignKey(d => d.IdTalento)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_TalentoConh_Talento");
            });

            modelBuilder.Entity<TalentoDisponibilidade>(entity =>
            {
                entity.HasKey(e => e.IdTalentoDisponibilidade)
                    .HasName("PK__TalentoD__8553DE1C1642E4D3");

                entity.HasOne(d => d.IdDisponibilidadeNavigation)
                    .WithMany(p => p.TalentoDisponibilidade)
                    .HasForeignKey(d => d.IdDisponibilidade)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_TalentoDisp_Disponi");

                entity.HasOne(d => d.IdTalentoNavigation)
                    .WithMany(p => p.TalentoDisponibilidade)
                    .HasForeignKey(d => d.IdTalento)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_TalentoDisp_Talento");
            });

            modelBuilder.Entity<TalentoMelhorHorario>(entity =>
            {
                entity.HasKey(e => e.IdTalentoMelhorHorario)
                    .HasName("PK__TalentoM__ADE0F29F1F21B462");

                entity.HasOne(d => d.IdMelhorHorarioNavigation)
                    .WithMany(p => p.TalentoMelhorHorario)
                    .HasForeignKey(d => d.IdMelhorHorario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_TalentoMH_MelhorH");

                entity.HasOne(d => d.IdTalentoNavigation)
                    .WithMany(p => p.TalentoMelhorHorario)
                    .HasForeignKey(d => d.IdTalento)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_TalentoMH_Talento");
            });
        }
    }
}