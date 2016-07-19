using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dom = TutorialAdonet._20.Dominio;
using ent = TutorialAdonet._10.Entidad;

namespace TutorialAdonet
{
    public partial class CategoriaFormulario : Form
    {
        dom.Categoria obj = new dom.Categoria();
        List<ent.Categoria> listacategoria = new List<ent.Categoria>();

        public CategoriaFormulario()
        {
            InitializeComponent();
        }

        private void CategoriaFormulario_Load(object sender, EventArgs e)
        {
            listacategoria = obj.ListarCategoria();
            dataGridView1.DataSource = listacategoria;
        }

        private void btnRegistrarCategoria_Click(object sender, EventArgs e)
        {
            ent.Categoria ent = new ent.Categoria()
            {
                categoria = txtcategoria.Text
            };

            obj.RegistrarCategoria(ent);
            dataGridView1.DataSource = obj.ListarCategoria();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            ent.Categoria ent = new ent.Categoria()
            {
                ID = Convert.ToInt32(txtIDCategoria.Text),
                categoria = txtcategoria.Text
            };

            obj.ModificarCategoria(ent);
            dataGridView1.DataSource = obj.ListarCategoria();
        }

        private void btnBorrarCategoria_Click(object sender, EventArgs e)
        {
            obj.EliminarCategoria(Convert.ToInt32(txtIDCategoria.Text));
            dataGridView1.DataSource = obj.ListarCategoria();
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = listacategoria.Where(x => x.categoria.Contains(txtcategoria.Text)).ToList();
        }


    }
}
