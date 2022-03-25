using System;

namespace Ejercicicio03
{
    public partial class MenuVista : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuVista()
        {
            InitializeComponent();
        }
        UsuariosVista usuariosVista;
        ProductoVista productoVista;
        PedidoVista pedidoVista;
        private void ListarUsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            if (usuariosVista==null)
            {
                usuariosVista = new UsuariosVista();
                usuariosVista.MdiParent = this;
                usuariosVista.FormClosed += UsuariosVista_FormClosed;
                usuariosVista.Show();
            }
            else
            {
                usuariosVista.Activate();   
            }
            
        }

        private void UsuariosVista_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            usuariosVista=null;
        }

        private void ProductosToolStripButton1_Click(object sender, EventArgs e)
        {
            if (productoVista==null)
            {
                productoVista = new ProductoVista();
                productoVista.MdiParent = this;
                productoVista.FormClosed += ProductoVista_FormClosed;
                productoVista.Show();
            }
            else
            {
                productoVista.Activate();
            }

        }

        private void ProductoVista_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            productoVista = null;
        }

        private void MenuVista_Load(object sender, EventArgs e)
        {

        }

        private void PedidosStripButton1_Click(object sender, EventArgs e)
        {
            if (pedidoVista==null)
            {
                pedidoVista = new PedidoVista();
                pedidoVista.MdiParent = this;
                pedidoVista.FormClosed += PedidoVista_FormClosed;
                pedidoVista.Show();
            }
            else
            {
                pedidoVista.Activate();
            }
        }

        private void PedidoVista_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            pedidoVista = null;
        }
    }
}
