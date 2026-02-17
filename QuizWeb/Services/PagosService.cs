using QuizWeb.Interface;
using QuizWeb.Models;
using QuizWeb.Controllers;

namespace QuizWeb.Services
{
    public class PagosService : IPagosService
    {
        private static List<Pagos> listapagos = new List<Pagos>();

        public PagosService() {
            if (!listapagos.Any())
            {
                listapagos.Add(new Pagos
                {
                    Id = Guid.NewGuid(),
                    nombreUsuario = "Roberto Escobar",
                    monto = 500000,
                    fechaPago = "24/02/2026",
                    estado = "pendiente",
                    mora = "no",
                    isActive = true
                });
                listapagos.Add(new Pagos
                {
                    Id = Guid.NewGuid(),
                    nombreUsuario = "Nicolás Maduro",
                    monto = 7000000,
                    fechaPago = "01/02/2026",
                    estado = "pendiente",
                    mora = "si",
                    isActive = true
                });

            }

                }
        public List<Pagos> GetAll()
        {
            return listapagos.Where(p => p.isActive).ToList();
        }

        public Pagos GetById(Guid Id)
        {
            return listapagos.FirstOrDefault(p => p.Id == Id);
        }

        public Pagos Create(Pagos pago)
        {

            pago.Id = Guid.NewGuid();
            pago.estado = "pendiente";
            pago.isActive = true;
            listapagos.Add(pago);

            return pago;
        }
        public bool SoftDelete(Guid id)
        {
            var pago = listapagos.FirstOrDefault(p => p.Id == id);

            if (pago == null)
                return false;

            pago.isActive = false;
            pago.mora = "no";
            pago.estado = "cancelado";
            return true;
        }

        public bool Pagar(Guid id)
        {
            var pago = listapagos.FirstOrDefault(p => p.Id == id);
            var multa = pago.monto * 0.05;
            var total = pago.monto + multa;
            if (pago == null) return false;
            if (pago.isActive && pago.mora != "si")
            {
                throw new Exception("El total de pago realizado sin multa es: " + pago.monto);  //muestra el total a pagar y actualiza los campos en la lista
                
            }
            pago.mora = "no";
            pago.estado = "pagado";

            if (pago.isActive && pago.mora == "si")
            {
                throw new Exception("Se debe pagar una multa 5% por la mora, se paga un total de: " + total);
                
            }
            pago.mora = "no";
            pago.estado = "pagado";

            return true;

            
        }


    }
}
