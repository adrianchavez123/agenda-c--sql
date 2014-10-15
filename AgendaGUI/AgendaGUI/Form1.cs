using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AgendaGUI
{
    public partial class Form1 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
            panelAlta.Visible = false;
            panelBaja.Visible = false;
            panelModificar.Visible = false;
            panelBuscar.Visible = false;
            conexion();
            
        }

        private void crearNuevoRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarPanel(1);
        }

        private void modificarUnRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarPanel(2);
        }

        private void modificarUnRegistroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mostrarPanel(3);
        }

        private void buscarUnRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarPanel(4);
        }

        private void mostrarPanel(int panel)
        {
            switch (panel)
            {
                case 1:
                    panelAlta.Visible = true;
                    panelBaja.Visible = false;
                    panelModificar.Visible = false;
                    panelBuscar.Visible = false;
                    break;
                case 2:
                    panelAlta.Visible = false;
                    panelBaja.Visible = true;
                    panelModificar.Visible = false;
                    panelBuscar.Visible = false;
                    mostrarNombres(2);
                    break;
                case 3:
                    panelAlta.Visible = false;
                    panelBaja.Visible = false;
                    panelModificar.Visible = true;
                    panelBuscar.Visible = false;
                    mostrarNombres(3);
                    limpiarCampos();
                    break;
                case 4:
                    panelAlta.Visible = false;
                    panelBaja.Visible = false;
                    panelModificar.Visible = false;
                    panelBuscar.Visible = true;
                    break;
                default:
                    panelAlta.Visible = false;
                    panelBaja.Visible = false;
                    panelModificar.Visible = false;
                    panelBuscar.Visible = false;
                    break;
            }
        }


        private void conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=localhost;Initial Catalog=agenda;Integrated Security=True");
                cn.Open();
                MessageBox.Show("Conexion establecida", "Conectado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if (comprobarCampos())
            {
                string sentencia = "insert into usuarios("
                    + "nombre,apaterno,amaterno,edad,sexo,calle,noExt,noInt,colonia,cp,ciudad,estado,telefono,celular,email)"
                    + "values('"
                    + textBoxNombre.Text + "','"
                    + textBoxApaterno.Text + "','"
                    + textBoxAmaterno.Text + "',"
                    + comboBoxEdad.Text;
                    if (comboBoxSexo.Text == "HOMBRE")
                        sentencia += ",0,'";
                    else if (comboBoxSexo.Text == "MUJER")
                        sentencia += ",1,'";
                    else
                        sentencia += ",2,'";
                    sentencia+= textBoxCalle.Text + "' , '"
                    + textBoxNoExterior.Text + "' , '"
                    + textBoxNoInt.Text + "' , '"
                    + textBoxColonia.Text + "' , '"
                    + textBoxCP.Text + "' , '"
                    + textBoxCiudad.Text + "' , '"
                    + textBoxEstado.Text + "' , '"
                    + textBoxTelefono.Text + "' , '"
                    + textBoxCelular.Text + "' , '"
                    + textBoxEmail.Text + "')";

                Console.Write(sentencia);
                cmd = new SqlCommand(sentencia, cn);
                cmd.ExecuteReader();
                MessageBox.Show("Tu registro ha sido ingresado", "Echo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          
                mostrarPanel(-1);
          
            }
            else
            {
                MessageBox.Show("No ha podido ser ingresado tu registro, algun campo esta vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //MessageBox.Show("ingresar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
            
        }

        private bool comprobarCampos()
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text) || string.IsNullOrEmpty(textBoxApaterno.Text)|| string.IsNullOrEmpty(textBoxAmaterno.Text)
                || string.IsNullOrEmpty(textBoxCalle.Text) || string.IsNullOrEmpty(textBoxNoExterior.Text) || string.IsNullOrEmpty(textBoxColonia.Text)
                || string.IsNullOrEmpty(textBoxCiudad.Text) || string.IsNullOrEmpty(textBoxEstado.Text))
            {
                return false;   
            }

            return true;
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {

           DialogResult dr =MessageBox.Show("¿Realmente deseas eliminar el registro?","",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string[] split = comboBoxRegistroBorrar.Text.Split(' ');
                        string sentencia = "delete from usuarios where apaterno='" + split[0] + "' and amaterno='" + split[1] + "' and nombre = '" + split[2] + "'";
                        Console.WriteLine(sentencia);
                        cmd = new SqlCommand(sentencia, cn);
                        cmd.ExecuteReader();
                        MessageBox.Show("Registro eliminado.", "Echo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        mostrarPanel(-1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            
        }


        private void mostrarNombres(int tipo)
        {

            comboBoxRegistroBorrar.Items.Clear();
            comboBoxRegistroBorrar.Text = "";

            comboBoxRegistroModif.Items.Clear();
            comboBoxRegistroModif.Text = "";

            cmd = new SqlCommand("select aPaterno,aMaterno,nombre from usuarios order By aPaterno",cn);
            reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                string value1 = reader["aPaterno"].ToString()+ " " + reader["aMaterno"].ToString() + " " + reader["nombre"].ToString();
                Console.WriteLine(value1);
                if (tipo == 2)
                {
                    comboBoxRegistroBorrar.Items.Add(value1);
                }
                else if (tipo == 3)
                { 
                    comboBoxRegistroModif.Items.Add(value1);
                }
            }
            reader.Close();
        }

        private void buttonModificarRegistro_Click(object sender, EventArgs e)
        {
           
          

            DialogResult dr = MessageBox.Show("¿Realmente deseas modificar el registro?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    string[] split = comboBoxRegistroModif.Text.Split(' ');
                    string sentencia = "update usuarios set ";
                    if (comprobarCamposModif())
                    {

                        sentencia += "edad=" + textBoxEdadModif.Text + ",";
                        if (textBoxSexoModif.Text == "HOMBRE")
                            sentencia += "sexo =0,";
                        else if (textBoxSexoModif.Text == "MUJER")
                            sentencia += "sexo = 1,";
                        else
                            sentencia += "sexo = 2,";

                        sentencia += "calle ='"+textBoxCalleModif.Text+"',"
                        + "noExt ='" + textBoxNoExtModif.Text + "',"
                        + "noInt ='" + textBoxNoIntModif.Text + "',"
                        + "colonia ='" + textBoxColoniaModif.Text + "',"
                        + "cp ='" + textBoxCPModif.Text + "',"
                        + "ciudad ='" + textBoxCiudadModif.Text + "',"
                        + "estado ='" + textBoxEstadoModif.Text + "',"
                        + "telefono ='" + textBoxTelefonoModif.Text + "',"
                        + "celular ='" + textBoxCelularModif.Text + "',"
                        + "email ='" + textBoxEmailModif.Text+"'" 
                        + " where apaterno='" + split[0] + "' and amaterno='" + split[1] + "' and nombre='" + split[2] + "'";
                        
                        Console.WriteLine(sentencia);
                        cmd = new SqlCommand(sentencia, cn);
                        cmd.ExecuteReader();
                        MessageBox.Show("Registro Actualizado.", "Echo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        mostrarPanel(-1);
                    }
                    else
                    {
                        MessageBox.Show("Error algun campo esta vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private bool comprobarCamposModif()
        {
            if (string.IsNullOrEmpty(comboBoxRegistroModif.Text) || string.IsNullOrEmpty(textBoxSexoModif.Text) || string.IsNullOrEmpty(textBoxEdadModif.Text)
                || string.IsNullOrEmpty(textBoxCalleModif.Text) || string.IsNullOrEmpty(textBoxNoExtModif.Text) || string.IsNullOrEmpty(textBoxColoniaModif.Text)
                || string.IsNullOrEmpty(textBoxCiudadModif.Text) || string.IsNullOrEmpty(textBoxEstadoModif.Text) || string.IsNullOrEmpty(textBoxEmailModif.Text))
            {
                return false;
            }

            return true;
        }

        private void comboBoxRegistroModif_SelectionChangeCommitted(object sender, EventArgs e)
        {

            ComboBox senderComboBox = (ComboBox)sender;

                 try
                {
                    string[] split = senderComboBox.SelectedItem.ToString().Split(' ');
                    string sentencia = "select edad,sexo,calle,noExt,noInt,colonia,cp,ciudad,estado, "
                    +"telefono,celular,email from usuarios"
                    + " where apaterno='" + split[0] + "' and amaterno='" + split[1] + "' and nombre='" + split[2] + "'";

                    Console.WriteLine(sentencia);
                    cmd = new SqlCommand(sentencia, cn);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        textBoxEdadModif.Text = reader["edad"].ToString();
                        if (reader["sexo"].ToString() == "0")
                            textBoxSexoModif.Text = "HOMBRE";
                        else if (reader["sexo"].ToString() == "1")
                            textBoxSexoModif.Text = "MUJER";
                        else
                            textBoxSexoModif.Text = "???";
                        
                        textBoxCalleModif.Text = reader["calle"].ToString();
                        textBoxNoExtModif.Text =reader["noExt"].ToString();
                        textBoxNoIntModif.Text = reader["noInt"].ToString();
                        textBoxColoniaModif.Text =reader["colonia"].ToString();
                        textBoxCPModif.Text = reader["cp"].ToString();
                        textBoxCiudadModif.Text =reader["ciudad"].ToString();
                        textBoxEstadoModif.Text = reader["estado"].ToString();
                        textBoxTelefonoModif.Text = reader["telefono"].ToString();
                        textBoxCelularModif.Text = reader["celular"].ToString();
                        textBoxEmailModif.Text = reader["email"].ToString();

                    }

                    reader.Close();
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }//textbox1.Text = senderComboBox.SelectedItem.ToString();
            
        }

        private void limpiarCampos()
        {
            textBoxEdadModif.Text = "";
            textBoxSexoModif.Text = "";
            textBoxCalleModif.Text = "";
            textBoxNoExtModif.Text = "";
            textBoxNoIntModif.Text = "";
            textBoxColoniaModif.Text = "";
            textBoxCPModif.Text = "";
            textBoxCiudadModif.Text = "";
            textBoxEstadoModif.Text = "";
            textBoxTelefonoModif.Text = "";
            textBoxCelularModif.Text = "";
            textBoxEmailModif.Text = "";
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sentencia = "select nombre,apaterno,amaterno,calle,colonia,ciudad,telefono,email from usuarios where nombre like '%"+textBoxBuscar.Text+"%'";
            Console.WriteLine(sentencia);
            cmd = new SqlCommand(sentencia, cn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int renglon = dataGridView1.Rows.Add();
                dataGridView1.Rows[renglon].Cells["Nombre"].Value = reader["nombre"].ToString();
                dataGridView1.Rows[renglon].Cells["ApellidoPaterno"].Value = reader["apaterno"].ToString();
                dataGridView1.Rows[renglon].Cells["ApellidoMaterno"].Value = reader["amaterno"].ToString();
                dataGridView1.Rows[renglon].Cells["Calle"].Value = reader["calle"].ToString();
                dataGridView1.Rows[renglon].Cells["Colonia"].Value = reader["colonia"].ToString();
                dataGridView1.Rows[renglon].Cells["Ciudad"].Value = reader["ciudad"].ToString();
                dataGridView1.Rows[renglon].Cells["Telefono"].Value = reader["telefono"].ToString();
                dataGridView1.Rows[renglon].Cells["Email"].Value =reader["email"].ToString();

            }

            reader.Close();

        }

        

        
    }


}
