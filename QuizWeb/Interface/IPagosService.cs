using QuizWeb.Models;

namespace QuizWeb.Interface
{
    public interface IPagosService
    {
        List<Pagos> GetAll();

        Pagos GetById(Guid Id);

        Pagos Create(Pagos pagos);

        bool SoftDelete(Guid Id);

        bool Pagar(Guid Id);


    }
}
