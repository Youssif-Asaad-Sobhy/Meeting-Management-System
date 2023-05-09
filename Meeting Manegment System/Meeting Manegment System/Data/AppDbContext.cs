using Microsoft.EntityFrameworkCore;

namespace Meeting_Manegment_System.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

    }
}
