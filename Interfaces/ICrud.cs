using Microsoft.AspNetCore.Mvc;

namespace ASP_API_EF.Interfaces
{
    public interface ICrud<T>
    {
        Task<List<T>> GetAll();

        Task<ActionResult<object>> GetById(int id);

        Task<ActionResult<object>> Create(T Model);

        Task<ActionResult<T>> Update(T Model);

        Task<ActionResult<object>> DeleteById(int id);
    }
}
