using Microsoft.AspNetCore.Identity;

namespace MiniERP.Web.Services

{
    /// <summary>
    /// Serviço responsável pela autenticação de utilizadores
    /// </summary>
    public class AuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Construtor com injeção de dependências
        /// </summary>
        public AuthService(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Método responsável por realizar login do utilizador
        /// </summary>
        
        public async Task<bool> LoginAsync(string email, string password)
        {
            // Procura utilizador pelo email
            var user = await _userManager.FindByEmailAsync(email);

            // Se não existir utilizador, retorna falso
            if (user == null)
                return false;

            // Tenta fazer login com o utilizador encontrado
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

            // Retorna se foi bem sucedido
            return result.Succeeded;
        }

        /// <summary>
        /// Faz logout do utilizador
        /// </summary>
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        /// <summary>
        /// Regista novo utilizador (opcional)
        /// </summary>
        public async Task<IdentityResult> RegisterAsync(string email, string password)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            return await _userManager.CreateAsync(user, password);
        }
    }
}

