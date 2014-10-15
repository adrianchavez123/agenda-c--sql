using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Articulos : System.Web.UI.Page
{
    Conexion con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new Conexion();
        mostrarPanel(3);
        Response.Write("<script>alert('"+Session["admin"]+"')</script>");
        if ((String)Session["admin"] ==null)
        {
            Response.Write("<script>alert('Para acceder a este contenido debes iniciar sesion')</script>");
        }
    }
    private void limpiarCampos()
    {
        textBoxNombre.Text = "";
        textBoxDescripcion.Text = "";
        textBoxPrecioVenta.Text = "";
        textBoxExistencia.Text = "";




        textBoxDescripcionM.Text = "";
        textBoxPrecioVentaM.Text = "";
        textBoxExistenciaM.Text = "";

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(textBoxNombre.Text) && !String.IsNullOrEmpty(textBoxDescripcion.Text)
            && !String.IsNullOrEmpty(textBoxExistencia.Text) && !String.IsNullOrEmpty(textBoxPrecioVenta.Text))
             
        {

            bool res = con.insertarArticulo(textBoxNombre.Text, textBoxDescripcion.Text, textBoxExistencia.Text,
                textBoxPrecioVenta.Text);
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

        bool eliminado = con.eliminarArticulo(s);

        if (eliminado)
        {
            Response.Write("<script>alert('El registro ha sido eliminado')</script>");
        }
        else
        {
            Response.Write("<script>alert('El registro no se pudo eliminar.')</script>");

        }
    }
    protected void ButtonModificar_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(textBoxDescripcionM.Text)
            && !String.IsNullOrEmpty(textBoxExistenciaM.Text) && !String.IsNullOrEmpty(textBoxPrecioVentaM.Text))
             
        {
            string id = DropDownList2.SelectedValue;

            bool res = con.updateArticulo(id, textBoxDescripcionM.Text, textBoxExistenciaM.Text,
                textBoxPrecioVentaM.Text);
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
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = DropDownList2.SelectedValue;

        string data = con.getDatosArticulo(id);

        string[] d = data.Split('¬');

        textBoxDescripcionM.Text = d[0];
        textBoxExistenciaM.Text = d[1];
        textBoxPrecioVentaM.Text = d[2];
        
    }
}