using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectods.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_completo_cliente = table.Column<string>(type: "text", nullable: false),
                    Cedula_cliente = table.Column<int>(type: "integer", nullable: false),
                    Tlf_proveedor = table.Column<int>(type: "integer", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    Id_conductor = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_completo_conductor = table.Column<string>(type: "text", nullable: false),
                    Tlf_conductor = table.Column<int>(type: "integer", nullable: false),
                    Fecha_nac_conductor = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cedula_conductor = table.Column<int>(type: "integer", nullable: false),
                    Fecha_expira_cedula = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    licencia_conductor = table.Column<int>(type: "integer", nullable: false),
                    tipoLicencia = table.Column<int>(type: "integer", nullable: false),
                    Fecha_expira_licencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Certificado_medico = table.Column<int>(type: "integer", nullable: false),
                    Fecha_expira_certificado_medico = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.Id_conductor);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id_departamento = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_departamento = table.Column<string>(type: "text", nullable: false),
                    Descrip_departamento = table.Column<string>(type: "text", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id_departamento);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id_estado = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_estado = table.Column<string>(type: "text", nullable: false),
                    Descrip_estado = table.Column<string>(type: "text", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id_estado);
                });

            migrationBuilder.CreateTable(
                name: "Lugares",
                columns: table => new
                {
                    Id_lugar = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_lugar = table.Column<string>(type: "text", nullable: false),
                    TipoLugar = table.Column<int>(type: "integer", nullable: false),
                    LugarPadreId = table.Column<Guid>(type: "uuid", nullable: true),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lugares", x => x.Id_lugar);
                    table.ForeignKey(
                        name: "FK_Lugares_Lugares_LugarPadreId",
                        column: x => x.LugarPadreId,
                        principalTable: "Lugares",
                        principalColumn: "Id_lugar");
                });

            migrationBuilder.CreateTable(
                name: "Polizas",
                columns: table => new
                {
                    Id_poliza = table.Column<Guid>(type: "uuid", nullable: false),
                    Num_poliza = table.Column<int>(type: "integer", nullable: false),
                    Nombre_poliza = table.Column<string>(type: "text", nullable: false),
                    Monto_cobertura_poliza = table.Column<int>(type: "integer", nullable: false),
                    Km_cobertura_poliza = table.Column<int>(type: "integer", nullable: false),
                    Monto_base_poliza = table.Column<int>(type: "integer", nullable: false),
                    Precio_km_poliza = table.Column<int>(type: "integer", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizas", x => x.Id_poliza);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id_proveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_proveedor = table.Column<string>(type: "text", nullable: false),
                    Denom_comercial_proveedor = table.Column<string>(type: "text", nullable: false),
                    Rif_proveedor = table.Column<int>(type: "integer", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id_proveedor);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id_rol = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_rol = table.Column<string>(type: "text", nullable: false),
                    Descrip_rol = table.Column<string>(type: "text", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id_rol);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id_servicio = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_servicio = table.Column<string>(type: "text", nullable: false),
                    Descrip_servicio = table.Column<string>(type: "text", nullable: false),
                    Costo_servicio = table.Column<int>(type: "integer", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id_servicio);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Vehiculos",
                columns: table => new
                {
                    Id_tipo_vehiculo = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_tipo_vehiculo = table.Column<string>(type: "text", nullable: false),
                    Descrip_tipo_vehiculo = table.Column<string>(type: "text", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Vehiculos", x => x.Id_tipo_vehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    Id_trabajador = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_completo_trabajador = table.Column<string>(type: "text", nullable: false),
                    Cedula_trabajador = table.Column<int>(type: "integer", nullable: false),
                    Tlf_trabajador = table.Column<int>(type: "integer", nullable: false),
                    Cargo_de_trabajo = table.Column<string>(type: "text", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.Id_trabajador);
                });

            migrationBuilder.CreateTable(
                name: "Poliza_Clientes",
                columns: table => new
                {
                    Id_poliza_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_poliza = table.Column<Guid>(type: "uuid", nullable: false),
                    Fecha_emision_poliza = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fecha_expira_poliza = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliza_Clientes", x => new { x.Id_poliza_cliente, x.Id_cliente, x.Id_poliza });
                    table.ForeignKey(
                        name: "FK_Poliza_Clientes_Clientes_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poliza_Clientes_Polizas_Id_poliza",
                        column: x => x.Id_poliza,
                        principalTable: "Polizas",
                        principalColumn: "Id_poliza",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id_vehiculo = table.Column<Guid>(type: "uuid", nullable: false),
                    Marca_vehiculo = table.Column<string>(type: "text", nullable: false),
                    Modelo_vehiculo = table.Column<string>(type: "text", nullable: false),
                    Color_vehiculo = table.Column<string>(type: "text", nullable: false),
                    Carnet_circulacion = table.Column<bool>(type: "boolean", nullable: false),
                    Id_tipo_vehiculo = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id_vehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Tipo_Vehiculos_Id_tipo_vehiculo",
                        column: x => x.Id_tipo_vehiculo,
                        principalTable: "Tipo_Vehiculos",
                        principalColumn: "Id_tipo_vehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Id_tlf = table.Column<Guid>(type: "uuid", nullable: false),
                    Num_tlf = table.Column<string>(type: "text", nullable: false),
                    Id_trabajador = table.Column<Guid>(type: "uuid", nullable: true),
                    Id_conductor = table.Column<Guid>(type: "uuid", nullable: true),
                    Id_cliente = table.Column<Guid>(type: "uuid", nullable: true),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Id_tlf);
                    table.ForeignKey(
                        name: "FK_Telefonos_Clientes_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_cliente");
                    table.ForeignKey(
                        name: "FK_Telefonos_Conductores_Id_conductor",
                        column: x => x.Id_conductor,
                        principalTable: "Conductores",
                        principalColumn: "Id_conductor");
                    table.ForeignKey(
                        name: "FK_Telefonos_Trabajadores_Id_trabajador",
                        column: x => x.Id_trabajador,
                        principalTable: "Trabajadores",
                        principalColumn: "Id_trabajador");
                });

            migrationBuilder.CreateTable(
                name: "Trabajador_Departamentos",
                columns: table => new
                {
                    Id_departamento = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_trabajador = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajador_Departamentos", x => new { x.Id_trabajador, x.Id_departamento });
                    table.ForeignKey(
                        name: "FK_Trabajador_Departamentos_Departamentos_Id_departamento",
                        column: x => x.Id_departamento,
                        principalTable: "Departamentos",
                        principalColumn: "Id_departamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajador_Departamentos_Trabajadores_Id_trabajador",
                        column: x => x.Id_trabajador,
                        principalTable: "Trabajadores",
                        principalColumn: "Id_trabajador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Correo_usuario = table.Column<string>(type: "text", nullable: false),
                    Contrasena_usuario = table.Column<int>(type: "integer", nullable: false),
                    Id_trabajador = table.Column<Guid>(type: "uuid", nullable: true),
                    Id_conductor = table.Column<Guid>(type: "uuid", nullable: true),
                    Id_proveedor = table.Column<Guid>(type: "uuid", nullable: true),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Conductores_Id_conductor",
                        column: x => x.Id_conductor,
                        principalTable: "Conductores",
                        principalColumn: "Id_conductor");
                    table.ForeignKey(
                        name: "FK_Usuarios_Proveedores_Id_proveedor",
                        column: x => x.Id_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_proveedor");
                    table.ForeignKey(
                        name: "FK_Usuarios_Trabajadores_Id_trabajador",
                        column: x => x.Id_trabajador,
                        principalTable: "Trabajadores",
                        principalColumn: "Id_trabajador");
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo_Proveedores",
                columns: table => new
                {
                    Id_vehiculo_proveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_proveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_vehiculo = table.Column<Guid>(type: "uuid", nullable: false),
                    Respon_civil = table.Column<bool>(type: "boolean", nullable: false),
                    Fecha_expira_respon_civil = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id_conductor = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo_Proveedores", x => new { x.Id_vehiculo_proveedor, x.Id_proveedor, x.Id_vehiculo });
                    table.ForeignKey(
                        name: "FK_Vehiculo_Proveedores_Conductores_Id_conductor",
                        column: x => x.Id_conductor,
                        principalTable: "Conductores",
                        principalColumn: "Id_conductor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Proveedores_Proveedores_Id_proveedor",
                        column: x => x.Id_proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_proveedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Proveedores_Vehiculos_Id_vehiculo",
                        column: x => x.Id_vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id_vehiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Roles",
                columns: table => new
                {
                    Id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_rol = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Roles", x => new { x.Id_usuario, x.Id_rol });
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_Roles_Id_rol",
                        column: x => x.Id_rol,
                        principalTable: "Roles",
                        principalColumn: "Id_rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_Usuarios_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden_De_Servicios",
                columns: table => new
                {
                    Id_orden_de_servicio = table.Column<Guid>(type: "uuid", nullable: false),
                    Descrip_incidente = table.Column<string>(type: "text", nullable: false),
                    Ubi_inicial_conductor = table.Column<string>(type: "text", nullable: false),
                    Ubi_incidente = table.Column<string>(type: "text", nullable: false),
                    Ubi_fin_incidente = table.Column<string>(type: "text", nullable: false),
                    Distancia_incidente = table.Column<string>(type: "text", nullable: false),
                    Descrip_vehiculo_cliente = table.Column<string>(type: "text", nullable: false),
                    Costo_incidente = table.Column<int>(type: "integer", nullable: false),
                    Id_poliza_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_poliza = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_trabajador = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_lugar = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_vehiculo_proveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_vehiculo = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_proveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden_De_Servicios", x => x.Id_orden_de_servicio);
                    table.ForeignKey(
                        name: "FK_Orden_De_Servicios_Lugares_Id_lugar",
                        column: x => x.Id_lugar,
                        principalTable: "Lugares",
                        principalColumn: "Id_lugar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_De_Servicios_Poliza_Clientes_Id_poliza_cliente_Id_pol~",
                        columns: x => new { x.Id_poliza_cliente, x.Id_poliza, x.Id_cliente },
                        principalTable: "Poliza_Clientes",
                        principalColumns: new[] { "Id_poliza_cliente", "Id_cliente", "Id_poliza" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_De_Servicios_Trabajadores_Id_trabajador",
                        column: x => x.Id_trabajador,
                        principalTable: "Trabajadores",
                        principalColumn: "Id_trabajador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_De_Servicios_Vehiculo_Proveedores_Id_vehiculo_proveed~",
                        columns: x => new { x.Id_vehiculo_proveedor, x.Id_vehiculo, x.Id_proveedor },
                        principalTable: "Vehiculo_Proveedores",
                        principalColumns: new[] { "Id_vehiculo_proveedor", "Id_proveedor", "Id_vehiculo" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estado_Ordenes",
                columns: table => new
                {
                    Id_estado_incidente = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_orden_de_servicio = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_estado = table.Column<Guid>(type: "uuid", nullable: false),
                    Fecha_inicio_incidente = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fecha_fin_incidente = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_Ordenes", x => new { x.Id_estado_incidente, x.Id_orden_de_servicio, x.Id_estado });
                    table.ForeignKey(
                        name: "FK_Estado_Ordenes_Estados_Id_estado",
                        column: x => x.Id_estado,
                        principalTable: "Estados",
                        principalColumn: "Id_estado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estado_Ordenes_Orden_De_Servicios_Id_orden_de_servicio",
                        column: x => x.Id_orden_de_servicio,
                        principalTable: "Orden_De_Servicios",
                        principalColumn: "Id_orden_de_servicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicio_Ordenes",
                columns: table => new
                {
                    Id_servicio_orden = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_servicio = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_orden_de_servicio = table.Column<Guid>(type: "uuid", nullable: false),
                    Id_base = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy_base = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt_base = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy_base = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio_Ordenes", x => new { x.Id_servicio_orden, x.Id_servicio, x.Id_orden_de_servicio });
                    table.ForeignKey(
                        name: "FK_Servicio_Ordenes_Orden_De_Servicios_Id_orden_de_servicio",
                        column: x => x.Id_orden_de_servicio,
                        principalTable: "Orden_De_Servicios",
                        principalColumn: "Id_orden_de_servicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicio_Ordenes_Servicios_Id_servicio",
                        column: x => x.Id_servicio,
                        principalTable: "Servicios",
                        principalColumn: "Id_servicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estado_Ordenes_Id_estado",
                table: "Estado_Ordenes",
                column: "Id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_Ordenes_Id_orden_de_servicio",
                table: "Estado_Ordenes",
                column: "Id_orden_de_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_Lugares_LugarPadreId",
                table: "Lugares",
                column: "LugarPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_De_Servicios_Id_lugar",
                table: "Orden_De_Servicios",
                column: "Id_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_De_Servicios_Id_poliza_cliente_Id_poliza_Id_cliente",
                table: "Orden_De_Servicios",
                columns: new[] { "Id_poliza_cliente", "Id_poliza", "Id_cliente" });

            migrationBuilder.CreateIndex(
                name: "IX_Orden_De_Servicios_Id_trabajador",
                table: "Orden_De_Servicios",
                column: "Id_trabajador");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_De_Servicios_Id_vehiculo_proveedor_Id_vehiculo_Id_pro~",
                table: "Orden_De_Servicios",
                columns: new[] { "Id_vehiculo_proveedor", "Id_vehiculo", "Id_proveedor" });

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_Clientes_Id_cliente",
                table: "Poliza_Clientes",
                column: "Id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Poliza_Clientes_Id_poliza",
                table: "Poliza_Clientes",
                column: "Id_poliza");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_Ordenes_Id_orden_de_servicio",
                table: "Servicio_Ordenes",
                column: "Id_orden_de_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_Ordenes_Id_servicio",
                table: "Servicio_Ordenes",
                column: "Id_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_Id_cliente",
                table: "Telefonos",
                column: "Id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_Id_conductor",
                table: "Telefonos",
                column: "Id_conductor");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_Id_trabajador",
                table: "Telefonos",
                column: "Id_trabajador");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajador_Departamentos_Id_departamento",
                table: "Trabajador_Departamentos",
                column: "Id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Roles_Id_rol",
                table: "Usuario_Roles",
                column: "Id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_conductor",
                table: "Usuarios",
                column: "Id_conductor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_proveedor",
                table: "Usuarios",
                column: "Id_proveedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_trabajador",
                table: "Usuarios",
                column: "Id_trabajador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Proveedores_Id_conductor",
                table: "Vehiculo_Proveedores",
                column: "Id_conductor");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Proveedores_Id_proveedor",
                table: "Vehiculo_Proveedores",
                column: "Id_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Proveedores_Id_vehiculo",
                table: "Vehiculo_Proveedores",
                column: "Id_vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Id_tipo_vehiculo",
                table: "Vehiculos",
                column: "Id_tipo_vehiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estado_Ordenes");

            migrationBuilder.DropTable(
                name: "Servicio_Ordenes");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Trabajador_Departamentos");

            migrationBuilder.DropTable(
                name: "Usuario_Roles");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Orden_De_Servicios");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Lugares");

            migrationBuilder.DropTable(
                name: "Poliza_Clientes");

            migrationBuilder.DropTable(
                name: "Vehiculo_Proveedores");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Polizas");

            migrationBuilder.DropTable(
                name: "Conductores");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Tipo_Vehiculos");
        }
    }
}
