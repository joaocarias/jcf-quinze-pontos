using Jcf.QuinzePontos.Identidade.Models;

namespace Jcf.QuinzePontos.Identidade.Repositorio
{
    public static class UserRepositorio
    {
        public static UserApp Get(string userName, string password)
        {
            var users = new List<UserApp>
            {
                new() { Id = 1, UserName = "batman", Password = "batman", Role = "manager" },
                new() { Id = 2, UserName = "robin", Password = "robin", Role = "employee" }
            };

            return users
                .FirstOrDefault(x =>
                     string.Equals(x.UserName, userName, StringComparison.CurrentCultureIgnoreCase)
                        && x.Password.Equals(password));
        }
    }
}
