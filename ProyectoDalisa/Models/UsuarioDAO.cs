using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoDalisa.Entity;
using ProyectoDalisa.Services;
using ProyectoDalisa.DataBase;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoDalisa.Models
{
    public class UsuarioDAO : IdaoUsuario<Usuario>
    {
        

        public Usuario Logueo(string use, string pas)
        {
            Usuario usu = null;
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("SP_INGRESAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USE",use);
            cmd.Parameters.AddWithValue("@PASS",pas);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usu = new Usuario()
                    {
                        idUsuario = dr[0].ToString(),
                        Pais = dr[1].ToString(),
                        Nombre = dr[2].ToString(),
                        Apellido = dr[3].ToString(),
                        FechaNac = dr[4].ToString(),
                        EstadoCiv = dr[5].ToString(),
                        sexo = dr[6].ToString(),
                        Dni = dr[7].ToString(),
                        Direccion = dr[8].ToString(),
                        Departamento = dr[9].ToString(),
                        Provincia=dr[10].ToString(),
                        Distrito = dr[11].ToString(),
                        Celuar = dr[12].ToString(),
                        Correo = dr[13].ToString(),
                        User = dr[14].ToString(),
                        Password = dr[15].ToString(),
                        Cuenta = dr[16].ToString(),
                        Banc = new Banco() {idBanco= Convert.ToInt32(dr[21]),Nombre=dr[22].ToString(),Tipo=dr[23].ToString() } 
                       
                    };
                }
                dr.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally { cn.Close(); }
            return usu;
        }
        public void ActualizarUsuario(Usuario u)
        {
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_MIS_DATOS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", u.idUsuario);
            cmd.Parameters.AddWithValue("@pais", u.Pais);
            cmd.Parameters.AddWithValue("@Nombre", u.Nombre);
            cmd.Parameters.AddWithValue("@apellido", u.Apellido);
            cmd.Parameters.AddWithValue("@fechanaci", u.FechaNac);
            cmd.Parameters.AddWithValue("@estadociv", u.EstadoCiv);
            cmd.Parameters.AddWithValue("@sexo", u.sexo);
            cmd.Parameters.AddWithValue("@dni", u.Dni);
            cmd.Parameters.AddWithValue("@direccion", u.Direccion);
            cmd.Parameters.AddWithValue("@celular", u.Celuar);
            cmd.Parameters.AddWithValue("@correo", u.Correo);
            cmd.Parameters.AddWithValue("@cuenta", u.Cuenta);
            cmd.Parameters.AddWithValue("@idbanco", u.Banc.idBanco);
            

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { cn.Close(); }
        }

        public void ActualizarPassword(Usuario u)
        {
            SqlConnection cn = DBAccess.getConecta();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_PASSWORD_USUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PASS", u.Password);
            cmd.Parameters.AddWithValue("@COD", u.idUsuario);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { cn.Close(); }



        }
    }

}