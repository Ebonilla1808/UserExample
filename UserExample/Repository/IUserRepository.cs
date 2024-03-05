using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExample.Model;

namespace UserExample.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetByRole(string roleId);
    }
}
