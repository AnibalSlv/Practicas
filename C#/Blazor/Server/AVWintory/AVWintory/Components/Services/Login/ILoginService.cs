using AVWintory.ModulesDb;

namespace AVWintory.Components.Services.Login;

public interface ILoginService
{
    List<User> GetUser();
    Task AddUser(User user);
    Task DeleteUser(User user);
}