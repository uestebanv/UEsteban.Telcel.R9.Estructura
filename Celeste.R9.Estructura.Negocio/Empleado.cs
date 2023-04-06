using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telcel.R9.Estructura.AccesoDatos;

namespace Celeste.R9.Estructura.Negocio
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public List<object> Empleados { get; set; }
        public Departamento Departamento { get; set; }
        public Puesto Puesto { get; set; }

        public static Result Add(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (UEstebanEstructuraEntities context = new UEstebanEstructuraEntities())
                {
                    var query = context.EmpleadoAdd(empleado.Nombre, empleado.Puesto.PuestoID, empleado.Departamento.DepartamentoID);

                    if (query >= 1)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Result Delete(int empleadoID)
        {
            Result result = new Result();
            try
            {
                using (UEstebanEstructuraEntities context = new UEstebanEstructuraEntities())
                {
                    var query = context.EmpleadoDelete(empleadoID);

                    if (query >= 1)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al eliminar el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Result GetAll(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using(UEstebanEstructuraEntities context = new UEstebanEstructuraEntities())
                {
                    var query = context.EmpleadoSearch(empleado.Nombre).ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var Item in query)
                        {
                            empleado= new Empleado();

                            empleado.EmpleadoID = Item.EmpleadoID;
                            empleado.Nombre= Item.Nombre;
                            empleado.Departamento = new Departamento(); 
                            empleado.Departamento.DepartamentoID = Item.DepartamentoID;
                            empleado.Departamento.Descripcion = Item.NombreDepartamento;
                            empleado.Puesto = new Puesto();
                            empleado.Puesto.PuestoID= Item.PuestoID;
                            empleado.Puesto.Descripcion = Item.NombrePuesto;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
