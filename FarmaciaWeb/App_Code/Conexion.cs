using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataReader reader;
	public Conexion()
	{
        try
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
            con.Open();

        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
	}

    public Boolean insertarCliente(string nombre, string domicilio, string colonia, string telefono, string celular, string cp, string municipio, string estado, string email)
    {
        string sentencia ="insert into clientes(nombre,domicilio,colonia,telefono,celular,cp,municipio,estado,email,activo)values(@Nombre, @Domicilio, @Colonia,@Telefono,@Celular,@Cp,@Municipio,@Estado,@Email,1)";

        cmd = new SqlCommand(sentencia, con);

        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@Nombre",SqlDbType.VarChar,60).Value = nombre;
        cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100).Value = domicilio;
        cmd.Parameters.Add("@Colonia", SqlDbType.VarChar, 30).Value = colonia;
        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 10).Value = telefono;
        cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = celular;
        cmd.Parameters.Add("@Cp", SqlDbType.VarChar, 6).Value = cp;
        cmd.Parameters.Add("@Municipio", SqlDbType.VarChar, 60).Value = municipio;
        cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 60).Value = estado;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;

        int x = cmd.ExecuteNonQuery();

        if (x == 0)
            return false;

        return true;
    }


    public bool eliminarCliente(string s)
    {
        cmd = new SqlCommand("update clientes set activo= 0 where idCliente="+s, con);

        int e = cmd.ExecuteNonQuery();

        if (e == 0)
            return false;
        return true;
    }

    public string getDatosClientes(string id)
    {
        string sentencia = "select * from clientes where idCliente =" + id;
        cmd = new SqlCommand(sentencia,con);
        reader = cmd.ExecuteReader();
        string data = "";
        while (reader.Read())
        {
            data += reader["domicilio"].ToString()+"¬";
            data += reader["colonia"].ToString() + "¬";
            data += reader["telefono"].ToString() + "¬";
            data += reader["celular"].ToString() + "¬";
            data += reader["cp"].ToString() + "¬";
            data += reader["municipio"].ToString() + "¬";
            data += reader["estado"].ToString() + "¬";
            data += reader["email"].ToString();


        }

        return data;
    }

    public bool updateCliente(string id,string domicilio, string colonia, string telefono, string celular, string cp, string municipio, string estado, string email)
    {
        string sentencia = "update clientes set domicilio= @Domicilio,colonia = @Colonia,telefono= @Telefono,celular=@Celular,cp=@Cp,municipio=@Municipio,estado=@Estado,email=@Email where idCliente="+id;

        cmd = new SqlCommand(sentencia, con);

        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100).Value = domicilio;
        cmd.Parameters.Add("@Colonia", SqlDbType.VarChar, 30).Value = colonia;
        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 10).Value = telefono;
        cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = celular;
        cmd.Parameters.Add("@Cp", SqlDbType.VarChar, 6).Value = cp;
        cmd.Parameters.Add("@Municipio", SqlDbType.VarChar, 60).Value = municipio;
        cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 60).Value = estado;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;

        int x = cmd.ExecuteNonQuery();

        if (x == 0)
            return false;

        return true;
    }

 

    public bool insertarEmpleado(string nombre, string puesto, string sueldo, string antiguedad, string celular, string telefono, string email, string domicilio, string noSS)
    {
        string sentencia = "insert into empleados(nombre,puesto,sueldo,antiguedad,celular,telefono,email,domicilio,noSeguroSocial,activo)values(@Nombre, @Puesto, @Sueldo,@Antiguedad,@Celular,@Telefono,@Email,@Domicilio,@NoSS,1)";

        cmd = new SqlCommand(sentencia, con);

        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 60).Value = nombre;
        cmd.Parameters.Add("@Puesto", SqlDbType.VarChar, 100).Value = puesto;
        cmd.Parameters.Add("@Sueldo", SqlDbType.Real).Value = sueldo;
        cmd.Parameters.Add("@Antiguedad", SqlDbType.Int).Value = antiguedad;
        cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = celular;
        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 10).Value = telefono;
        cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100).Value = domicilio;
        cmd.Parameters.Add("@NoSS", SqlDbType.VarChar, 100).Value = noSS;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;

        int x = cmd.ExecuteNonQuery();

        if (x == 0)
            return false;

        return true;
    }

    public bool eliminarEmpleado(string s)
    {
        cmd = new SqlCommand("update empleados set activo= 0 where idEmpleado=" + s, con);

        int e = cmd.ExecuteNonQuery();

        if (e == 0)
            return false;
        return true;
    }

    public string getDatosEmpleados(string id)
    {
        string sentencia = "select * from empleados where idEmpleado =" + id;
        cmd = new SqlCommand(sentencia, con);
        reader = cmd.ExecuteReader();
        string data = "";
        while (reader.Read())
        {
            data += reader["puesto"].ToString() + "¬";
            data += reader["sueldo"].ToString() + "¬";
            data += reader["antiguedad"].ToString() + "¬";
            data += reader["celular"].ToString() + "¬";
            data += reader["telefono"].ToString() + "¬";
            data += reader["email"].ToString() + "¬";
            data += reader["domicilio"].ToString() + "¬";
            data += reader["noSeguroSocial"].ToString();


        }

        return data;
    }

    public bool updateEmpleado(string id, string puesto, string sueldo, string antiguedad, string celular, string telefono, string email, string domicilio, string noSS)
    {
        string sentencia = "update empleados set puesto= @Puesto,sueldo = @Sueldo,antiguedad= @Antiguedad,celular=@Celular,telefono=@Telefono,email=@Email,domicilio=@Domicilio,noSeguroSocial=@NoSS where idEmpleado=" + id;

        cmd = new SqlCommand(sentencia, con);

        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@Puesto", SqlDbType.VarChar, 100).Value = puesto;
        cmd.Parameters.Add("@Sueldo", SqlDbType.Real).Value = sueldo;
        cmd.Parameters.Add("@Antiguedad", SqlDbType.Int).Value = antiguedad;
        cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = celular;
        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 10).Value = telefono;
        cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100).Value = domicilio;
        cmd.Parameters.Add("@NoSS", SqlDbType.VarChar, 100).Value = noSS;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;

        int x = cmd.ExecuteNonQuery();

        if (x == 0)
            return false;

        return true;
    }

    public bool insertarProveedor(string nombre, string domicilio, string colonia, string telefono, string celular, string cp, string municipio, string estado, string email,string rfc)
    {
        string sentencia = "insert into proveedores(nombre,domicilio,colonia,telefono,celular,cp,municipio,estado,email,rfc,activo)values(@Nombre, @Domicilio, @Colonia,@Telefono,@Celular,@Cp,@Municipio,@Estado,@Email,@RFC,1)";

        cmd = new SqlCommand(sentencia, con);

        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 60).Value = nombre;
        cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100).Value = domicilio;
        cmd.Parameters.Add("@Colonia", SqlDbType.VarChar, 30).Value = colonia;
        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 10).Value = telefono;
        cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = celular;
        cmd.Parameters.Add("@Cp", SqlDbType.VarChar, 6).Value = cp;
        cmd.Parameters.Add("@Municipio", SqlDbType.VarChar, 60).Value = municipio;
        cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 60).Value = estado;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
        cmd.Parameters.Add("@RFC", SqlDbType.VarChar, 100).Value = rfc;

        int x = cmd.ExecuteNonQuery();

        if (x == 0)
            return false;

        return true;
    }

    public bool eliminarProveedor(string s)
    {
        cmd = new SqlCommand("update proveedores set activo= 0 where idProveedor=" + s, con);

        int e = cmd.ExecuteNonQuery();

        if (e == 0)
            return false;
        return true;
    }

    public string getDatosProveedor(string id)
    {
        string sentencia = "select * from proveedores where idProveedor =" + id;
        cmd = new SqlCommand(sentencia, con);
        reader = cmd.ExecuteReader();
        string data = "";
        while (reader.Read())
        {
            data += reader["domicilio"].ToString() + "¬";
            data += reader["colonia"].ToString() + "¬";
            data += reader["telefono"].ToString() + "¬";
            data += reader["celular"].ToString() + "¬";
            data += reader["cp"].ToString() + "¬";
            data += reader["municipio"].ToString() + "¬";
            data += reader["estado"].ToString() + "¬";
            data += reader["email"].ToString() + "¬";
            data += reader["rfc"].ToString();


        }

        return data;
    }

    public bool updateProveedor(string id, string domicilio, string colonia, string telefono, string celular, string cp, string municipio, string estado, string email, string rfc)
    {
        string sentencia = "update proveedores set domicilio= @Domicilio,colonia = @Colonia,telefono= @Telefono,celular=@Celular,cp=@Cp,municipio=@Municipio,estado=@Estado,email=@Email,rfc = @RFC where idProveedor=" + id;

        cmd = new SqlCommand(sentencia, con);

        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100).Value = domicilio;
        cmd.Parameters.Add("@Colonia", SqlDbType.VarChar, 30).Value = colonia;
        cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 10).Value = telefono;
        cmd.Parameters.Add("@Celular", SqlDbType.VarChar, 15).Value = celular;
        cmd.Parameters.Add("@Cp", SqlDbType.VarChar, 6).Value = cp;
        cmd.Parameters.Add("@Municipio", SqlDbType.VarChar, 60).Value = municipio;
        cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 60).Value = estado;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
        cmd.Parameters.Add("@RFC", SqlDbType.VarChar, 100).Value = email;
        int x = cmd.ExecuteNonQuery();

        if (x == 0)
            return false;

        return true;
    }

    public bool insertarArticulo(string nombre, string descripcion, string existencia, string precio)
    {
        string sentencia = "insert into articulos(nombre,descripcion,existencia,precioVenta,activo)values(@Nombre, @Descripcion, @Existencia,@Precio,1)";

        cmd = new SqlCommand(sentencia, con);

        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 60).Value = nombre;
        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 255).Value = descripcion;
        cmd.Parameters.Add("@Existencia", SqlDbType.Int).Value = existencia;
        cmd.Parameters.Add("@Precio", SqlDbType.Real).Value = precio;
       

        int x = cmd.ExecuteNonQuery();

        if (x == 0)
            return false;

        return true;   
    }

    public bool eliminarArticulo(string s)
    {
        cmd = new SqlCommand("update articulos set activo= 0 where idArticulo=" + s, con);

        int e = cmd.ExecuteNonQuery();

        if (e == 0)
            return false;
        return true;
    }

    public string getDatosArticulo(string id)
    {
        string sentencia = "select * from articulos where idArticulo =" + id;
        cmd = new SqlCommand(sentencia, con);
        reader = cmd.ExecuteReader();
        string data = "";
        while (reader.Read())
        {
            data += reader["descripcion"].ToString() + "¬";
            data += reader["existencia"].ToString() + "¬";
            data += reader["precioVenta"].ToString();


        }

        return data;
    }

    public bool updateArticulo(string id, string descripcion, string existencia, string precio)
    {
        string sentencia = "update articulos set descripcion= @Descripcion, existencia = @Existencia,precioVenta= @Precio where idArticulo=" + id;

        cmd = new SqlCommand(sentencia, con);

        cmd.CommandType = CommandType.Text;

        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 255).Value = descripcion;
        cmd.Parameters.Add("@Existencia", SqlDbType.Int).Value = existencia;
        cmd.Parameters.Add("@Precio", SqlDbType.Real).Value = precio;
        int x = cmd.ExecuteNonQuery();

        if (x == 0)
            return false;

        return true;
    }
}