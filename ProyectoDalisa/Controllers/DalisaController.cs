using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoDalisa.Entity;
using ProyectoDalisa.Models;

namespace ProyectoDalisa.Controllers
{
    public class DalisaController : Controller
    {
        // GET: Dalisa
        UsuarioDAO objusu = new UsuarioDAO();
        public ActionResult Password()
        {
            return View();
        }
        public ActionResult Misdatos()
        {
            return View();
        }     
        public ActionResult loguin()
        {
            
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActualizarDatos(string idusuario =null, string @pais=null, string Nombre=null, string apellido=null,
           string fechanaci=null, string estadociv= null, string sexo=null, string dni=null,string direccion=null
          , string celular=null, string correo = null, string cuenta=null, int idbanco = 0)
        {
            
            objusu.ActualizarUsuario(new Usuario()
            {
               idUsuario=idusuario,
               Pais=pais,
               Nombre=Nombre,
               Apellido=apellido,
               FechaNac=fechanaci,
               EstadoCiv=estadociv,
               sexo=sexo,
               Dni=dni,
               Direccion=direccion,
               Celuar=celular,
               Correo=correo,
               Cuenta=cuenta,
               Banc= new Banco()
               {
                idBanco=idbanco,
               },

               
            });
            return RedirectToAction ("Dashboard");
        }


        public ActionResult ActualizarPassword( string PASS = null, string COD = null)
        {
            objusu.ActualizarUsuario(new Usuario()
            {
                idUsuario = COD,
                Password = PASS,
            });
            return RedirectToAction("Password");
        }
        
        [HttpPost]
        public ActionResult loguin(string usuario=null, string password=null)
        {
            try
            {
                Usuario use = objusu.Logueo(usuario, password);
                

                if (use != null)
                {

                    Session["use"] = use;
                    ViewBag.usuario = use.Nombre;
                    return View("Dashboard");
                }
                else
                {
                    return View("Error");
                }
                
                
            }
            catch
            {
                return RedirectToAction("loguin");
            }
        }
    }
}