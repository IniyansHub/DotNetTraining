using Microsoft.EntityFrameworkCore;

namespace CRUD_App.Models
{
    public class AdhaarDBContext : DbContext
    {
        public AdhaarDBContext(DbContextOptions<AdhaarDBContext> options) : base(options)
        { }

        //Create Table here
        public DbSet<AdhaarModel> adhaar { get; set; }
    }
}
