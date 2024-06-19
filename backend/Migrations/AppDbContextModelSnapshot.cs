﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using purrfect_olho_vivo_api.Context;

#nullable disable

namespace purrfect_olho_vivo_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LinhaParada", b =>
                {
                    b.Property<long>("LinhasId")
                        .HasColumnType("bigint");

                    b.Property<long>("ParadasId")
                        .HasColumnType("bigint");

                    b.HasKey("LinhasId", "ParadasId");

                    b.HasIndex("ParadasId");

                    b.ToTable("LinhaParada", (string)null);
                });

            modelBuilder.Entity("purrfect_olho_vivo_api.ViewModels.Models.Linha", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Linha");
                });

            modelBuilder.Entity("purrfect_olho_vivo_api.ViewModels.Models.Parada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parada");
                });

            modelBuilder.Entity("purrfect_olho_vivo_api.ViewModels.Models.PosicaoVeiculo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<long>("VeiculoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("PosicoesVeiculo");
                });

            modelBuilder.Entity("purrfect_olho_vivo_api.ViewModels.Models.Veiculo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("LinhaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LinhaId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("LinhaParada", b =>
                {
                    b.HasOne("purrfect_olho_vivo_api.ViewModels.Models.Linha", null)
                        .WithMany()
                        .HasForeignKey("LinhasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("purrfect_olho_vivo_api.ViewModels.Models.Parada", null)
                        .WithMany()
                        .HasForeignKey("ParadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("purrfect_olho_vivo_api.ViewModels.Models.PosicaoVeiculo", b =>
                {
                    b.HasOne("purrfect_olho_vivo_api.ViewModels.Models.Veiculo", "Veiculo")
                        .WithMany("PosicoesVeiculo")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("purrfect_olho_vivo_api.ViewModels.Models.Veiculo", b =>
                {
                    b.HasOne("purrfect_olho_vivo_api.ViewModels.Models.Linha", "Linha")
                        .WithMany()
                        .HasForeignKey("LinhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Linha");
                });

            modelBuilder.Entity("purrfect_olho_vivo_api.ViewModels.Models.Veiculo", b =>
                {
                    b.Navigation("PosicoesVeiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
