﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValiProyecto.Models;

#nullable disable

namespace ValiProyecto.Migrations
{
    [DbContext(typeof(ProyectoValiContext))]
    [Migration("20230922120018_ligin")]
    partial class ligin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ValiProyecto.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCategoria")
                        .HasName("PK__Categori__A3C02A10374BB3DF");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ValiProyecto.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<int>("Cedula")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCliente")
                        .HasName("PK__Clientes__D5946642EA6764D7");

                    b.HasIndex(new[] { "Cedula" }, "UQ__Clientes__B4ADFE38985DF55B")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ValiProyecto.Models.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompra"));

                    b.Property<DateTime>("FechaCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("OrdenCompraId")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdCompra")
                        .HasName("PK__Compras__0A5CDB5CE98F2094");

                    b.HasIndex("OrdenCompraId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("ValiProyecto.Models.DetallesCompra", b =>
                {
                    b.Property<int>("IdDetalleCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleCompra"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdDetalleCompra")
                        .HasName("PK__Detalles__E046CCBB7EEB347D");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallesCompras");
                });

            modelBuilder.Entity("ValiProyecto.Models.DetallesOrdenCompra", b =>
                {
                    b.Property<int>("IdDetalleOrdenCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleOrdenCompra"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("OrdenCompraId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdDetalleOrdenCompra")
                        .HasName("PK__Detalles__F75F8C296491E8FC");

                    b.HasIndex("OrdenCompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallesOrdenCompras");
                });

            modelBuilder.Entity("ValiProyecto.Models.DetallesVenta", b =>
                {
                    b.Property<int>("DetalleVentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleVentaId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("DetalleVentaId")
                        .HasName("PK__Detalles__340EEDA4B2FDC949");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("DetallesVentas");
                });

            modelBuilder.Entity("ValiProyecto.Models.OrdenCompra", b =>
                {
                    b.Property<int>("IdOrdenCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrdenCompra"));

                    b.Property<DateTime>("FechaOrdenCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdOrdenCompra")
                        .HasName("PK__OrdenCom__685E464B262E87E3");

                    b.HasIndex("ProveedorId");

                    b.ToTable("OrdenCompras");
                });

            modelBuilder.Entity("ValiProyecto.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Iva")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("IdProducto")
                        .HasName("PK__Producto__09889210D345D98A");

                    b.HasIndex("CategoriaId");

                    b.HasIndex(new[] { "Codigo" }, "UQ__Producto__06370DACE6D5ADE7")
                        .IsUnique();

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ValiProyecto.Models.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProveedor"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdProveedor")
                        .HasName("PK__Proveedo__E8B631AF34BE7792");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("ValiProyecto.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ValiProyecto.Models.Venta", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenta"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdVenta")
                        .HasName("PK__Ventas__BC1240BD1471A4C1");

                    b.HasIndex("ClienteId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ValiProyecto.Models.Compra", b =>
                {
                    b.HasOne("ValiProyecto.Models.OrdenCompra", "OrdenCompra")
                        .WithMany("Compras")
                        .HasForeignKey("OrdenCompraId")
                        .IsRequired()
                        .HasConstraintName("FK__Compras__OrdenCo__5441852A");

                    b.HasOne("ValiProyecto.Models.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("ProveedorId")
                        .IsRequired()
                        .HasConstraintName("FK__Compras__Proveed__534D60F1");

                    b.Navigation("OrdenCompra");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("ValiProyecto.Models.DetallesCompra", b =>
                {
                    b.HasOne("ValiProyecto.Models.Compra", "Compra")
                        .WithMany("DetallesCompras")
                        .HasForeignKey("CompraId")
                        .IsRequired()
                        .HasConstraintName("FK__DetallesC__Compr__571DF1D5");

                    b.HasOne("ValiProyecto.Models.Producto", "Producto")
                        .WithMany("DetallesCompras")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("FK__DetallesC__Produ__5812160E");

                    b.Navigation("Compra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ValiProyecto.Models.DetallesOrdenCompra", b =>
                {
                    b.HasOne("ValiProyecto.Models.OrdenCompra", "OrdenCompra")
                        .WithMany("DetallesOrdenCompras")
                        .HasForeignKey("OrdenCompraId")
                        .IsRequired()
                        .HasConstraintName("FK__DetallesO__Orden__4E88ABD4");

                    b.HasOne("ValiProyecto.Models.Producto", "Producto")
                        .WithMany("DetallesOrdenCompras")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("FK__DetallesO__Produ__4F7CD00D");

                    b.Navigation("OrdenCompra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ValiProyecto.Models.DetallesVenta", b =>
                {
                    b.HasOne("ValiProyecto.Models.Producto", "Producto")
                        .WithMany("DetallesVenta")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("FK__DetallesV__Produ__47DBAE45");

                    b.HasOne("ValiProyecto.Models.Venta", "Venta")
                        .WithMany("DetallesVenta")
                        .HasForeignKey("VentaId")
                        .IsRequired()
                        .HasConstraintName("FK__DetallesV__Venta__46E78A0C");

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ValiProyecto.Models.OrdenCompra", b =>
                {
                    b.HasOne("ValiProyecto.Models.Proveedor", "Proveedor")
                        .WithMany("OrdenCompras")
                        .HasForeignKey("ProveedorId")
                        .IsRequired()
                        .HasConstraintName("FK__OrdenComp__Prove__4BAC3F29");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("ValiProyecto.Models.Producto", b =>
                {
                    b.HasOne("ValiProyecto.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .IsRequired()
                        .HasConstraintName("FK__Productos__Categ__403A8C7D");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ValiProyecto.Models.Proveedor", b =>
                {
                    b.HasOne("ValiProyecto.Models.Categoria", "Categoria")
                        .WithMany("Proveedores")
                        .HasForeignKey("CategoriaId")
                        .IsRequired()
                        .HasConstraintName("FK__Proveedor__Estad__3C69FB99");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ValiProyecto.Models.Venta", b =>
                {
                    b.HasOne("ValiProyecto.Models.Cliente", "Cliente")
                        .WithMany("Venta")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK__Ventas__ClienteI__440B1D61");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ValiProyecto.Models.Categoria", b =>
                {
                    b.Navigation("Productos");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("ValiProyecto.Models.Cliente", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ValiProyecto.Models.Compra", b =>
                {
                    b.Navigation("DetallesCompras");
                });

            modelBuilder.Entity("ValiProyecto.Models.OrdenCompra", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("DetallesOrdenCompras");
                });

            modelBuilder.Entity("ValiProyecto.Models.Producto", b =>
                {
                    b.Navigation("DetallesCompras");

                    b.Navigation("DetallesOrdenCompras");

                    b.Navigation("DetallesVenta");
                });

            modelBuilder.Entity("ValiProyecto.Models.Proveedor", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("OrdenCompras");
                });

            modelBuilder.Entity("ValiProyecto.Models.Venta", b =>
                {
                    b.Navigation("DetallesVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
