using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaSessionMVC.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        //Este es el punto de entrada, el "Index" http://localhost:xxxxx/
        public ActionResult Panel()
        {
            return View("/Views/Registro/Panel.cshtml");
        }

        public ActionResult Cargar()
        {
            return View("/Views/Registro/Formulario.cshtml");
        }
        /// <summary>
        /// Recibe todos los datos del formulario. Colocamos la ruta en action del form, method post
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido">La variable apellido lo toma del name del formulario</param>
        /// <param name="documento">La variable documento la toma del name del formulario</param>
        /// <returns></returns>
        public ActionResult Guardar(string nombre, string apellido, long documento)
        {
            Models.Alumno variablealumno = new Models.Alumno();
            variablealumno.Nombre = nombre;
            variablealumno.Apellido = apellido;
            variablealumno.DNI = documento;

            //Extraigo de la sesion la lista de alumnos
            List<Models.Alumno> lista = (List<Models.Alumno>)Session["listadealumnos"];
            //Verifico si la lista existe
            if (lista == null)
            {
                lista = new List<Models.Alumno>();
            }
            //A esta instancia si la lista no existia la cree y si ya existia tomo lo que tenia la session

            //Cargo el nuevo alumno en la lista
            lista.Add(variablealumno);

            //Guardo la lista en la session
            Session["listadealumnos"] = lista;

            //Retorno un mensaje de exito
            return View("/Views/Registro/Mensaje.cshtml");
        }
        public ActionResult Listar()
        {
            //Extraigo de la sesion la lista de alumnos
            List<Models.Alumno> lista = (List<Models.Alumno>)Session["listadealumnos"];

            ViewBag.Lista = lista;

            return View("/Views/Registro/Lista.cshtml");
        }
    }
}