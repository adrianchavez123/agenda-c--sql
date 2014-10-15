using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Proveedores : System.Web.UI.Page
{
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new Conexion();
        mostrarPanel(3);
    }
    protected void ButtonModificar_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(textBoxDomicilioM.Text)
           && !String.IsNullOrEmpty(textBoxColoniaM.Text) && !String.IsNullOrEmpty(textBoxTelefonoM.Text)
            && !String.IsNullOrEmpty(textBoxCelularM.Text) && !String.IsNullOrEmpty(textBoxCpM.Text)
            && !String.IsNullOrEmpty(textBoxMunicipioM.Text) && !String.IsNullOrEmpty(textBoxEstadoM.Text)
           && !String.IsNullOrEmpty(textBoxEmailM.Text) && !String.IsNullOrEmpty(textBoxRFCM.Text))
        {
            string id = DropDownList2.SelectedValue;

            bool res = con.updateProveedor(id, textBoxDomicilioM.Text, textBoxColoniaM.Text,
                textBoxTelefonoM.Text, textBoxCelularM.Text, textBoxCpM.Text, textBoxMunicipioM.Text,
                textBoxEstadoM.Text, textBoxEmailM.Text, textBoxRFCM.Text);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxDomicilio.Text)
            && !String.IsNullOrEmpty(textBoxColonia.Text) && !String.IsNullOrEmpty(textBoxTelefono.Text)
             && !String.IsNullOrEmpty(textBoxCelular.Text) && !String.IsNullOrEmpty(textBoxEmail.Text)
             && !String.IsNullOrEmpty(textBoxCp.Text) && !String.IsNullOrEmpty(textBoxMunicipio.Text)
            && !String.IsNullOrEmpty(textBoxEstado.Text) && !String.IsNullOrEmpty(textBoxRFC.Text))
        {
            //(string nombre, string domicilio, string colonia, string telefono, string celular, string cp, string municipio, string estado, string email,string rfc)
            bool res = con.insertarProveedor(textBoxNombre.Text, textBoxDomicilio.Text, textBoxColonia.Text,
                textBoxTelefono.Text, textBoxCelular.Text, textBoxCp.Text,
                textBoxMunicipio.Text, textBoxEstado.Text, textBoxEmail.Text, textBoxRFC.Text);
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
    protected void ButtonEliminar_Click(object sender, EventArgs e)
    {
        string s = DropDownList1.SelectedValue;

        bool eliminado = con.eliminarProveedor(s);

        if (eliminado)
        {
            Response.Write("<script>alert('El registro ha sido eliminado')</script>");
        }
        else
        {
            Response.Write("<script>alert('El registro no se pudo eliminar.')</script>");

        }
        

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
    private void limpiarCampos()
    {
        textBoxNombre.Text = "";
        textBoxDomicilio.Text = "";
        textBoxTelefono.Text = "";
        textBoxColonia.Text = "";
        textBoxCelular.Text = "";
        textBoxEmail.Text = "";
        textBoxRFC.Text = "";
        textBoxMunicipio.Text = "";
        textBoxEstado.Text = "";


        textBoxDomicilioM.Text = "";
        textBoxTelefonoM.Text = "";
        textBoxColoniaM.Text = "";
        textBoxCelularM.Text = "";
        textBoxEmailM.Text = "";
        textBoxRFCM.Text = "";
        textBoxMunicipioM.Text = "";
        textBoxEstadoM.Text = "";

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

        string data = con.getDatosProveedor(id);

        string[] d = data.Split('¬');

        textBoxDomicilioM.Text = d[0];
        textBoxTelefonoM.Text = d[2];
        textBoxColoniaM.Text = d[1];
        textBoxCelularM.Text = d[3];
        textBoxEmailM.Text = d[7];
        textBoxCpM.Text = d[4];
        textBoxMunicipioM.Text = d[5];
        textBoxEstadoM.Text = d[6];
        textBoxRFCM.Text = d[8];
    }
}