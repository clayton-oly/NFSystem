using Microsoft.EntityFrameworkCore;

namespace FaturamentoService.Data
{
    public class FaturamentoServiceDbContext : DbContext
    {
        public FaturamentoServiceDbContext(DbContextOptions<FaturamentoServiceDbContext> options) : base(options) { }
    }
}
