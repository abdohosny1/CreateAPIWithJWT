


namespace TTechTack.Data
{
    public class ApplicationDBContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
                  : base(options)
        {
        }

        public virtual DbSet<Employee>  Employees{ get; set; }
    }
}
