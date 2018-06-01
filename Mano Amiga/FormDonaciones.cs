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

namespace Mano_Amiga
{
    public partial class FormDonaciones : Form
    {
        private Mano_AmigaEntities1 db;
        private int identificador;

        List<Articulo> listaArticulo = new List<Articulo>();

        public FormDonaciones(int  identificador)
        {
            InitializeComponent();
            this.identificador = identificador;
            LoadArticulo();
            loadComboCategoria();
            
        }
        
        
        private void LoadArticulo()
        {
            db = new Mano_AmigaEntities1();
            List<Articulo> listaArticulos = db.Articulo.ToList();
            listaArticulo = listaArticulos;
            ListView.ListViewItemCollection listaLd = new ListView.ListViewItemCollection(listViewComida);
            foreach (Articulo a in listaArticulos)
            {
                listaLd.Add(a.Nombre_Articulo, 0);
            }
            
            
        }

        private void loadArticuloByCategoria(int categ)
        {
            db = new Mano_AmigaEntities1();
            var query = from d in db.Articulo where d.id_Categoria==categ orderby d.id_Categoria select d;
            try
            {
                db = new Mano_AmigaEntities1();
                List<Articulo> Articulo = query.ToList();
                ListView.ListViewItemCollection listaLd = new ListView.ListViewItemCollection(listViewComida);
                foreach (Articulo a in Articulo)
                {
                    listaLd.Add(a.Nombre_Articulo, 0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadComboCategoria()
        {
            db = new Mano_AmigaEntities1();
            var query = from d in db.Categoria orderby d.id_Categoria select d;
            try
            {
                List<Categoria> categoria = query.ToList();
                this.comboArticulos.DataSource = categoria;
                this.comboArticulos.DisplayMember = "Tipo";
                this.comboArticulos.ValueMember = "id_Categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDatos(Articulo a)
        {
            estado1.Text = a.Estado;
            txtDesc.Text = a.Descripcion ;
           
            //pictureBox1.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath,a.Foto ));
        }
        private void btnHacerDonacion_Click(object sender, EventArgs e)
        {
            Form frm = new HacerDonacion(identificador);
            frm.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            listViewComida.Clear();
            if (comboArticulos.SelectedIndex >= 0)
            {
                loadArticuloByCategoria(Convert.ToInt32(comboArticulos.SelectedValue));
            }
                
        }

        private void listViewComida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewComida.SelectedItems.Count > 0)
            {
                Articulo a = listaArticulo.ElementAt(listViewComida.SelectedIndices[0]);
                loadDatos(a);

            }
        }

        private void comboArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            db = new Mano_AmigaEntities1();
            db.sp_ReservarArticulo(extado1.Text);

        }
    }
}
