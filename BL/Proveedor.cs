using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioPrueba2Context context = new DL.EignacioPrueba2Context())
                {
                    var query = context.Proveedors.FromSqlRaw("ProveedorGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();

                            proveedor.IdProveedor = obj.IdProveedor;
                            proveedor.Nombre = obj.NombreProveedor;
                            result.Objects.Add(proveedor);
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
    }
}
