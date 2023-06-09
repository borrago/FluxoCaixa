﻿// <auto-generated />
using System;
using FluxoCaixa.Lancamentos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FluxoCaixa.Lancamentos.Data.Migrations
{
    [DbContext(typeof(LancamentoContext))]
    [Migration("20230516234553_Initi")]
    partial class Initi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FluxoCaixa.Lancamentos.Domain.Lancamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataRecebimento")
                        .HasColumnType("datetime2");

                    b.Property<byte>("TipoLancamento")
                        .HasColumnType("tinyint");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Lancamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
