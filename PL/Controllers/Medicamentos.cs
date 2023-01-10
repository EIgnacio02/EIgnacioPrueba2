using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class Medicamentos : Controller
    {
        public IActionResult GetAll()
        {
            ML.Medicamento medicamento = new ML.Medicamento();
            ML.Result result = BL.Medicamento.GetAll();
            if (result.Correct)
            {
                medicamento.MedicamentosList = result.Objects;
                return View(medicamento);
            }
            else
            {
                return View();
            }
        }


        public IActionResult Form(int? IdMedicamento)
        {
            ML.Medicamento medicamento = new ML.Medicamento();
            ML.Result result = new ML.Result();
            ML.Result resultProveedor = BL.Proveedor.GetAll();
            medicamento.Proveedor = new ML.Proveedor();
            result.Objects = new List<object>();
            if (IdMedicamento == null)
            {
                medicamento.Proveedor.ProveedorList = resultProveedor.Objects;
                return View(medicamento);

            }
            return View();
        }
    }
}
