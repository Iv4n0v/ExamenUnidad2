using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Windows.Forms;

namespace Ejercicicio03
{
    public partial class PedidoVista : Form
    {
        public PedidoVista()
        {
            InitializeComponent();
        }

        ProductoAcceso productoAcceso = new ProductoAcceso();
        string operacion = string.Empty;
        PedidoAcceso pedidoAcceso = new PedidoAcceso();
        Producto producto;
        
        private void NuevoButton_Click_1(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            IdPedidoTextBox.Enabled = true;                  
            CantidadTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            CodigoProductoTextBox.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
        }

        private void DesabilitarControles()
        {
            IdPedidoTextBox.Enabled = false;                      
            CantidadTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            CodigoProductoTextBox.Enabled = false;

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            IdPedidoTextBox.Clear();
            DescripcionTextBox.Clear();
            TotalTextBox.Clear();
            CantidadTextBox.Clear();
            NombreTextBox.Clear();
            CodigoProductoTextBox.Clear();
            PrecioTextBox.Clear();
        }
        private void PedidoVista_Load(object sender, EventArgs e)
        {
            ListarPedidos();
        }

        private void ListarPedidos()
        {
            PedidoGridView1.DataSource = pedidoAcceso.ListarPedidos();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(IdPedidoTextBox.Text))
                {
                    errorProvider1.SetError(IdPedidoTextBox, "Ingrese el Id del Pedido");
                    IdPedidoTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionTextBox, "Ingrese la descripcion");
                    DescripcionTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(TotalTextBox.Text))
                {
                    errorProvider1.SetError(TotalTextBox, "Ingrese el total");
                    TotalTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(CantidadTextBox.Text))
                {
                    errorProvider1.SetError(CantidadTextBox, "Ingrese la cantidad");
                    CantidadTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese el Nombre del Cliente");
                    NombreTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(CodigoProductoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoProductoTextBox, "Ingrese el codigo del producto");
                    CodigoProductoTextBox.Focus();
                    return;
                }

                Pedido pedido = new Pedido();
                pedido.Cliente = NombreTextBox.Text;
                pedido.Total = Convert.ToDecimal(TotalTextBox.Text);
                pedido.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
                pedido.IdProducto = CodigoProductoTextBox.Text;
                pedido.Codigo = Convert.ToInt32(IdPedidoTextBox.Text);

                if (operacion == "Nuevo")
                {
                    bool inserto = pedidoAcceso.InsertarPedidos(pedido);

                    if (inserto)
                    {
                        DesabilitarControles();
                        LimpiarControles();
                        ListarPedidos();
                        MessageBox.Show("Pedido insertado");
                    }
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void CodigoProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new Producto();
                producto = productoAcceso.GetProductoPorCodigo(CodigoProductoTextBox.Text);
                DescripcionTextBox.Text = producto.Descripcion;
                PrecioTextBox.Text = Convert.ToString(producto.Precio);
                TotalTextBox.Text = Convert.ToString(Convert.ToDecimal(PrecioTextBox.Text) * Convert.ToDecimal(CantidadTextBox.Text)); ;
            }
            else
            {
                //producto = null;
                //DescripcionTextBox.Clear();
                //CantidadTextBox.Clear();
                //PrecioTextBox.Clear();
            }
        }
    }
}
