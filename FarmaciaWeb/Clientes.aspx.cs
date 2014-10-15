using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Clientes : System.Web.UI.Page
{
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new Conexion();
        mostrarPanel(3);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxDomicilio.Text)
            && !String.IsNullOrEmpty(textBoxColonia.Text) && !String.IsNullOrEmpty(textBoxTelefono.Text)
             && !String.IsNullOrEmpty(textBoxCelular.Text) && !String.IsNullOrEmpty(textBoxCp.Text)
             && !String.IsNullOrEmpty(textBoxMunicipio.Text) && !String.IsNullOrEmpty(textBoxEstado.Text)
            && !String.IsNullOrEmpty(textBoxEmail.Text))
        {

            bool res =con.insertarCliente(textBoxNombre.Text,textBoxDomicilio.Text,textBoxColonia.Text,
                textBoxTelefono.Text,textBoxCelular.Text,textBoxCp.Text,textBoxMunicipio.Text,
                textBoxEstado.Text,textBoxEmail.Text);
            if(res)
            {
                Response.Write("<script>alert('Datos insertados.')</script>");
                mostrarPanel(5);
                limpiarCampos();
            }
            else
            {
                Response.Write("<script>alert('Ocurrio un Error.')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Todos los datos debe de ser ingresado.')</script>");
        }
           
    }

    private void limpiarCampos()
    {
        textBoxNombre.Text = "";
        textBoxDomicilio.Text = "";
        textBoxTelefono.Text = "";
        textBoxColonia.Text = "";
        textBoxCelular.Text = "";
        textBoxEmail.Text = "";
        textBoxCp.Text = "";
        textBoxMunicipio.Text = "";
        textBoxEstado.Text = "";


        textBoxDomicilioModif.Text = "";
        textBoxTelefonoModif.Text = "";
        textBoxColoniaModif.Text = "";
        textBoxCelularModif.Text = "";
        textBoxEmailModif.Text = "";
        textBoxCpModif.Text = "";
        textBoxMunicipioModif.Text = "";
        textBoxEstado0.Text = "";

    }
    protected void LinkModificar_Click(object sender, EventArgs e)
    {
        mostrarPanel(3);
    }
    protected void LinkEliminar_Click(object sender, EventArgs e)
    {
        mostrarPanel(2);
    }
    protected void LinkAgregar_Click(object sender, EventArgs e)
    {
        mostrarPanel(1);
    }
    protected void LinkBuscar_Click(object sender, EventArgs e)
    {
        mostrarPanel(4);
    }

    
    protected void ButtonEliminar_Click(object sender, EventArgs e)
    {
        string s = DropDownList1.SelectedValue;

        bool eliminado = con.eliminarCliente(s);

        if (eliminado)
        {
            Response.Write("<script>alert('El registro ha sido eliminado')</script>");
        }
        else
        {
            Response.Write("<script>alert('El registro no se pudo eliminar.')</script>");
       
        }
        
    }
    protected void mostrarPanel(int id)
    {
        switch (id)
        {
            case 1:
                Panel1.Visible = true;
                panelEliminar.Visible = false;
                PanelModificar.Visible = false;
                panelMostrar.Visible = false;

                break;
            case 2:
                Panel1.Visible = false;
                panelEliminar.Visible = true;
                PanelModificar.Visible = false;
                panelMostrar.Visible = false;
                break;
            case 3:
                Panel1.Visible = false;
                panelEliminar.Visible = false;
                PanelModificar.Visible = true;
                panelMostrar.Visible = false;
                break;
            case 4:
                Panel1.Visible = false;
                panelEliminar.Visible = false;
                PanelModificar.Visible = false;
                panelMostrar.Visible = true;
                break;
            default:
                Panel1.Visible = false;
                panelEliminar.Visible = false;
                PanelModificar.Visible = false;
                panelMostrar.Visible = false;
                break;

        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = DropDownList2.SelectedValue;

        string data = con.getDatosClientes(id);
        
        string[] d= data.Split('¬');

        textBoxDomicilioModif.Text = d[0];
        textBoxTelefonoModif.Text = d[2];
        textBoxColoniaModif.Text = d[1];
        textBoxCelularModif.Text = d[3];
        textBoxEmailModif.Text = d[7];
        textBoxCpModif.Text = d[4];
        textBoxMunicipioModif.Text = d[5];
        textBoxEstado0.Text = d[6];

    }
    protected void ButtonModificar_Click(object sender, EventArgs e)
    {
        if ( !String.IsNullOrEmpty(textBoxDomicilioModif.Text)
           && !String.IsNullOrEmpty(textBoxColoniaModif.Text) && !String.IsNullOrEmpty(textBoxTelefonoModif.Text)
            && !String.IsNullOrEmpty(textBoxCelularModif.Text) && !String.IsNullOrEmpty(textBoxCpModif.Text)
            && !String.IsNullOrEmpty(textBoxMunicipioModif.Text) && !String.IsNullOrEmpty(textBoxEstado0.Text)
           && !String.IsNullOrEmpty(textBoxEmailModif.Text))
        {
            string id = DropDownList2.SelectedValue;

            bool res = con.updateCliente(id,textBoxDomicilioModif.Text, textBoxColoniaModif.Text,
                textBoxTelefonoModif.Text, textBoxCelularModif.Text, textBoxCpModif.Text, textBoxMunicipioModif.Text,
                textBoxEstado0.Text, textBoxEmailModif.Text);
            if (res)
            {
                Response.Write("<script>alert('Datos actualizados.')</script>");
                mostrarPanel(5);
                limpiarCampos();
            }
            else
            {
                Response.Write("<script>alert('Ocurrio un Error.')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Todos los datos debe de ser ingresado.')</script>");
        }

    }
}