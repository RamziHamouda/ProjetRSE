﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RSEBack.data;

namespace RSEBack.Migrations
{
    [DbContext(typeof(RSEContext))]
    [Migration("20210607221514_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RSEBack.Models.Actualite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actualites");
                });

            modelBuilder.Entity("RSEBack.Models.Impact", b =>
                {
                    b.Property<int>("IdImpact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aime")
                        .HasColumnType("bit");

                    b.Property<float>("Dons")
                        .HasColumnType("real");

                    b.Property<float>("HeureTravail")
                        .HasColumnType("real");

                    b.Property<int>("IdProjet")
                        .HasColumnType("int");

                    b.Property<int>("IdUtilisateur")
                        .HasColumnType("int");

                    b.HasKey("IdImpact");

                    b.HasIndex("IdProjet");

                    b.HasIndex("IdUtilisateur");

                    b.ToTable("Impacts");
                });

            modelBuilder.Entity("RSEBack.Models.Partenaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Partenaires");
                });

            modelBuilder.Entity("RSEBack.Models.PartenaireProjet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateCreation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPartenaire")
                        .HasColumnType("int");

                    b.Property<int>("IdProjet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPartenaire");

                    b.HasIndex("IdProjet");

                    b.ToTable("PartenaireProjet");
                });

            modelBuilder.Entity("RSEBack.Models.Projet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("RSEBack.Models.Suggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUtilisateur")
                        .HasColumnType("int");

                    b.Property<string>("Sujet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUtilisateur");

                    b.ToTable("Suggestions");
                });

            modelBuilder.Entity("RSEBack.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateDeNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MembreEquipeRSE")
                        .HasColumnType("bit");

                    b.Property<string>("MotDePasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoProfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("RSEBack.Models.Impact", b =>
                {
                    b.HasOne("RSEBack.Models.Projet", "Projet")
                        .WithMany("Impacts")
                        .HasForeignKey("IdProjet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RSEBack.Models.Utilisateur", "Utilisateur")
                        .WithMany("Impacts")
                        .HasForeignKey("IdUtilisateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projet");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("RSEBack.Models.PartenaireProjet", b =>
                {
                    b.HasOne("RSEBack.Models.Partenaire", "Partenaire")
                        .WithMany("PartenaireProjet")
                        .HasForeignKey("IdPartenaire")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RSEBack.Models.Projet", "Projet")
                        .WithMany("PartenaireProjet")
                        .HasForeignKey("IdProjet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partenaire");

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("RSEBack.Models.Suggestion", b =>
                {
                    b.HasOne("RSEBack.Models.Utilisateur", "Utilisateur")
                        .WithMany("Suggestions")
                        .HasForeignKey("IdUtilisateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("RSEBack.Models.Partenaire", b =>
                {
                    b.Navigation("PartenaireProjet");
                });

            modelBuilder.Entity("RSEBack.Models.Projet", b =>
                {
                    b.Navigation("Impacts");

                    b.Navigation("PartenaireProjet");
                });

            modelBuilder.Entity("RSEBack.Models.Utilisateur", b =>
                {
                    b.Navigation("Impacts");

                    b.Navigation("Suggestions");
                });
#pragma warning restore 612, 618
        }
    }
}
