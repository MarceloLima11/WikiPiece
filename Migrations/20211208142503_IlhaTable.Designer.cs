﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WikiPiece.Data;

namespace WikiPiece.Migrations
{
    [DbContext(typeof(WikiPieceContext))]
    [Migration("20211208142503_IlhaTable")]
    partial class IlhaTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("WikiPiece.Models.AkumaNoMi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(20000)
                        .HasColumnType("longtext");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("varchar(17)");

                    b.Property<string>("PrimeiraAparicao")
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.HasKey("Id");

                    b.ToTable("AkumaNoMis");
                });

            modelBuilder.Entity("WikiPiece.Models.Ilha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Clima")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Ilhas");
                });

            modelBuilder.Entity("WikiPiece.Models.Personagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AkumaNoMiId")
                        .HasColumnType("int");

                    b.Property<string>("Altura")
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .HasMaxLength(20000)
                        .HasColumnType("longtext");

                    b.Property<string>("FraseMarcante")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<int?>("IlhaId")
                        .HasColumnType("int");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Linhagem")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PrimeiraAparicao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Recompensa")
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("Top5")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("AkumaNoMiId");

                    b.HasIndex("IlhaId");

                    b.ToTable("Personagens");
                });

            modelBuilder.Entity("WikiPiece.Models.Personagem", b =>
                {
                    b.HasOne("WikiPiece.Models.AkumaNoMi", "AkumaNoMi")
                        .WithMany("Personagens")
                        .HasForeignKey("AkumaNoMiId");

                    b.HasOne("WikiPiece.Models.Ilha", null)
                        .WithMany("Personagens")
                        .HasForeignKey("IlhaId");

                    b.Navigation("AkumaNoMi");
                });

            modelBuilder.Entity("WikiPiece.Models.AkumaNoMi", b =>
                {
                    b.Navigation("Personagens");
                });

            modelBuilder.Entity("WikiPiece.Models.Ilha", b =>
                {
                    b.Navigation("Personagens");
                });
#pragma warning restore 612, 618
        }
    }
}
