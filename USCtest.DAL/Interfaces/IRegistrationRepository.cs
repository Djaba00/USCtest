using System.Threading.Tasks;
using USCtest.DAL.Entities;

namespace USCtest.DAL.Interfaces
{
    public interface IRegistrationRepository<T>
    {
        Task CreateRegistrationAsync(T registration);
        Task UpdateRegistrtionAsync(T registration);
        Task DeleteRegistrationAsync(T registration);
    }
}
