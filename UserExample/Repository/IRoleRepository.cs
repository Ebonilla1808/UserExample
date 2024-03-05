using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExample.Model;

namespace UserExample.Repository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role?> GetByName(string roleName);
    }
}
