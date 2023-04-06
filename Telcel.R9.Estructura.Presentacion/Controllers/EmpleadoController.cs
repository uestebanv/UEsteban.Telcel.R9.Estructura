using Celeste.R9.Estructura.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult GetAll()
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = "";
            Result result = Empleado.GetAll(empleado);
            Result resultPuesto = Puesto.GetAll();
            Result resultDepartamento = Departamento.GetAll();

            
            empleado.Puesto = new Puesto();
            empleado.Departamento = new Departamento();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                empleado.Puesto.Puestos = resultPuesto.Objects;
                empleado.Departamento.Departamentos = resultDepartamento.Objects;
                return View(empleado);
            }else
            {
                return View(empleado);
            }
        }

        [HttpPost]
        public ActionResult GetAll(Empleado empleado)
        {
            Result result = Empleado.GetAll(empleado);
            Result resultPuesto = Puesto.GetAll();
            Result resultDepartamento = Departamento.GetAll();


            empleado.Puesto = new Puesto();
            empleado.Departamento = new Departamento();


            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                empleado.Puesto.Puestos = resultPuesto.Objects;
                empleado.Departamento.Departamentos = resultDepartamento.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }


        public ActionResult From(Empleado empleado)
        {
            
            if (empleado.EmpleadoID == 0)
            {
                Result result = Empleado.Add(empleado);
                
                if(result.Correct)
                {
                    ViewBag.Message = "Se inserto el regsitro";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar los registros";
                    return View("Modal");
                }
            }
            return View(empleado);
        }


        [HttpGet]
        public ActionResult Delete(int EmpleadoID)
        {

            Result result = new Result();

            result = Empleado.Delete(EmpleadoID);
            //return View("GetAll", result);

            if(result.Correct)
            {
                ViewBag.Message = "Se elimino el registro";
                return View("Modal");
            }
            else
            {
                ViewBag.Message = "No se Elimino el registro";
                return View("Modal");
            }
        }

    }
}