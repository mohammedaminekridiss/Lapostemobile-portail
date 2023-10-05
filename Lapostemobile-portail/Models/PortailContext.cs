using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_portail.Models;

public partial class PortailContext : DbContext
{
    public PortailContext()
    {
    }

    public PortailContext(DbContextOptions<PortailContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adresse> Adresses { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<CaracteristiquesArticle> CaracteristiquesArticles { get; set; }

    public virtual DbSet<CoordonneesBancaire> CoordonneesBancaires { get; set; }

    public virtual DbSet<Financement> Financements { get; set; }

    public virtual DbSet<Ligne> Lignes { get; set; }

    public virtual DbSet<LigneArticle> LigneArticles { get; set; }

    public virtual DbSet<LigneOption> LigneOptions { get; set; }

    public virtual DbSet<ModeLivraison> ModeLivraisons { get; set; }

    public virtual DbSet<OffreEngagement> OffreEngagements { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<PrixArticle> PrixArticles { get; set; }

    public virtual DbSet<Prospect> Prospects { get; set; }

    public virtual DbSet<Souscription> Souscriptions { get; set; }

    public virtual DbSet<StatutSouscription> StatutSouscriptions { get; set; }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UMUO8VR\\SQLEXPRESS;Database=Portail;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.IdAdresse).HasName("PK__adresse__05B3E6DC201BBB5F");

            entity.ToTable("adresse");

            entity.Property(e => e.IdAdresse).HasColumnName("id_adresse");
            entity.Property(e => e.AdresseComp)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("adresse_comp");
            entity.Property(e => e.Codepostal)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codepostal");
            entity.Property(e => e.DatCre)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("date")
                .HasColumnName("dat_cre");
            entity.Property(e => e.DatMod)
                .HasColumnType("date")
                .HasColumnName("dat_mod");
            entity.Property(e => e.IdPays).HasColumnName("id_pays");
            entity.Property(e => e.Numero)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Ville)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ville");
            entity.Property(e => e.Voie)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("voie");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.IdArticle).HasName("PK__article__64CB31B82888E3FD");

            entity.ToTable("article");

            entity.Property(e => e.IdArticle)
                .ValueGeneratedNever()
                .HasColumnName("id_article");
            entity.Property(e => e.CodeSap)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("code_sap");
            entity.Property(e => e.DateFinCcial)
                .HasColumnType("date")
                .HasColumnName("date_fin_ccial");
            entity.Property(e => e.FichierImage)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("fichier_image");
            entity.Property(e => e.FichierImageVignette)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("fichier_image_vignette");
            entity.Property(e => e.IdFabriquant).HasColumnName("id_fabriquant");
            entity.Property(e => e.IdTypeArticle).HasColumnName("id_type_article");
            entity.Property(e => e.LibelleArticle)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("libelle_article");
            entity.Property(e => e.LibelleCourt)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("libelle_court");
            entity.Property(e => e.Ordre).HasColumnName("ordre");
            entity.Property(e => e.Statut).HasColumnName("statut");
        });

        modelBuilder.Entity<CaracteristiquesArticle>(entity =>
        {
            entity.HasKey(e => e.IdCaracteristiquesArticles).HasName("PK__caracter__6F85FECF542765C0");

            entity.ToTable("caracteristiques_articles");

            entity.Property(e => e.IdCaracteristiquesArticles)
                .ValueGeneratedNever()
                .HasColumnName("id_caracteristiques_articles");
            entity.Property(e => e.IdArticle).HasColumnName("id_article");
            entity.Property(e => e.NomCaracteristiquesArticles)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_caracteristiques_articles");
            entity.Property(e => e.ValeurCarasteristiquesArticles)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("valeur_carasteristiques_articles");

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.CaracteristiquesArticles)
                .HasForeignKey(d => d.IdArticle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__caracteri__id_ar__6FE99F9F");
        });

        modelBuilder.Entity<CoordonneesBancaire>(entity =>
        {
            entity.HasKey(e => e.IdCoordonnees).HasName("PK__coordonn__AF9E03121B5DB706");

            entity.ToTable("coordonnees_bancaires");

            entity.Property(e => e.IdCoordonnees).HasColumnName("id_coordonnees");
            entity.Property(e => e.CodeBic)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("code_bic");
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("date")
                .HasColumnName("date_creation");
            entity.Property(e => e.DateModification)
                .HasColumnType("date")
                .HasColumnName("date_modification");
            entity.Property(e => e.Iban)
                .HasMaxLength(34)
                .IsUnicode(false)
                .HasColumnName("iban");
            entity.Property(e => e.NomBanque)
                .HasMaxLength(58)
                .IsUnicode(false)
                .HasColumnName("nom_banque");
            entity.Property(e => e.TitulaireCompte)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("titulaire_compte");
        });

        modelBuilder.Entity<Financement>(entity =>
        {
            entity.HasKey(e => e.IdFinancement).HasName("PK__financem__A9EB9E164074079B");

            entity.ToTable("financement");

            entity.Property(e => e.IdFinancement)
                .ValueGeneratedNever()
                .HasColumnName("id_financement");
            entity.Property(e => e.DureeFinancement)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("duree_financement");
            entity.Property(e => e.IdOption).HasColumnName("id_option");
            entity.Property(e => e.MontantFinancement)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("montant_financement");

            entity.HasOne(d => d.IdOptionNavigation).WithMany(p => p.Financements)
                .HasForeignKey(d => d.IdOption)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__financeme__id_op__49C3F6B7");
        });

        modelBuilder.Entity<Ligne>(entity =>
        {
            entity.HasKey(e => e.IdLigne).HasName("PK__ligne__E1D60C0C7A775143");

            entity.ToTable("ligne");

            entity.Property(e => e.IdLigne).HasColumnName("id_ligne");
            entity.Property(e => e.DatCre)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("date")
                .HasColumnName("dat_cre");
            entity.Property(e => e.DatMod)
                .HasColumnType("date")
                .HasColumnName("dat_mod");
            entity.Property(e => e.IdFinancement).HasColumnName("id_financement");
            entity.Property(e => e.IdOffreEngagement).HasColumnName("id_offre_engagement");
            entity.Property(e => e.IdSouscription).HasColumnName("id_souscription");
            entity.Property(e => e.PrixVenteOffre).HasColumnName("prix_vente_offre");

            entity.HasOne(d => d.IdFinancementNavigation).WithMany(p => p.Lignes)
                .HasForeignKey(d => d.IdFinancement)
                .HasConstraintName("FK__ligne__id_financ__2CF2ADDF");

            entity.HasOne(d => d.IdOffreEngagementNavigation).WithMany(p => p.Lignes)
                .HasForeignKey(d => d.IdOffreEngagement)
                .HasConstraintName("FK__ligne__id_offre___2DE6D218");

            entity.HasOne(d => d.IdSouscriptionNavigation).WithMany(p => p.Lignes)
                .HasForeignKey(d => d.IdSouscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ligne__id_souscr__2EDAF651");
        });

        modelBuilder.Entity<LigneArticle>(entity =>
        {
            entity.HasKey(e => e.IdLigneArticle).HasName("PK__ligne_ar__813AC43D124B4CB6");

            entity.ToTable("ligne_article");

            entity.Property(e => e.IdLigneArticle).HasColumnName("id_ligne_article");
            entity.Property(e => e.DatCre)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("date")
                .HasColumnName("dat_cre");
            entity.Property(e => e.DatMod)
                .HasColumnType("date")
                .HasColumnName("dat_mod");
            entity.Property(e => e.IdArticle).HasColumnName("id_article");
            entity.Property(e => e.IdLigne).HasColumnName("id_ligne");
            entity.Property(e => e.Imei)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("imei");
            entity.Property(e => e.PrixPaye)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("prix_paye");
            entity.Property(e => e.TotalSubvention)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_subvention");

            entity.HasOne(d => d.IdLigneNavigation).WithMany(p => p.LigneArticles)
                .HasForeignKey(d => d.IdLigne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ligne_art__id_li__32AB8735");
        });

        modelBuilder.Entity<LigneOption>(entity =>
        {
            entity.HasKey(e => e.IdLigneOption).HasName("PK__ligne_op__6498FBB4033AC961");

            entity.ToTable("ligne_option");

            entity.Property(e => e.IdLigneOption).HasColumnName("id_ligne_option");
            entity.Property(e => e.DatMod)
                .HasColumnType("date")
                .HasColumnName("dat_mod");
            entity.Property(e => e.DateCreation)
                .HasColumnType("date")
                .HasColumnName("date_creation");
            entity.Property(e => e.IdLigne).HasColumnName("id_ligne");
            entity.Property(e => e.IdOption).HasColumnName("id_option");
            entity.Property(e => e.PrixVenteOption).HasColumnName("prix_vente_option");

            entity.HasOne(d => d.IdLigneNavigation).WithMany(p => p.LigneOptions)
                .HasForeignKey(d => d.IdLigne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ligne_opt__id_li__3587F3E0");

            entity.HasOne(d => d.IdOptionNavigation).WithMany(p => p.LigneOptions)
                .HasForeignKey(d => d.IdOption)
                .HasConstraintName("FK__ligne_opt__id_op__367C1819");
        });

        modelBuilder.Entity<ModeLivraison>(entity =>
        {
            entity.HasKey(e => e.IdModeLivraison).HasName("PK__mode_liv__C95298B7972ADFF5");

            entity.ToTable("mode_livraison");

            entity.Property(e => e.IdModeLivraison)
                .ValueGeneratedNever()
                .HasColumnName("id_mode_livraison");
            entity.Property(e => e.LibelleModeLivraison)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("libelle_mode_livraison");
            entity.Property(e => e.PrixLivraison).HasColumnName("prix_livraison");
        });

        modelBuilder.Entity<OffreEngagement>(entity =>
        {
            entity.HasKey(e => e.IdOffreEngagement).HasName("PK__offre_en__857BF79C0AC2E96F");

            entity.ToTable("offre_engagement");

            entity.Property(e => e.IdOffreEngagement)
                .ValueGeneratedNever()
                .HasColumnName("id_offre_engagement");
            entity.Property(e => e.Caracteristiques)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("caracteristiques");
            entity.Property(e => e.DureeEngagement).HasColumnName("duree_engagement");
            entity.Property(e => e.Est5g).HasColumnName("est_5g");
            entity.Property(e => e.LibelleMarketing)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("libelle_marketing");
            entity.Property(e => e.MontantSubvention)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("montant_subvention");
            entity.Property(e => e.Prix)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prix");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.IdOption).HasName("PK__options__7B78D9B64C0BC083");

            entity.ToTable("options");

            entity.Property(e => e.IdOption)
                .ValueGeneratedNever()
                .HasColumnName("id_option");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdGroupeOption).HasColumnName("id_groupe_option");
            entity.Property(e => e.LibelleMarketing)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("libelle_marketing");
            entity.Property(e => e.LibelleOption)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("libelle_option");
            entity.Property(e => e.OrdreAffichage)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ordre_affichage");
        });

        modelBuilder.Entity<PrixArticle>(entity =>
        {
            entity.HasKey(e => e.IdPrixArticle).HasName("PK__prix_art__B64515C8F009DBA4");

            entity.ToTable("prix_article");

            entity.Property(e => e.IdPrixArticle)
                .ValueGeneratedNever()
                .HasColumnName("id_prix_article");
            entity.Property(e => e.DateInsert)
                .HasColumnType("date")
                .HasColumnName("date_insert");
            entity.Property(e => e.IdArticle).HasColumnName("id_article");
            entity.Property(e => e.IdOffreEngagement).HasColumnName("id_offre_engagement");
            entity.Property(e => e.PrixArticle1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("prix_article");

            entity.HasOne(d => d.IdArticleNavigation).WithMany(p => p.PrixArticles)
                .HasForeignKey(d => d.IdArticle)
                .HasConstraintName("FK_prix_article_article");

            entity.HasOne(d => d.IdOffreEngagementNavigation).WithMany(p => p.PrixArticles)
                .HasForeignKey(d => d.IdOffreEngagement)
                .HasConstraintName("FK_prix_article_offre_engagement");
        });

        modelBuilder.Entity<Prospect>(entity =>
        {
            entity.HasKey(e => e.IdProspect).HasName("PK__prospect__6B3AC313648BB801");

            entity.ToTable("prospect");

            entity.Property(e => e.IdProspect).HasColumnName("id_prospect");
            entity.Property(e => e.DatCre)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("date")
                .HasColumnName("dat_cre");
            entity.Property(e => e.DatMod)
                .HasColumnType("date")
                .HasColumnName("dat_mod");
            entity.Property(e => e.DateNaissance)
                .HasColumnType("date")
                .HasColumnName("date_naissance");
            entity.Property(e => e.DepNaissance)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("dep_naissance");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdAdresseFacturation).HasColumnName("id_adresse_facturation");
            entity.Property(e => e.IdAdresseLivraison).HasColumnName("id_adresse_livraison");
            entity.Property(e => e.IdCivilite).HasColumnName("id_civilite");
            entity.Property(e => e.IdCoordonneesBancaires).HasColumnName("id_coordonnees_bancaires");
            entity.Property(e => e.IdModepaiementSouscription).HasColumnName("id_modepaiement_souscription");
            entity.Property(e => e.IdSouscription).HasColumnName("id_souscription");
            entity.Property(e => e.Nom)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.NumeroFixe)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("numero_fixe");
            entity.Property(e => e.NumeroMobile)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("numero_mobile");
            entity.Property(e => e.Prenom)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("prenom");

            entity.HasOne(d => d.IdCoordonneesBancairesNavigation).WithMany(p => p.Prospects)
                .HasForeignKey(d => d.IdCoordonneesBancaires)
                .HasConstraintName("FK__prospect__id_coo__45BE5BA9");
        });

        modelBuilder.Entity<Souscription>(entity =>
        {
            entity.HasKey(e => e.IdSouscription).HasName("PK__souscrip__A5BABA32E988E1D6");

            entity.ToTable("souscription");

            entity.Property(e => e.IdSouscription).HasColumnName("id_souscription");
            entity.Property(e => e.DateModification)
                .HasColumnType("date")
                .HasColumnName("date_modification");
            entity.Property(e => e.DateSouscription)
                .HasColumnType("date")
                .HasColumnName("date_souscription");
            entity.Property(e => e.IdModeLivraison)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("id_mode_livraison");
            entity.Property(e => e.IdStatutSouscription).HasColumnName("id_statut_souscription");
            entity.Property(e => e.MontantPaye)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("montant_paye");
            entity.Property(e => e.NumContrat)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("num_contrat");
            entity.Property(e => e.PrixLivraison)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("prix_livraison");

            entity.HasOne(d => d.IdStatutSouscriptionNavigation).WithMany(p => p.Souscriptions)
                .HasForeignKey(d => d.IdStatutSouscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__souscript__id_st__18EBB532");
        });

        modelBuilder.Entity<StatutSouscription>(entity =>
        {
            entity.HasKey(e => e.IdStatutSouscription).HasName("PK__statut_s__DA50E0249AA68D50");

            entity.ToTable("statut_souscription");

            entity.Property(e => e.IdStatutSouscription)
                .ValueGeneratedNever()
                .HasColumnName("id_statut_souscription");
            entity.Property(e => e.EstSouscriptionComplete)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("est_souscription_complete");
            entity.Property(e => e.LibelleStatutSouscription)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("libelle_statut_souscription");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
