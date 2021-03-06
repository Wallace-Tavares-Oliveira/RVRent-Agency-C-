// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RVRentAgencia.Data;

namespace RVRentAgencia.Migrations
{
    [DbContext(typeof(ClienteContext))]
    [Migration("20220113051105_RVRenteAgencia")]
    partial class RVRenteAgencia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RVRentAgencia.Models.Cliente", b =>
                {
                    b.Property<int>("Id_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContatoId_contato")
                        .HasColumnType("int");

                    b.Property<int>("DestinoId_destino")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PromocaoId_promocao")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Cliente");

                    b.HasIndex("ContatoId_contato");

                    b.HasIndex("DestinoId_destino");

                    b.HasIndex("PromocaoId_promocao");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RVRentAgencia.Models.Contato", b =>
                {
                    b.Property<int>("Id_Contato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Contato");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("RVRentAgencia.Models.Destino", b =>
                {
                    b.Property<int>("Id_Destino")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Partida")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Retorno")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_Destino");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("RVRentAgencia.Models.Promocao", b =>
                {
                    b.Property<int>("Id_Promocao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Preco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Promocao");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("RVRentAgencia.Models.Cliente", b =>
                {
                    b.HasOne("RVRentAgencia.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId_contato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RVRentAgencia.Models.Destino", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoId_destino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RVRentAgencia.Models.Promocao", "Promocao")
                        .WithMany()
                        .HasForeignKey("PromocaoId_promocao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("Destino");

                    b.Navigation("Promocao");
                });
#pragma warning restore 612, 618
        }
    }
}
