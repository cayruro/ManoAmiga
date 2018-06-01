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
    public partial class HacerDonacion : Form
    {
        private Mano_AmigaEntities1 db;
        private int identificador;

        public HacerDonacion(int identificador)
        {
            InitializeComponent();
            this.identificador = identificador;
            loadComboCategoria();
            
        }

        private void btnRegistrarArticulo_Click(object sender, EventArgs e)
        {
            db = new Mano_AmigaEntities1();
            Articulo a = new Articulo();
            db.sp_insertarArticulo( 
                Convert.ToInt32(comboBoxCategoria.SelectedValue),identificador, txtFoto.Text, richBoxDescripcion.Text,dateTimePicker1.Value, txtNombre.Text);
            MessageBox.Show("El articulo se ha creado correctamente");

            this.Hide();
        }

        private void loadComboCategoria()
        {
            db = new Mano_AmigaEntities1();
            var query = from d in db.Categoria orderby d.id_Categoria select d;
            try
            {
                List<Categoria> categoria = query.ToList();
                this.comboBoxCategoria.DataSource = categoria;
                this.comboBoxCategoria.DisplayMember = "Tipo";
                this.comboBoxCategoria.ValueMember = "id_Categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HacerDonacion_Load(object sender, EventArgs e)
        {

        }
    }
}
