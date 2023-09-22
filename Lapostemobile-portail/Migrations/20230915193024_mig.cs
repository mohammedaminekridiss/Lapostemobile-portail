using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapostemobile_portail.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adresse",
                columns: table => new
                {
                    id_adresse = table.Column<int>(type: "int", nullable: false),
                    id_pays = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    voie = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    ville = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    codepostal = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    adresse_comp = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    dat_cre = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(sysdatetime())"),
                    dat_mod = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__adresse__05B3E6DC602BFAB6", x => x.id_adresse);
                });

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    id_article = table.Column<int>(type: "int", nullable: false),
                    id_type_article = table.Column<int>(type: "int", nullable: false),
                    code_sap = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: true),
                    libelle_article = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    ordre = table.Column<int>(type: "int", nullable: true),
                    statut = table.Column<bool>(type: "bit", nullable: false),
                    fichier_image_vignette = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    fichier_image = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    libelle_court = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    id_fabriquant = table.Column<int>(type: "int", nullable: true),
                    date_fin_ccial = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__article__64CB31B82888E3FD", x => x.id_article);
                });

            migrationBuilder.CreateTable(
                name: "coordonnees_bancaires",
                columns: table => new
                {
                    id_coordonnees = table.Column<int>(type: "int", nullable: false),
                    titulaire_compte = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    nom_banque = table.Column<string>(type: "varchar(58)", unicode: false, maxLength: 58, nullable: true),
                    iban = table.Column<string>(type: "varchar(34)", unicode: false, maxLength: 34, nullable: true),
                    code_bic = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    date_creation = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(sysdatetime())"),
                    date_modification = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__coordonn__AF9E03123FB3761A", x => x.id_coordonnees);
                });

            migrationBuilder.CreateTable(
                name: "mode_livraison",
                columns: table => new
                {
                    id_mode_livraison = table.Column<int>(type: "int", nullable: false),
                    libelle_mode_livraison = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__mode_liv__C95298B7B962A58E", x => x.id_mode_livraison);
                });

            migrationBuilder.CreateTable(
                name: "offre_engagement",
                columns: table => new
                {
                    id_offre_engagement = table.Column<int>(type: "int", nullable: false),
                    duree_engagement = table.Column<int>(type: "int", nullable: false),
                    prix = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    libelle_marketing = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    montant_subvention = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    caracteristiques = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    est_5g = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__offre_en__857BF79C0AC2E96F", x => x.id_offre_engagement);
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    id_option = table.Column<int>(type: "int", nullable: false),
                    id_groupe_option = table.Column<int>(type: "int", nullable: false),
                    libelle_option = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    libelle_marketing = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    ordre_affichage = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValueSql: "((0))"),
                    description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__options__7B78D9B64C0BC083", x => x.id_option);
                });

            migrationBuilder.CreateTable(
                name: "statut_souscription",
                columns: table => new
                {
                    id_statut_souscription = table.Column<int>(type: "int", nullable: false),
                    libelle_statut_souscription = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    est_souscription_complete = table.Column<decimal>(type: "numeric(1,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__statut_s__DA50E02423CA42C6", x => x.id_statut_souscription);
                });

            migrationBuilder.CreateTable(
                name: "caracteristiques_articles",
                columns: table => new
                {
                    id_caracteristiques_articles = table.Column<int>(type: "int", nullable: false),
                    id_article = table.Column<int>(type: "int", nullable: false),
                    Nom_caracteristiques_articles = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    valeur_carasteristiques_articles = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__caracter__6F85FECF37650E6D", x => x.id_caracteristiques_articles);
                    table.ForeignKey(
                        name: "FK__caracteri__id_ar__60A75C0F",
                        column: x => x.id_article,
                        principalTable: "article",
                        principalColumn: "id_article");
                });

            migrationBuilder.CreateTable(
                name: "prospect",
                columns: table => new
                {
                    id_prospect = table.Column<int>(type: "int", nullable: false),
                    id_civilite = table.Column<int>(type: "int", nullable: false),
                    id_souscription = table.Column<int>(type: "int", nullable: false),
                    id_adresse_facturation = table.Column<int>(type: "int", nullable: true),
                    id_adresse_livraison = table.Column<int>(type: "int", nullable: true),
                    id_modepaiement_souscription = table.Column<int>(type: "int", nullable: false),
                    nom = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    prenom = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    date_naissance = table.Column<DateTime>(type: "date", nullable: false),
                    dep_naissance = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    dat_cre = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(sysdatetime())"),
                    dat_mod = table.Column<DateTime>(type: "date", nullable: true),
                    id_coordonnees_bancaires = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    numero_fixe = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    numero_mobile = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__prospect__6B3AC313077C5DF6", x => x.id_prospect);
                    table.ForeignKey(
                        name: "FK__prospect__id_coo__3D5E1FD2",
                        column: x => x.id_coordonnees_bancaires,
                        principalTable: "coordonnees_bancaires",
                        principalColumn: "id_coordonnees");
                });

            migrationBuilder.CreateTable(
                name: "prix_article",
                columns: table => new
                {
                    id_prix_article = table.Column<int>(type: "int", nullable: false),
                    id_article = table.Column<int>(type: "int", nullable: false),
                    id_offre_engagement = table.Column<int>(type: "int", nullable: false),
                    prix_article = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    date_insert = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__prix_art__B64515C8F009DBA4", x => x.id_prix_article);
                    table.ForeignKey(
                        name: "FK_prix_article_article",
                        column: x => x.id_article,
                        principalTable: "article",
                        principalColumn: "id_article",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prix_article_offre_engagement",
                        column: x => x.id_offre_engagement,
                        principalTable: "offre_engagement",
                        principalColumn: "id_offre_engagement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "financement",
                columns: table => new
                {
                    id_financement = table.Column<int>(type: "int", nullable: false),
                    montant_financement = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    duree_financement = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    id_option = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__financem__A9EB9E164074079B", x => x.id_financement);
                    table.ForeignKey(
                        name: "FK__financeme__id_op__49C3F6B7",
                        column: x => x.id_option,
                        principalTable: "options",
                        principalColumn: "id_option");
                });

            migrationBuilder.CreateTable(
                name: "souscription",
                columns: table => new
                {
                    id_souscription = table.Column<int>(type: "int", nullable: false),
                    id_statut_souscription = table.Column<int>(type: "int", nullable: false),
                    date_souscription = table.Column<DateTime>(type: "date", nullable: false),
                    num_contrat = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    date_modification = table.Column<DateTime>(type: "date", nullable: true),
                    id_mode_livraison = table.Column<decimal>(type: "numeric(10,0)", nullable: false),
                    prix_livraison = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    montant_paye = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__souscrip__A5BABA325DC0888D", x => x.id_souscription);
                    table.ForeignKey(
                        name: "FK__souscript__id_st__412EB0B6",
                        column: x => x.id_statut_souscription,
                        principalTable: "statut_souscription",
                        principalColumn: "id_statut_souscription");
                });

            migrationBuilder.CreateTable(
                name: "ligne",
                columns: table => new
                {
                    id_ligne = table.Column<int>(type: "int", nullable: false),
                    id_souscription = table.Column<int>(type: "int", nullable: false),
                    id_offre_engagement = table.Column<int>(type: "int", nullable: true),
                    prix_vente_offre = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    dat_cre = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(sysdatetime())"),
                    dat_mod = table.Column<DateTime>(type: "date", nullable: true),
                    id_financement = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ligne__E1D60C0C35DB3C13", x => x.id_ligne);
                    table.ForeignKey(
                        name: "FK__ligne__id_financ__5165187F",
                        column: x => x.id_financement,
                        principalTable: "financement",
                        principalColumn: "id_financement");
                    table.ForeignKey(
                        name: "FK__ligne__id_offre___52593CB8",
                        column: x => x.id_offre_engagement,
                        principalTable: "offre_engagement",
                        principalColumn: "id_offre_engagement");
                    table.ForeignKey(
                        name: "FK__ligne__id_souscr__534D60F1",
                        column: x => x.id_souscription,
                        principalTable: "souscription",
                        principalColumn: "id_souscription");
                });

            migrationBuilder.CreateTable(
                name: "ligne_article",
                columns: table => new
                {
                    id_ligne_article = table.Column<int>(type: "int", nullable: false),
                    id_ligne = table.Column<int>(type: "int", nullable: false),
                    id_article = table.Column<int>(type: "int", nullable: true),
                    prix_paye = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    total_subvention = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    dat_cre = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(sysdatetime())"),
                    dat_mod = table.Column<DateTime>(type: "date", nullable: true),
                    imei = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ligne_ar__813AC43D1DD68471", x => x.id_ligne_article);
                    table.ForeignKey(
                        name: "FK__ligne_art__id_li__59FA5E80",
                        column: x => x.id_ligne,
                        principalTable: "ligne",
                        principalColumn: "id_ligne");
                });

            migrationBuilder.CreateTable(
                name: "ligne_option",
                columns: table => new
                {
                    id_ligne_option = table.Column<int>(type: "int", nullable: false),
                    id_ligne = table.Column<int>(type: "int", nullable: false),
                    id_option = table.Column<int>(type: "int", nullable: true),
                    prix_vente_option = table.Column<int>(type: "int", nullable: false),
                    date_creation = table.Column<DateTime>(type: "date", nullable: true),
                    dat_mod = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ligne_op__6498FBB40410619C", x => x.id_ligne_option);
                    table.ForeignKey(
                        name: "FK__ligne_opt__id_li__5CD6CB2B",
                        column: x => x.id_ligne,
                        principalTable: "ligne",
                        principalColumn: "id_ligne");
                    table.ForeignKey(
                        name: "FK__ligne_opt__id_op__5DCAEF64",
                        column: x => x.id_option,
                        principalTable: "options",
                        principalColumn: "id_option");
                });

            migrationBuilder.CreateIndex(
                name: "IX_caracteristiques_articles_id_article",
                table: "caracteristiques_articles",
                column: "id_article");

            migrationBuilder.CreateIndex(
                name: "IX_financement_id_option",
                table: "financement",
                column: "id_option");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_id_financement",
                table: "ligne",
                column: "id_financement");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_id_offre_engagement",
                table: "ligne",
                column: "id_offre_engagement");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_id_souscription",
                table: "ligne",
                column: "id_souscription");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_article_id_ligne",
                table: "ligne_article",
                column: "id_ligne");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_option_id_ligne",
                table: "ligne_option",
                column: "id_ligne");

            migrationBuilder.CreateIndex(
                name: "IX_ligne_option_id_option",
                table: "ligne_option",
                column: "id_option");

            migrationBuilder.CreateIndex(
                name: "IX_prix_article_id_article",
                table: "prix_article",
                column: "id_article");

            migrationBuilder.CreateIndex(
                name: "IX_prix_article_id_offre_engagement",
                table: "prix_article",
                column: "id_offre_engagement");

            migrationBuilder.CreateIndex(
                name: "IX_prospect_id_coordonnees_bancaires",
                table: "prospect",
                column: "id_coordonnees_bancaires");

            migrationBuilder.CreateIndex(
                name: "IX_souscription_id_statut_souscription",
                table: "souscription",
                column: "id_statut_souscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adresse");

            migrationBuilder.DropTable(
                name: "caracteristiques_articles");

            migrationBuilder.DropTable(
                name: "ligne_article");

            migrationBuilder.DropTable(
                name: "ligne_option");

            migrationBuilder.DropTable(
                name: "mode_livraison");

            migrationBuilder.DropTable(
                name: "prix_article");

            migrationBuilder.DropTable(
                name: "prospect");

            migrationBuilder.DropTable(
                name: "ligne");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "coordonnees_bancaires");

            migrationBuilder.DropTable(
                name: "financement");

            migrationBuilder.DropTable(
                name: "offre_engagement");

            migrationBuilder.DropTable(
                name: "souscription");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "statut_souscription");
        }
    }
}
