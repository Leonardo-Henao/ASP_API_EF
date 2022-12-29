using Azure;
using Microsoft.AspNetCore.Mvc;

namespace ASP_API_EF.Interfaces
{
    public interface ICrud<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Create(T Model);

        Task<T> Update(T Model);

        Task<T> DeleteById(int id);
    }
}
