using preresback.Domain.IRepositories;
using preresback.Domain.IServices;
using preresback.Domain.Models;
using System.Threading.Tasks;

namespace preresback.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }
    }
}
