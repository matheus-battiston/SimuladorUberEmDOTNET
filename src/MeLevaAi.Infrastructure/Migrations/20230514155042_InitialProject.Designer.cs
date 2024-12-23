﻿// <auto-generated />
using System;
using MeLevaAi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeLevaAi.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230514155042_InitialProject")]
    partial class InitialProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MeLevaAi.Domain.Models.Corrida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HorarioChegada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HorarioInicio")
                        .HasColumnType("TEXT");

                    b.Property<double>("LatitudeFinal")
                        .HasColumnType("REAL");

                    b.Property<double>("LatitudeInicio")
                        .HasColumnType("REAL");

                    b.Property<double>("LongitudeFinal")
                        .HasColumnType("REAL");

                    b.Property<double>("LongitudeInicio")
                        .HasColumnType("REAL");

                    b.Property<Guid>("MotoristaId")
                        .HasColumnType("TEXT");

                    b.Property<int>("NotaMotorista")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NotaPassageiro")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PassageiroId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorEstimado")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("PassageiroId");

                    b.ToTable("Corridas");
                });

            modelBuilder.Entity("MeLevaAi.Domain.Models.Motorista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HabilitacaoCategoria")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("HabilitacaoDataVencimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("HabilitacaoNumero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("MediaDasNotas")
                        .HasColumnType("REAL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroDeCorridas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantidadeDeAvaliacoes")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Saldo")
                        .HasColumnType("REAL");

                    b.Property<int>("SomaDasNotas")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("VeiculoId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("MeLevaAi.Domain.Models.Passageiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MediaDasAvaliacoes")
                        .HasColumnType("REAL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroDeCorridas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantidadeAvaliacoes")
                        .HasColumnType("INTEGER");

                    b.Property<float>("SaldoEmConta")
                        .HasColumnType("REAL");

                    b.Property<int>("SomaDasNotas")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Passageiros");
                });

            modelBuilder.Entity("MeLevaAi.Domain.Models.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Categoria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("MeLevaAi.Domain.Models.Corrida", b =>
                {
                    b.HasOne("MeLevaAi.Domain.Models.Motorista", "Motorista")
                        .WithMany("Corridas")
                        .HasForeignKey("PassageiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeLevaAi.Domain.Models.Passageiro", "Passageiro")
                        .WithMany("Corridas")
                        .HasForeignKey("PassageiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motorista");

                    b.Navigation("Passageiro");
                });

            modelBuilder.Entity("MeLevaAi.Domain.Models.Motorista", b =>
                {
                    b.HasOne("MeLevaAi.Domain.Models.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("MeLevaAi.Domain.Models.Motorista", b =>
                {
                    b.Navigation("Corridas");
                });

            modelBuilder.Entity("MeLevaAi.Domain.Models.Passageiro", b =>
                {
                    b.Navigation("Corridas");
                });
#pragma warning restore 612, 618
        }
    }
}