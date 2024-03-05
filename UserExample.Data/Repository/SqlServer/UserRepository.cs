using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExample.Model;
using UserExample.Repository;

namespace UserExample.Data.Repository.SqlServer
{
    public class UserRepository : IUserRepository
    {
        private readonly UserExampleContext _db;

        public UserRepository(UserExampleContext db)
        {
            _db = db;
        }

        public async Task AddAsync(User enity)
        {
            await _db.Users.AddAsync(enity);
        }

        public void DeleteAsync(User entity)
        {
            _db.Users.Remove(entity);
        }

        public async Task<List<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetById(string id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetByRole(string roleId)
        {
            return await _db.Users.Where(x => x.RoleId == roleId).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
