using preresback.Domain.Models;
using System.Threading.Tasks;

namespace preresback.Domain.IServices
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
