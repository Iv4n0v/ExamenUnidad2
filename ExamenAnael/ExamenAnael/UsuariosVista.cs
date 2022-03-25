using Datos.Accesos;
using System;
using System.Windows.Forms;

namespace Ejercicicio03
{
    public partial class UsuariosVista : Form
    {
        public UsuariosVista()
        {
            InitializeComponent();
        }

        UsuarioAcceso usuarioAcceso = new UsuarioAcceso();

        private void UsuariosVista_Load(object sender, EventArgs e)
        {
            
          UsuariodataGridView.DataSource = usuarioAcceso.ListarUsuarios();
        }
    }
}
