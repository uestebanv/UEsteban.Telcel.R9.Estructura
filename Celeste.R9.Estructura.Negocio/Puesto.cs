using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telcel.R9.Estructura.AccesoDatos;

namespace Celeste.R9.Estructura.Negocio
{
    public class Puesto
    {
        public int PuestoID { get; set; }
        public string Descripcion { get; set; }
        public List<object> Puestos { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();

            try
            {
                using(UEstebanEstructuraEntities context = new UEstebanEstructuraEntities())
                {
                    var query = context.PuestoGetAll().ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            Puesto puesto = new Puesto();

                            puesto.PuestoID = item.PuestoID;
                            puesto.Descripcion = item.Descripcion;

                            result.Objects.Add(puesto);
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
