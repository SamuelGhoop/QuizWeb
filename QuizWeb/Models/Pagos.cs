using System.ComponentModel.DataAnnotations;

namespace QuizWeb.Models
{
    public class Pagos
    {
        public Guid Id { get; set; }
        public string nombreUsuario {  get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe ser mayor que 0")]
        public float monto { get; set; }

        public string fechaPago {  get; set; }

        public string estado {  get; set; } //pendiente-pagado-cancelado

        public string mora {  get; set; } //si-no
        public bool isActive { get; set; }

    }
}
