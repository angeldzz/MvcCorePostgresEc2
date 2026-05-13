using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEc2.Data;
using MvcCorePostgresEc2.Models;

namespace MvcCorePostgresEc2.Repositories
{
    public class RepositoryDepartamentos
    {
        private HospitalContext context;
        public RepositoryDepartamentos(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }
        public async Task<Departamento> FindDepartamentoAsync(int idDepartamento)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == idDepartamento);
        }
        public async Task CreateDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            await this.context.Departamentos.AddAsync(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
