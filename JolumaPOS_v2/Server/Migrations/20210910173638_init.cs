using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JolumaPOS_v2.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    padre = table.Column<int>(type: "int", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria1",
                        column: x => x.padre,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContactoTipo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactoTipo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InventarioStatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razonSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    calleDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMoneda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMoneda", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VentaStatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InventarioSalida",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    caja = table.Column<int>(type: "int", nullable: false),
                    empleado = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioSalida", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventarioSalida_Caja",
                        column: x => x.caja,
                        principalTable: "Caja",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioSalida_InventarioStatus",
                        column: x => x.status,
                        principalTable: "InventarioStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proveedor = table.Column<int>(type: "int", nullable: false),
                    tipoContacto = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contacto_ContactoProveedor",
                        column: x => x.proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacto_ContactoTipo",
                        column: x => x.tipoContacto,
                        principalTable: "ContactoTipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventarioEntrada",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proveedor = table.Column<int>(type: "int", nullable: false),
                    empleado = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    caja = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioEntrada", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventarioEntrada_Caja",
                        column: x => x.caja,
                        principalTable: "Caja",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioEntrada_ContactoProveedor",
                        column: x => x.proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioEntrada_InventarioStatus",
                        column: x => x.status,
                        principalTable: "InventarioStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoBarras = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    unidadMedida = table.Column<int>(type: "int", nullable: false),
                    requiereInventario = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria1",
                        column: x => x.categoria,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_UnidadMedida",
                        column: x => x.unidadMedida,
                        principalTable: "UnidadMedida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente = table.Column<int>(type: "int", nullable: false),
                    empleado = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    nombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caja = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Venta_Caja",
                        column: x => x.caja,
                        principalTable: "Caja",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente",
                        column: x => x.cliente,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venta_VentaStatus",
                        column: x => x.status,
                        principalTable: "VentaStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    caja = table.Column<int>(type: "int", nullable: false),
                    producto = table.Column<int>(type: "int", nullable: false),
                    precioCompra = table.Column<decimal>(type: "money", nullable: false),
                    precioVenta = table.Column<decimal>(type: "money", nullable: false),
                    tipoMonedaCompra = table.Column<int>(type: "int", nullable: false),
                    tipoMonedaVenta = table.Column<int>(type: "int", nullable: false),
                    puntoReorden = table.Column<int>(type: "int", nullable: true),
                    cantidadStock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario_1", x => new { x.caja, x.producto });
                    table.ForeignKey(
                        name: "FK_Inventario_Caja",
                        column: x => x.caja,
                        principalTable: "Caja",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventario_Producto",
                        column: x => x.producto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventario_TipoMoneda",
                        column: x => x.tipoMonedaCompra,
                        principalTable: "TipoMoneda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventario_TipoMoneda1",
                        column: x => x.tipoMonedaVenta,
                        principalTable: "TipoMoneda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventarioEntradaDetalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entradaInventario = table.Column<int>(type: "int", nullable: false),
                    producto = table.Column<int>(type: "int", nullable: false),
                    razon = table.Column<int>(type: "int", nullable: false),
                    cantidadProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    precioCompra = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioEntradaDetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventarioEntradaDetalle_InventarioEntrada",
                        column: x => x.entradaInventario,
                        principalTable: "InventarioEntrada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioEntradaDetalle_Producto",
                        column: x => x.producto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventarioSalidaDetalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salidaInventario = table.Column<int>(type: "int", nullable: false),
                    producto = table.Column<int>(type: "int", nullable: false),
                    razon = table.Column<int>(type: "int", nullable: false),
                    cantidadProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioSalidaDetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventarioSalidaDetalle_InventarioSalida",
                        column: x => x.salidaInventario,
                        principalTable: "InventarioSalida",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioSalidaDetalle_Producto",
                        column: x => x.producto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VentaDetalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    venta = table.Column<int>(type: "int", nullable: false),
                    producto = table.Column<int>(type: "int", nullable: false),
                    cantProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    precioVenta = table.Column<decimal>(type: "money", nullable: false),
                    tipoMonedaVenta = table.Column<int>(type: "int", nullable: false),
                    precioCompra = table.Column<decimal>(type: "money", nullable: false),
                    tipoMonedaCompra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaDetalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_VentaDetalle_Producto1",
                        column: x => x.producto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VentaDetalle_Venta",
                        column: x => x.venta,
                        principalTable: "Venta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VentaPago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    venta = table.Column<int>(type: "int", nullable: false),
                    tipoPago = table.Column<int>(type: "int", nullable: false),
                    montoPagado = table.Column<decimal>(type: "money", nullable: false),
                    montoTotal = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaPago", x => x.id);
                    table.ForeignKey(
                        name: "FK_VentaPago_TipoPago",
                        column: x => x.tipoPago,
                        principalTable: "TipoPago",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VentaPago_Venta",
                        column: x => x.venta,
                        principalTable: "Venta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_padre",
                table: "Categoria",
                column: "padre");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_proveedor",
                table: "Contacto",
                column: "proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_tipoContacto",
                table: "Contacto",
                column: "tipoContacto");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_producto",
                table: "Inventario",
                column: "producto");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_tipoMonedaCompra",
                table: "Inventario",
                column: "tipoMonedaCompra");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_tipoMonedaVenta",
                table: "Inventario",
                column: "tipoMonedaVenta");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioEntrada_caja",
                table: "InventarioEntrada",
                column: "caja");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioEntrada_proveedor",
                table: "InventarioEntrada",
                column: "proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioEntrada_status",
                table: "InventarioEntrada",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioEntradaDetalle_entradaInventario",
                table: "InventarioEntradaDetalle",
                column: "entradaInventario");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioEntradaDetalle_producto",
                table: "InventarioEntradaDetalle",
                column: "producto");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioSalida_caja",
                table: "InventarioSalida",
                column: "caja");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioSalida_status",
                table: "InventarioSalida",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioSalidaDetalle_producto",
                table: "InventarioSalidaDetalle",
                column: "producto");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioSalidaDetalle_salidaInventario",
                table: "InventarioSalidaDetalle",
                column: "salidaInventario");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoria",
                table: "Producto",
                column: "categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_unidadMedida",
                table: "Producto",
                column: "unidadMedida");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_caja",
                table: "Venta",
                column: "caja");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_cliente",
                table: "Venta",
                column: "cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_status",
                table: "Venta",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalle_producto",
                table: "VentaDetalle",
                column: "producto");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalle_venta",
                table: "VentaDetalle",
                column: "venta");

            migrationBuilder.CreateIndex(
                name: "IX_VentaPago_tipoPago",
                table: "VentaPago",
                column: "tipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_VentaPago_venta",
                table: "VentaPago",
                column: "venta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "InventarioEntradaDetalle");

            migrationBuilder.DropTable(
                name: "InventarioSalidaDetalle");

            migrationBuilder.DropTable(
                name: "VentaDetalle");

            migrationBuilder.DropTable(
                name: "VentaPago");

            migrationBuilder.DropTable(
                name: "ContactoTipo");

            migrationBuilder.DropTable(
                name: "TipoMoneda");

            migrationBuilder.DropTable(
                name: "InventarioEntrada");

            migrationBuilder.DropTable(
                name: "InventarioSalida");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "TipoPago");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "InventarioStatus");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropTable(
                name: "Caja");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "VentaStatus");
        }
    }
}
