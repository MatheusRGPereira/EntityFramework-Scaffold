// <auto-generated />
using System;
using LocacaoGama.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocacaoGama.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230104010942_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LocacaoGama.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("modelo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_carros");
                });

            modelBuilder.Entity("LocacaoGama.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("modelo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_clientes");
                });

            modelBuilder.Entity("LocacaoGama.Models.Configuracao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("diasDeLocacao")
                        .HasColumnType("DateTime")
                        .HasColumnName("dias_de_locacao");

                    b.HasKey("id");

                    b.ToTable("tb_configuracoes");
                });

            modelBuilder.Entity("LocacaoGama.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_marcas");
                });

            modelBuilder.Entity("LocacaoGama.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_modelos");
                });

            modelBuilder.Entity("LocacaoGama.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Carro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("carro");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("DateTime")
                        .HasColumnName("data_entrega");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("DateTime")
                        .HasColumnName("data_locacao");

                    b.Property<string>("IdCliente")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("id_cliente");

                    b.HasKey("Id");

                    b.ToTable("tb_pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
