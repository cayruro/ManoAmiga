using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mano_Amiga
{
    public partial class RegistroUsuario : Form
    {
        private Mano_AmigaEntities1 db;
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            db = new Mano_AmigaEntities1();
            db.sp_insertarUsuario(txtUser.Text, txtPassword.Text, txtName.Text, txtSurname.Text, txtLocalidad.Text, txtDNI.Text, Convert.ToInt32(txtPhone.Text), txtCorreo.Text);
            MessageBox.Show("El usuario se ha creado correctamente");
            this.Hide();
            Form frm = new Form1();
            frm.Show();
        }

       
    }
}
