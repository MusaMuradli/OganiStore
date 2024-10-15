using Microsoft.EntityFrameworkCore;

namespace Ogani.DAL.DataContext
{
    public class DataInitalizer
    {
        private readonly AppDbContext _appDbContext;

        public DataInitalizer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task SeedDataAsync()
        {
            await _appDbContext.Database.MigrateAsync();
        }
    }
}
