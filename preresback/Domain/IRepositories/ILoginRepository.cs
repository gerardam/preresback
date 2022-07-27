using preresback.Domain.Models;
using System.Threading.Tasks;

namespace preresback.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
