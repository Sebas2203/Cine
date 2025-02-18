using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Cine
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                mensajeTexto.InnerText = "Su sesión ya fue iniciada. Redireccionando a la cartelera.";
                System.Threading.Thread.Sleep(3000);
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string folder = "~/DataFiles/";

                string ruta = Server.MapPath(folder + "Usuarios.xml"); //ruta del archivo de usuarios

                User usuario = new User();
                usuario.username = txtUsername.Text;
                usuario.password = txtPassword.Text;
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                List<User> users;

                //se lee elarchivo de usuarios
                using (var reader = new StreamReader(ruta))
                {
                    users = (List<User>)serializer.Deserialize(reader); //se deserializa el XML y se pone en la lista
                }

                User existingUser = users.FirstOrDefault(u => u.username == usuario.username);

                if (existingUser == null) // Si el usuario no existe
                {
                    mensajeTexto.InnerText = "El nombre de usuario o contraseña es incorrecto.";
                }
                else
                {
                    // Compara las passwords
                    if (existingUser.password == usuario.password) // Successful login
                    {
                        Session["UserLogin"] = existingUser; // Set user session
                        Response.Redirect("Home.aspx"); // Redirect to home page
                    }
                    else
                    {
                        mensajeTexto.InnerText = "El nombre de usuario o contraseña es incorrecto.";
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }

            // Validate user credentials
            if (txtUsername.Text == "user" && txtPassword.Text == "password")
            {
                User usuario = new User();
                usuario.username = txtUsername.Text;
                usuario.password = txtPassword.Text;
                Session["UserLogin"] = usuario;

                // Redirect to the home page
                Session["LoginFailed"] = null;
                Response.Redirect("Home.aspx");
            }
            else
            {
                // Show an error message
                mensajeTexto.InnerText = "Usuario o contraseña equivocados.";
                divMensaje.Style["display"] = "block";
                Session["LoginFailed"] = true;
            }
        }


        /*protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                //sino existe en la session, crea la instancia
                if (Session["UserLogin"] != null)
                {
                    mensajeTexto.InnerText = "Su sesión ya fue iniciada. Redireccionando a la cartelera";
                    System.Threading.Thread.Sleep(3000);
                    Response.Redirect("Home.aspx");
                }
                else
                {

                    //objeto para sostener los datos
                    User usuario = new User();
                    usuario.username = txtUsername.Text;
                    usuario.password = txtPassword.Text;

                    //codigo para crear el XML

                    //crear el archivo en el Server

                    //configurar donde se guardará el archivo en el server
                    string folder = "~/DataFiles/";

                    string ruta = Server.MapPath(folder + "Usuarios.xml");

                    if (!File.Exists(ruta)) //crea el archivo si no existe
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

                        //crea una lista para sostener a los usuarios
                        List<User> users = new List<User> { usuario };

                        using (var writer = new StreamWriter(ruta))
                        {
                            serializer.Serialize(writer, usuario);
                        }
                    }
                    else //agrega usuarios al archivo si el archivo existe
                    {
                        XmlSerializer serializer = new XmlSerializer (typeof(List<User>));
                        List<User> users;

                        using (var reader = new StreamReader(ruta))
                        { 
                            users = (List<User>)serializer.Deserialize(reader); //se deserializa el XML y se pone en la lista
                        }

                        bool userExists = users.Exists(u  => u.username == usuario.username); //variable para revisar si un usuario ya esta registrado

                        if (userExists)
                        {
                            mensajeTexto.InnerText = "El nombre de usuario ya está registrado";
                        }
                        else 
                        {
                            users.Add(usuario);

                            using (var writer = new StreamWriter(ruta))
                            {
                                serializer.Serialize(writer, users); // se serializa la lista ya con el usuario nuevo de vuelta al XML
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                mensajeTexto.InnerText = "Ocurrió un error: " + ex.Message;
                divMensaje.Style["display"] = "block";
            }

        }*/



    }
}