using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Medicamento
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioPrueba2Context context = new DL.EignacioPrueba2Context())
                {
                    var query = context.Medicamentos.FromSqlRaw("MedicamentoGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Medicamento medicamento = new ML.Medicamento();

                            medicamento.IdMedicamento = obj.IdMedicamentos;
                            medicamento.Nombre = obj.NombreMedicamento;
                            medicamento.Descripcion = obj.Descripcion;
                            medicamento.FechaCaducidad = obj.FechaCaducidad;
                            medicamento.PrecioUnitario = (int)obj.PrecioUnitario;
                            medicamento.Stock = (int)obj.Stock;
                            medicamento.Proveedor = new ML.Proveedor();
                            medicamento.Proveedor.IdProveedor = (int)obj.IdProveedor;
                            medicamento.Proveedor.Nombre = obj.NombreProveedor;
                            result.Objects.Add(medicamento);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
            }
            return result;
        }


        public static ML.Result Add(ML.Medicamento medicamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioPrueba2Context context = new DL.EignacioPrueba2Context())
                {
                    var query = context.Database.ExecuteSqlRaw($"MedicamentosAdd '{medicamento.Nombre}', '{medicamento.Descripcion}', '{medicamento.FechaCaducidad}', {medicamento.PrecioUnitario}, {medicamento.Stock},{medicamento.Proveedor.IdProveedor} ");

                    result.Objects = new List<object>();
                    if (query >0)
                    {
                        result.Message = "Se agregaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
    }
}



//var query = context.Medicamentos.FromSqlRaw($"UsuarioGetById {iD}").AsEnumerable().FirstOrDefault();