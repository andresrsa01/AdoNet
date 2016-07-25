using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ent = TutorialAdonet._10.Entidad;
using dom = TutorialAdonet._20.Dominio;
using help = TutorialAdonet._40.Helper;

namespace TutorialAdonet
{
    public partial class Form1 : Form
    {
        dom.Personal per = new dom.Personal();
        dom.Categoria cate = new dom.Categoria();
        List<ent.Personal> ListaPersonal = new List<ent.Personal>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ListaPersonal = per.ListarPersonal();
            ListaPersonal = per.PersonaLista();
            dataGridView1.DataSource = ListaPersonal;

            cboCategoria.DataSource = cate.ListarCategoria();
            cboCategoria.ValueMember = "ID";
            cboCategoria.DisplayMember = "categoria";

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            ent.Personal obj = new ent.Personal()
            {
                Nombre = txtNombre.Text,
                ApePaterno = txtApePaterno.Text,
                ApeMaterno = txtApeMaterno.Text,
                IDCategoria = Convert.ToInt32(cboCategoria.SelectedValue),
                Pais = cboArea.Text,
                Fecha = Convert.ToDateTime(txtFecha.Text),
                Salario = Convert.ToDecimal(txtsalario.Text)
            };

            help.Validacion<ent.Personal> valida = new help.Validacion<ent.Personal>();
            string mensaje = valida.validar(obj);

            if (mensaje != "Correcto")
            {
                MessageBox.Show(mensaje);
            }
            else
            {
                per.RegistrarPersonal(obj);
                ListaPersonal = per.ListarPersonal();
                dataGridView1.DataSource = ListaPersonal;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ent.Personal obj = new ent.Personal()
            {
                ID = Convert.ToInt32(txtIdModificar.Text),
                Nombre = txtNombre.Text,
                ApePaterno = txtApePaterno.Text,
                ApeMaterno = txtApeMaterno.Text,
                IDCategoria = Convert.ToInt32(cboCategoria.SelectedValue),
                Pais = cboArea.Text,
                Fecha = Convert.ToDateTime(txtFecha.Text),
                Salario = Convert.ToDecimal(txtsalario.Text)
            };

            per.ModificarPersonal(obj);
            ListaPersonal = per.ListarPersonal();
            dataGridView1.DataSource = ListaPersonal;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            per.BorrarPersonal(Convert.ToInt32(txtIdBorrar.Text));
            ListaPersonal = per.ListarPersonal();
            dataGridView1.DataSource = ListaPersonal;
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            CategoriaFormulario obj = new CategoriaFormulario();
            obj.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                txtIdModificar.Text = (string)dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                txtNombre.Text = (string)dataGridView1.CurrentRow.Cells["Nombre"].Value;
                txtApePaterno.Text = (string)dataGridView1.CurrentRow.Cells["ApePaterno"].Value;
                txtApeMaterno.Text = (string)dataGridView1.CurrentRow.Cells["ApeMaterno"].Value;
                cboCategoria.SelectedValue = (Int32)dataGridView1.CurrentRow.Cells["IDCategoria"].Value;
                cboArea.Text = (string)dataGridView1.CurrentRow.Cells["Pais"].Value;
                txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                txtsalario.Text = dataGridView1.CurrentRow.Cells["Salario"].Value.ToString();

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdModificar.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApePaterno.Text = string.Empty;
            txtApeMaterno.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtsalario.Text = string.Empty;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ListaPersonal = per.ListarPersonal();
            dataGridView1.DataSource = ListaPersonal;

            cboCategoria.DataSource = cate.ListarCategoria();
            cboCategoria.ValueMember = "ID";
            cboCategoria.DisplayMember = "categoria";
        }

        private void btnBNombre_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ListaPersonal.Where(x => x.Nombre.StartsWith(txtNombre.Text) && x.Salario > 400 ).ToList();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ListaPersonal.OrderByDescending(x => x.ID).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ListaPersonal.Where(x => x.Salario > 150).ToList();
        }


    }
}
