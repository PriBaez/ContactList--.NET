using MVC_Project.Models;
using System.Data.SqlClient;
using System.Data;

namespace MVC_Project.Data
{
    public class ContactosDatos
    {
        public List<Contactos> Listar() {
            var oLista = new List<Contactos>();

            var con = new DBConnection();

            using (var conection = new SqlConnection(con.getSQLConString()) )
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Contactos()
                        {
                           IdContacto = Convert.ToInt32(dr["Con_ID"]), 
                           Nombre = dr["Con_Nombre"].ToString(),
                           Telefono = dr["Con_Telefono"].ToString(),
                           Correo = dr["Con_Correo"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

    public Contactos Obtener(int IdContacto) {
            
            var oContacto = new Contactos();

            var con = new DBConnection();

            using (var conection = new SqlConnection(con.getSQLConString()) )
            {
                conection.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", conection);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;
                
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["Con_ID"]); 
                        oContacto.Nombre = dr["Con_Nombre"].ToString();
                        oContacto.Telefono = dr["Con_Telefono"].ToString();
                        oContacto.Correo = dr["Con_Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar(Contactos ocontacto)
        {
            bool rpta;

            try
            {
                var con = new DBConnection();

                using (var conection = new SqlConnection(con.getSQLConString()) )
                {
                    conection.Open();


                    SqlCommand cmd = new SqlCommand("sp_guardar", conection);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;         
                rpta = false;
            }

            return rpta;
        }



        public bool Editar(Contactos ocontacto)
        {
            bool rpta;

            try
            {
                var con = new DBConnection();

                using (var conection = new SqlConnection(con.getSQLConString()) )
                {
                    conection.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar", conection);
                    cmd.Parameters.AddWithValue("IdContacto", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;         
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var con = new DBConnection();

                using (var conection = new SqlConnection(con.getSQLConString()) )
                {
                    conection.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar", conection);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;         
                rpta = false;
            }

            return rpta;
        }
    }
}

