namespace Persistance
{
    public class DbInitialize
    {
        public static void Initialize(ApplicationDbContext context) =>
            context.Database.EnsureCreated();
    }
}
