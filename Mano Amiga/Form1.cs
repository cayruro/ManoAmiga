using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;

namespace Mano_Amiga
{
    public partial class Form1 : Form
    {
        private Mano_AmigaEntities1 db;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            db = new Mano_AmigaEntities1();
            ObjectParameter Output = new ObjectParameter("salida", typeof(Int32));
            ObjectParameter identificar = new ObjectParameter("id_Usuario",typeof(Int32));
            db.sp_login(txtUser.Text, txtContra.Text, Output, identificar);
            if (Output.Value.Equals(1))
            {
                this.Hide();
                Form frm = new FormDonaciones(Convert.ToInt32(identificar.Value));
                frm.Show();
            }
            else if (Output.Value.Equals(2))
            {
                MessageBox.Show("Contraseña incorrecta");
            }
            else
            {
                MessageBox.Show("No existe este usuario");
            }
            
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new RegistroUsuario();
            frm.Show();
        }
    }
}
