namespace AVWintory.Components.Services.Login;
using AVWintory.ModulesDb;
using Microsoft.EntityFrameworkCore;

public class LoginService : ILoginService
{
    
    private readonly IDbContextFactory <AVContext> _dbFactory;

    public LoginService(IDbContextFactory<AVContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }
    
    private List<User> UserList { get; set; } = new ();

    public List<User> GetUser()
    {
        var context = _dbFactory.CreateDbContext();
        return context.Users.ToList();
    }

    public async Task AddUser(User user)
    {
        var context = _dbFactory.CreateDbContext();
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteUser(User user)
    {
        var context = _dbFactory.CreateDbContext();
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}