using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEc2.Models;

namespace MvcCorePostgresEc2.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> context): base(context)
        {
        }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
