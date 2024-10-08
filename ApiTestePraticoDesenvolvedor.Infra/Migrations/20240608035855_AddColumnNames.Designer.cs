﻿// <auto-generated />
using System;
using ApiConta.Infra.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiConta.Infra.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240608035855_AddColumnNames")]
    partial class AddColumnNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiConta.Domain.Entities.ContaEntity", b =>
                {
                    b.Property<Guid>("IdConta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_CONTA");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_PAGAMENTO_CONTA");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_VENCIMENTO_CONTA");

                    b.Property<int>("DiasAtrasados")
                        .HasColumnType("int")
                        .HasColumnName("DIAS_ATRASADOS_CONTA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME_CONTA");

                    b.Property<double>("ValorCorrigido")
                        .HasColumnType("float")
                        .HasColumnName("VALOR_CORRIGIDO_CONTA");

                    b.Property<double>("ValorOriginal")
                        .HasColumnType("float")
                        .HasColumnName("VALOR_ORIGINAL_CONTA");

                    b.HasKey("IdConta");

                    b.ToTable("CONTA_DATABASE", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
