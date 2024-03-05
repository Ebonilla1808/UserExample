using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExample.Model;
using UserExample.Repository;

namespace UserExample.Data.Repository.SqlServer
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserExampleContext _db;

        public RoleRepository(UserExampleContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Role enity)
        {
            await _db.Roles.AddAsync(enity);
        }

        public  void DeleteAsync(Role entity)
        {
            _db.Remove(entity);
        }

        public async Task<List<Role>> GetAll()
        {
            return await _db.Roles.ToListAsync();
        }

        public async Task<Role?> GetById(string id)
        {
            return await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role?> GetByName(string roleName)
        {
            return await _db.Roles.FirstOrDefaultAsync(x => x.RoleName == roleName);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
