using Business;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcial
{
    public partial class Form1 : Form
    {
        PartidoBusiness partidoBusiness = new PartidoBusiness();
        DeporteBusiness deporteBusiness = new DeporteBusiness();    
        
        public Form1()
        {
            InitializeComponent();
        }
        public void ActualizarDataGrid()
        {
            dataGridView1.DataSource = partidoBusiness.GetPartidos();
            TxtLocal.Text = null;
            TxtVisitante.Text = null;
            comboBox1.Text = null;
            Txteliminar.Text = null;


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarDataGrid();
            ObtenerCombo();
        }
        public void ObtenerCombo()
        {
            comboBox1.Items.Clear();
            comboBox1.DataSource = deporteBusiness.GetDeportes();   
            comboBox1.DisplayMember = "tipodeporte";
            comboBox1.ValueMember = "idDeporte";
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevoPartido = new Partido();
                nuevoPartido.IdPartido = Convert.ToInt32(comboBox1.SelectedValue.ToString());   
                nuevoPartido.EquipoLocal = Convert.ToString(TxtLocal.Text);
                nuevoPartido.EquipoVisitante = Convert.ToString(TxtVisitante.Text);
                nuevoPartido.FechaPartido = Convert.ToDateTime(monthCalendar1.SelectionStart.ToString());
                nuevoPartido.IdDeporte = Convert.ToInt32(comboBox1.SelectedValue);
                nuevoPartido.FechaRegistro = DateTime.Today;
                partidoBusiness.CargarPartidos(nuevoPartido);
                ActualizarDataGrid();
                MessageBox.Show("se agregó con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var eliminoPartido = new Partido();
                eliminoPartido.IdPartido = Convert.ToInt32(Txteliminar.Text);
                partidoBusiness.EliminarPartido(eliminoPartido);
                ActualizarDataGrid();
                MessageBox.Show("Se eliminó con exito");
            }
            catch(Exception  ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var editoPartido = new Partido();
                partidoBusiness.EditarPartidos(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox4.Text));
                ActualizarDataGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );   
            }
        }
    }
}
