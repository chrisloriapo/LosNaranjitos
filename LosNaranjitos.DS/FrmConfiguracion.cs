using LosNaranjitos.DATOS;
using Microsoft.Win32;
using ServiceStack.ServiceInterface.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LosNaranjitos.DS
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utilitarios.emailValido(txtEmail.Text))
            {
                lblValidEmail.Text = "Email Válido";
                lblValidEmail.ForeColor = Color.Green;
            }
            else
            {
                lblValidEmail.Text = "Email NO Válido";
                lblValidEmail.ForeColor = Color.Red;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbMain.SelectedIndex = 2;
        }

        private void rbSqlServer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSqlServer.Checked)
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
            else
            {
                txtPassword.Clear();
                txtUsername.Clear();
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                var baseKey = RegistryKey.OpenBaseKey(
                           RegistryHive.LocalMachine, RegistryView.Registry64);
                var key = baseKey.OpenSubKey(
                @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");
                foreach (string sqlserver in key.GetValueNames())
                {
                    cmbInstancias.Items.Add(Environment.MachineName + "\\" + sqlserver);
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Error al Listar las Instancias \n Ingreselas Manualmente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbbImpresora.Items.Add(printer);
            }
            cbbImpresora.SelectedIndex = 0;



        }

        public bool CreateCompanyDatabase()
        {
            String DatabaseCreation, StructureCreation;
            SqlConnection myConn;
            if (rbSqlServer.Checked)
            {
                myConn = new SqlConnection("Server=" + cmbInstancias.Text + ";database=master;uid=" + txtUsername.Text + ";pwd=" + txtPassword.Text + ";");
            }
            else
            {
                myConn = new SqlConnection("Server=" + cmbInstancias.Text + ";database=master;Integrated Security=True;");
            }
            DatabaseCreation = "USE MASTER CREATE DATABASE [OrangeDB1]";
            StructureCreation = @"USE OrangeDB1

/****** Object:  Table [dbo].[Bitacora]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Bitacora](
	[IdBitacora] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Accion] [varchar](1000) NOT NULL,
	[Usuario] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Caja]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Caja](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[OperadorActual] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[UltimaModificacion] [datetime] NOT NULL,
	[Disponible] [bit] NOT NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Cargas]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Cargas](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[Porcentaje] [decimal](18, 0) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Cargas] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[CategoriaProductos]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[CategoriaProductos](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_CategoriaProductos] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Cierre]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Cierre](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Caja] [varchar](50) NOT NULL,
	[CantidadVentas] [int] NOT NULL,
	[MontoTarjeta] [decimal](18, 0) NOT NULL,
	[MontoEfectivo] [decimal](18, 0) NOT NULL,
	[MontroOtro] [decimal](18, 0) NOT NULL,
	[MontoCambio] [decimal](18, 0) NOT NULL,
	[MontoTotal] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Cierre] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Cliente]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Cliente](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[IdPersonal] [varchar](100) NOT NULL,
	[Contrasena] [varchar](100) NULL,
	[Correo] [varchar](500) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido1] [varchar](100) NOT NULL,
	[Apellido2] [varchar](100) NULL,
	[Telefono] [varchar](100) NULL,
	[Direccion] [varchar](1000) NULL,
	[UltimaVisita] [datetime] NULL,
	[Puntaje] [decimal](18, 0) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Combo]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Combo](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[Precio] [decimal](18, 0) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Combo_1] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[ComboProducto]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[ComboProducto](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[CodCombo] [varchar](100) NOT NULL,
	[CodProducto] [varchar](200) NOT NULL,
	[IdMedida] [varchar](50) NOT NULL,
	[CantidadProducto] [float] NOT NULL,
 CONSTRAINT [PK_ComboProducto] PRIMARY KEY CLUSTERED 
(
	[CodCombo] ASC,
	[CodProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Consecutivo]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Consecutivo](
	[Prefijo] [varchar](50) NOT NULL,
	[Tipo] [varchar](1000) NOT NULL,
	[ConsecutivoActual] [int] NOT NULL,
 CONSTRAINT [PK_Consecutivo] PRIMARY KEY CLUSTERED 
(
	[Prefijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[DetallePedido]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[DetallePedido](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[IdOrden] [int] NOT NULL,
	[Producto] [varchar](200) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[ObservacionesDT] [varchar](5000) NULL,
	[SubTotal] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_DetallePedido_1] PRIMARY KEY CLUSTERED 
(
	[IdOrden] ASC,
	[Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Error]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Error](
	[IdError] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](1000) NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[Hora] [datetime] NULL,
 CONSTRAINT [PK_Error] PRIMARY KEY CLUSTERED 
(
	[IdError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[FacturaCompra]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[FacturaCompra](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [varchar](500) NOT NULL,
	[IdProveedor] [varchar](150) NOT NULL,
	[Monto] [decimal](18, 0) NOT NULL,
	[Observaciones] [varchar](5000) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Operador] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FacturaCompra_1] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Insumos]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Insumos](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[IdInsumo] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[IdMedida] [varchar](50) NOT NULL,
	[PrecioCompra] [decimal](18, 0) NOT NULL,
	[RendimientoUM] [float] NULL,
	[RendimientoPorcion] [float] NOT NULL,
	[PrecioMermado] [decimal](18, 0) NOT NULL,
	[CantInventario] [float] NOT NULL,
	[Proveedor] [varchar](150) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Insumos] PRIMARY KEY CLUSTERED 
(
	[IdInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Medida]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Medida](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[IdMedida] [varchar](50) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Medida] PRIMARY KEY CLUSTERED 
(
	[IdMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Parametros]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Parametros](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Valor] [varchar](500) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Operador] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Pedido]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Pedido](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [varchar](100) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Observaciones] [varchar](5000) NULL,
	[Operador] [varchar](100) NOT NULL,
	[MontoTarjeta] [decimal](18, 0) NOT NULL,
	[MontoEfectivo] [decimal](18, 0) NOT NULL,
	[MontoOtro] [decimal](18, 0) NOT NULL,
	[MontoCambio] [decimal](18, 0) NOT NULL,
	[Subtotal] [decimal](18, 0) NOT NULL,
	[Cancelado] [bit] NOT NULL,
	[CompletoCocina] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[CierreOperador] [bit] NOT NULL,
	[Cerrado] [bit] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Producto]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Producto](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](200) NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Descripcion] [varchar](5000) NOT NULL,
	[Categoria] [int] NOT NULL,
	[Precio] [decimal](18, 0) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Producto_1] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[ProductoInsumo]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[ProductoInsumo](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [varchar](200) NOT NULL,
	[IdInsumo] [varchar](100) NOT NULL,
	[CantidadRequerida] [float] NOT NULL,
 CONSTRAINT [PK_ProductoInsumo] PRIMARY KEY CLUSTERED 
(
	[CodigoProducto] ASC,
	[IdInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Proveedor]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Proveedor](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[IdProveedor] [varchar](150) NOT NULL,
	[NombreProveedor] [varchar](100) NOT NULL,
	[Telefono] [varchar](70) NOT NULL,
	[Correo] [varchar](200) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[RolUsuario]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[RolUsuario](
	[IdRol] [int] NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_RolUsuario] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  Table [dbo].[Usuario]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Usuario](
	[Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Contrasena] [varchar](100) NOT NULL,
	[Rol] [int] NOT NULL,
	[IdPersonal] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido1] [varchar](100) NOT NULL,
	[Apellido2] [varchar](100) NULL,
	[Direccion] [varchar](500) NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
	[CambioContrasena] [bit] NOT NULL,
	[UltimoContrasena] [datetime] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

/****** Object:  View [dbo].[VProveedor_Insumo]    Script Date: 6/7/2017 18:10:44 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON




ALTER TABLE [dbo].[Cierre]  WITH CHECK ADD  CONSTRAINT [FK_Cierre_Usuario] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuario] ([Username])

ALTER TABLE [dbo].[Cierre] CHECK CONSTRAINT [FK_Cierre_Usuario]

ALTER TABLE [dbo].[ComboProducto]  WITH CHECK ADD  CONSTRAINT [FK_ComboProducto_Combo] FOREIGN KEY([CodCombo])
REFERENCES [dbo].[Combo] ([Codigo])

ALTER TABLE [dbo].[ComboProducto] CHECK CONSTRAINT [FK_ComboProducto_Combo]

ALTER TABLE [dbo].[ComboProducto]  WITH CHECK ADD  CONSTRAINT [FK_ComboProducto_Medida] FOREIGN KEY([IdMedida])
REFERENCES [dbo].[Medida] ([IdMedida])

ALTER TABLE [dbo].[ComboProducto] CHECK CONSTRAINT [FK_ComboProducto_Medida]

ALTER TABLE [dbo].[ComboProducto]  WITH CHECK ADD  CONSTRAINT [FK_ComboProducto_Producto] FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Producto] ([Codigo])

ALTER TABLE [dbo].[ComboProducto] CHECK CONSTRAINT [FK_ComboProducto_Producto]

ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([IdOrden])
REFERENCES [dbo].[Pedido] ([Consecutivo])

ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]

ALTER TABLE [dbo].[FacturaCompra]  WITH CHECK ADD  CONSTRAINT [FK_FacturaCompra_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])

ALTER TABLE [dbo].[FacturaCompra] CHECK CONSTRAINT [FK_FacturaCompra_Proveedor]

ALTER TABLE [dbo].[FacturaCompra]  WITH CHECK ADD  CONSTRAINT [FK_FacturaCompra_Usuario] FOREIGN KEY([Operador])
REFERENCES [dbo].[Usuario] ([Username])

ALTER TABLE [dbo].[FacturaCompra] CHECK CONSTRAINT [FK_FacturaCompra_Usuario]

ALTER TABLE [dbo].[Insumos]  WITH CHECK ADD  CONSTRAINT [FK_Insumos_Medida] FOREIGN KEY([IdMedida])
REFERENCES [dbo].[Medida] ([IdMedida])

ALTER TABLE [dbo].[Insumos] CHECK CONSTRAINT [FK_Insumos_Medida]

ALTER TABLE [dbo].[Insumos]  WITH CHECK ADD  CONSTRAINT [FK_Insumos_Proveedor] FOREIGN KEY([Proveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])

ALTER TABLE [dbo].[Insumos] CHECK CONSTRAINT [FK_Insumos_Proveedor]

ALTER TABLE [dbo].[Parametros]  WITH CHECK ADD  CONSTRAINT [FK_Parametros_Parametros] FOREIGN KEY([Operador])
REFERENCES [dbo].[Usuario] ([Username])

ALTER TABLE [dbo].[Parametros] CHECK CONSTRAINT [FK_Parametros_Parametros]

ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdPersonal])

ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]

ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Usuario] FOREIGN KEY([Operador])
REFERENCES [dbo].[Usuario] ([Username])

ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Usuario]

ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_CategoriaProductos] FOREIGN KEY([Categoria])
REFERENCES [dbo].[CategoriaProductos] ([IdTipo])

ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_CategoriaProductos]

ALTER TABLE [dbo].[ProductoInsumo]  WITH CHECK ADD  CONSTRAINT [FK_ProductoInsumo_Insumos] FOREIGN KEY([IdInsumo])
REFERENCES [dbo].[Insumos] ([IdInsumo])

ALTER TABLE [dbo].[ProductoInsumo] CHECK CONSTRAINT [FK_ProductoInsumo_Insumos]

ALTER TABLE [dbo].[ProductoInsumo]  WITH CHECK ADD  CONSTRAINT [FK_ProductoInsumo_Producto] FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[Producto] ([Codigo])

ALTER TABLE [dbo].[ProductoInsumo] CHECK CONSTRAINT [FK_ProductoInsumo_Producto]

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_RolUsuario] FOREIGN KEY([Rol])
REFERENCES [dbo].[RolUsuario] ([IdRol])

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_RolUsuario]";
            SqlCommand ComandDatabase = new SqlCommand(DatabaseCreation, myConn);

            SqlCommand ComandTables = new SqlCommand(StructureCreation, myConn);
            try
            {
                myConn.Open();
                ComandDatabase.ExecuteNonQuery();
                ComandTables.ExecuteNonQuery();

                Utilitarios.OpCargas.AgregarCargas(new Cargas { Activo = true, Descripcion = "Impuesto de Venta", Porcentaje = 13 });
                Utilitarios.OpCargas.AgregarCargas(new Cargas { Activo = true, Descripcion = "Recurso Humano", Porcentaje = 50 });

                Utilitarios.OpMedidas.AgregarMedida(new Medida { Descripcion = "Unidad", IdMedida = "u" });

                List<CategoriaProductos> CategoriasDefault = new List<CategoriaProductos>();
                CategoriasDefault.Add(new CategoriaProductos { Activo = true, Descripcion = "Producto Principal" });
                CategoriasDefault.Add(new CategoriaProductos { Activo = true, Descripcion = "Acompañamiento" });
                CategoriasDefault.Add(new CategoriaProductos { Activo = true, Descripcion = "Bebidas" });
                CategoriasDefault.Add(new CategoriaProductos { Activo = true, Descripcion = "Adicional" });

                foreach (var Categoria in CategoriasDefault)
                {
                    Utilitarios.OpCategorias.AgregarCategoriaProductos(Categoria);

                }

                List<DATOS.RolUsuario> Roles = new List<DATOS.RolUsuario>();
                Roles.Add(new DATOS.RolUsuario { IdRol = 1, Activo = true, Descripcion = "SuperUsuario" });
                Roles.Add(new DATOS.RolUsuario { IdRol = 2, Activo = true, Descripcion = "Administrador" });
                Roles.Add(new DATOS.RolUsuario { IdRol = 3, Activo = true, Descripcion = "Cajero" });

                foreach (var rol in Roles)
                {
                    Utilitarios.OpRol.AgregarRolUsuario(rol);
                }
                AgregarUsuario();

                List<DATOS.Parametros> ParametrosIniciales = new List<DATOS.Parametros>();
               
                //Parametro de Impresora
                if (!chkLuegoPrinter.Checked)
                {
                    ParametrosIniciales.Add(new DATOS.Parametros
                    {
                        Nombre = "Impresora de Ticketes",
                        Fecha = DateTime.Now,
                        Operador = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Username,
                        Valor = cbbImpresora.SelectedItem.ToString()
                    });
                }
                else
                {
                    ParametrosIniciales.Add(new DATOS.Parametros
                    {
                        Nombre = "Impresora de Ticketes",
                        Fecha = DateTime.Now,
                        Operador = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Username,
                        Valor = ""
                    });

                }
                //Email
                ParametrosIniciales.Add(new DATOS.Parametros { Nombre = "Smtp", Fecha = DateTime.Now, Operador = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Username, Valor = txtSmtp.Text });
                ParametrosIniciales.Add(new DATOS.Parametros { Nombre = "PuertoCorreo", Fecha = DateTime.Now, Operador = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Username, Valor = txtPortNumber.Text });
                ParametrosIniciales.Add(new DATOS.Parametros { Nombre = "MailDeliverer", Fecha = DateTime.Now, Operador = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Username, Valor = txtMailDeliverer.Text });
                ParametrosIniciales.Add(new DATOS.Parametros { Nombre = "PasswordMailDeliverer", Fecha = DateTime.Now, Operador = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Username, Valor = Utilitarios.Encriptar(txtContrasenaConfirmada.Text, Utilitarios.Llave) });
                //Parametro de Monitor
                ParametrosIniciales.Add(new DATOS.Parametros { Nombre = "BanderaMonitor", Fecha = DateTime.Now, Operador = Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Username, Valor = "0" });

                Cliente ClienteGeneneral = new Cliente
                {
                    Activo = true,
                    Apellido1 = "General",
                    Apellido2 = "",
                    Contrasena = Utilitarios.Encriptar("123", Utilitarios.Llave),
                    Correo = "nomail.com",
                    Direccion = "No Registrado",
                    IdPersonal = "0",
                    Nombre = "Cliente",
                    Puntaje = 0,
                    Telefono = "0",
                    UltimaVisita = DateTime.Now

                };
                Utilitarios.OpClientes.AgregarCliente(ClienteGeneneral);

                foreach (var parameter in ParametrosIniciales)
                {
                    Utilitarios.OpParametros.AgregarParametro(parameter);
                }
                if (!chkLuegoPrinter.Checked)
                {
                    DATOS.Pedido OrdenPrueba = new DATOS.Pedido { Activo = true, Cancelado = true, Cerrado = true, CierreOperador = true, Consecutivo = 1, Fecha = DateTime.Now, IdCliente = "Cliente Prueba", MontoCambio = 500, MontoEfectivo = 1000, MontoOtro = 1000, MontoTarjeta = 1000, Observaciones = "Observaciones", Operador = txtNombre.Text + " " + txtApellido.Text, Subtotal = 10000 };
                    List<DATOS.DetallePedido> DetallePrueba = new List<DATOS.DetallePedido>();
                    DATOS.DetallePedido Prueba = new DATOS.DetallePedido { Consecutivo = 1, Cantidad = 6, IdOrden = OrdenPrueba.Consecutivo, ObservacionesDT = "", Producto = "Producto Prueba 1", SubTotal = 5000 };
                    DATOS.DetallePedido Prueba2 = new DATOS.DetallePedido { Consecutivo = 2, Cantidad = 5, IdOrden = OrdenPrueba.Consecutivo, ObservacionesDT = "", Producto = "Producto Prueba 2", SubTotal = 4500 };
                    DetallePrueba.Add(Prueba);
                    DetallePrueba.Add(Prueba2);

                    Utilitarios.TicketeGeneral("1", "Prueba", "Cliente Prueba", DetallePrueba, OrdenPrueba);

                }
                try
                {
                    List<string> Destinatario = new List<string>();
                    Destinatario.Add(Utilitarios.Decriptar(Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Correo, Utilitarios.Llave));
                    Utilitarios.EnviarEmail(Destinatario, "***CONFIDENCIAL**** - Credenciales de Acceso - Soda Los Naranjitos", "Su nombre de usuario es: " + Utilitarios.Decriptar(Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Username, Utilitarios.Llave) + " \n Su Contraseña de acceso es: " + Utilitarios.Decriptar(Utilitarios.OpUsuarios.ListarUsuarios().FirstOrDefault().Contrasena, Utilitarios.Llave));

                    MessageBox.Show("Se ha enviado la contraseña al correo correspondiente al usuario ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    Utilitarios.GeneralError(ex.Message, "Error al Enviar Correo", "", "Error en Modulo de Usuarios al Intentar Agregar un usuario nuevo");
                    MessageBox.Show("Error al enviar Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                MessageBox.Show("Base de datos y Parametros Creados Correctamente ", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
                Application.Restart();
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbInstancias.Text) || string.IsNullOrWhiteSpace(cmbInstancias.Text))
            {
                MessageBox.Show("Debes Ingresar una instancia de Base de datos", "Espacios en blanco ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string myConn;
            if (rbSqlServer.Checked)
            {
                myConn = "Server=" + cmbInstancias.Text + ";Initial Catalog=OrangeDB1;uid=" + txtUsername.Text + ";pwd=" + txtPassword.Text + ";";
            }
            else
            {
                myConn = "Server=" + cmbInstancias.Text + ";Initial Catalog=OrangeDB1;Integrated Security=True;";
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Properties.Settings.Default["conexion"] = myConn;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            //Application.Restart();
            //try
            //{
            //    DS._Conexion.CrearConexion().OpenDbConnection();
            //    MessageBox.Show("Conexión Correcta", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //catch (SqlException)
            //{
            //    MessageBox.Show("Error al Ingresar a la instancia de Base de datos", "Trata de Nuevo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            tbMain.SelectedIndex = 1;
            //  tbMain.TabPages.Remove(tbConexión);
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkLuegoPrinter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLuegoPrinter.Checked)
            {
                cbbImpresora.Enabled = false;
            }
            else
            {
                cbbImpresora.Enabled = true;
            }
        }

        public void AgregarUsuario()
        {

            if (string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
              string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrEmpty(txtApellido2.Text) || string.IsNullOrWhiteSpace(txtApellido2.Text) ||
              string.IsNullOrEmpty(txtIdPersonal.Text) || string.IsNullOrWhiteSpace(txtIdPersonal.Text) ||
              string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Faltan datos por ingresar o se encuentran en blanco",
                    "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    if (!Utilitarios.emailValido(txtEmail.Text))
                    {
                        MessageBox.Show("Email No Valido",
                            "Error al ingresar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    Usuario Userprivate = new Usuario
                    {
                        Username = Utilitarios.Encriptar(GetUsername(), Utilitarios.Llave),
                        Nombre = Utilitarios.Encriptar(txtNombre.Text, Utilitarios.Llave),
                        Apellido1 = Utilitarios.Encriptar(txtApellido.Text, Utilitarios.Llave),
                        Apellido2 = Utilitarios.Encriptar(txtApellido2.Text, Utilitarios.Llave),
                        Contrasena = Utilitarios.Encriptar(RandomString(6), Utilitarios.Llave),
                        Activo = true,
                        IdPersonal = Utilitarios.Encriptar(txtIdPersonal.Text, Utilitarios.Llave),
                        Telefono = Utilitarios.Encriptar(txtTelefono.Text, Utilitarios.Llave),
                        Correo = Utilitarios.Encriptar(txtEmail.Text, Utilitarios.Llave),
                        Rol = 1,
                        Direccion = txtDireccion.Text,
                        CambioContrasena = true,
                        UltimoContrasena = DateTime.Now

                    };

                    Utilitarios.OpUsuarios.AgregarUsuario(Userprivate);



                    Utilitarios.GeneralBitacora(Utilitarios.Decriptar(Userprivate.Username, Utilitarios.Llave), "Ingreso de Usuario Nuevo " + Utilitarios.Decriptar(Userprivate.Username, Utilitarios.Llave));
                    MessageBox.Show("Los datos del Usuario se ingresaron correctamente",
"Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    Utilitarios.GeneralError(ex.Message, "Error No Reconocido", "", "Error en Modulo de Usuarios al Intentar Agregar un usuario nuevo");
                    MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private string GetUsername()
        {
            try
            {
                string Usuario; int Consec = 0;

                Usuario = txtApellido.Text.Replace(" ", "") + txtNombre.Text.Substring(0, 1) + Consec.ToString();
                Usuario = Usuario.ToLower();
                do
                {
                    Consec = Consec + 1; //Consecutivo para IdUsuario
                    Usuario = txtApellido.Text + txtNombre.Text.Substring(0, 1) + Consec.ToString();
                    Usuario = Usuario.ToLower();
                } while (Utilitarios.OpUsuarios.ExisteUsuario(Utilitarios.Encriptar(Usuario, Utilitarios.Llave)));

                return Usuario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        private void txtContrasenaConfirmada_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtContrasena.Text == txtContrasenaConfirmada.Text)
            {
                lblContrasenas.Text = "Contraseñas Coinciden";
                lblContrasenas.ForeColor = Color.Green;
            }
            else
            {
                lblContrasenas.Text = "Contraseñas No Coinciden";
                lblContrasenas.ForeColor = Color.Red;
            }
        }



        private void txtMailDeliverer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utilitarios.emailValido(txtEmail.Text))
            {
                lblValidMailDeliverer.Text = "Email Válido";
                lblValidMailDeliverer.ForeColor = Color.Green;
            }
            else
            {
                lblValidMailDeliverer.Text = "Email NO Válido";
                lblValidMailDeliverer.ForeColor = Color.Red;
            }

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSmtp.Text) || string.IsNullOrWhiteSpace(txtSmtp.Text))
                {
                    MessageBox.Show("Debes Ingresar el parametro de SMTP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSmtp.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPortNumber.Text) || string.IsNullOrWhiteSpace(txtPortNumber.Text))
                {
                    MessageBox.Show("Debes Ingresar el parametro de Número de puerto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPortNumber.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtMailDeliverer.Text) || string.IsNullOrWhiteSpace(txtMailDeliverer.Text))
                {
                    MessageBox.Show("Debes Ingresar el correo a utilizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMailDeliverer.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtContrasenaConfirmada.Text) || string.IsNullOrWhiteSpace(txtContrasenaConfirmada.Text))
                {
                    MessageBox.Show("Debes Ingresar el parametro de SMTP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasenaConfirmada.Focus();
                    return;
                }
                if (txtContrasenaConfirmada.Text != txtContrasena.Text)
                {
                    MessageBox.Show("Las Contraseñas No Coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasenaConfirmada.Focus();
                    return;
                }
                if (!Utilitarios.emailValido(txtMailDeliverer.Text))
                {
                    MessageBox.Show("Correo No Válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasenaConfirmada.Focus();
                    return;
                }

                CreateCompanyDatabase();
            }
            catch (Exception ex)
            {

                Utilitarios.GeneralError(ex.Message, "Error No Reconocido", "", "Error en Modulo de Usuarios al Intentar Agregar un usuario nuevo");
                MessageBox.Show("Error en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
    }
}