using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Empleados : System.Web.UI.Page
{
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new Conexion();
        mostrarPanel(3);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxPuesto.Text)
            && !String.IsNullOrEmpty(textBoxSueldo.Text) && !String.IsNullOrEmpty(textBoxAntiguedad.Text)
             && !String.IsNullOrEmpty(textBoxCelular.Text) && !String.IsNullOrEmpty(textBoxTelefono.Text)
             && !String.IsNullOrEmpty(textBoxEmail.Text) && !String.IsNullOrEmpty(textBoxDomicilio.Text)
            && !String.IsNullOrEmpty(textBoxNoSS.Text))
        {

            bool res = con.insertarEmpleado(textBoxNombre.Text, textBoxPuesto.Text, textBoxSueldo.Text,
                textBoxAntiguedad.Text, textBoxCelular.Text, textBoxTelefono.Text, textBoxEmail.Text,
                textBoxDomicilio.Text, textBoxNoSS.Text);
            if (res)
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
        textBoxSueldo.Text = "";
        textBoxCelular.Text = "";
        textBoxEmail.Text = "";
        textBoxNoSS.Text = "";
        textBoxPuesto.Text = "";
        textBoxAntiguedad.Text = "";


        textBoxDomicilioM.Text = "";
        textBoxTelefonoM.Text = "";
        textBoxSueldoM.Text = "";
        textBoxCelularM.Text = "";
        textBoxEmailM.Text = "";
        textBoxNoSSM.Text = "";
        textBoxPuestoM.Text = "";
        textBoxAntiguedadM.Text = "";

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

        bool eliminado = con.eliminarEmpleado(s);

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

        string data = con.getDatosEmpleados(id);

        string[] d = data.Split('¬');

        textBoxPuestoM.Text = d[0];
        textBoxSueldoM.Text = d[1];
        textBoxAntiguedadM.Text = d[2];
        textBoxCelularM.Text = d[3];
        textBoxTelefonoM.Text = d[4];
        textBoxEmailM.Text = d[5];
        textBoxDomicilioM.Text = d[6];
        textBoxNoSSM.Text = d[7];

    }
    protected void ButtonModificar_Click(object sender, EventArgs e)
    {

        if ( !String.IsNullOrEmpty(textBoxPuestoM.Text)
            && !String.IsNullOrEmpty(textBoxSueldoM.Text) && !String.IsNullOrEmpty(textBoxAntiguedadM.Text)
             && !String.IsNullOrEmpty(textBoxCelularM.Text) && !String.IsNullOrEmpty(textBoxTelefonoM.Text)
             && !String.IsNullOrEmpty(textBoxEmailM.Text) && !String.IsNullOrEmpty(textBoxDomicilioM.Text)
            && !String.IsNullOrEmpty(textBoxNoSSM.Text))
        {
            string id = DropDownList2.SelectedValue;

            bool res = con.updateEmpleado(id, textBoxPuestoM.Text, textBoxSueldoM.Text,
                textBoxAntiguedadM.Text, textBoxCelularM.Text, textBoxTelefonoM.Text, textBoxEmailM.Text,
                textBoxDomicilioM.Text, textBoxNoSSM.Text);
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