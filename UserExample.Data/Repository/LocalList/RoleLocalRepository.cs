using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExample.Model;
using UserExample.Repository;

namespace UserExample.Data.Repository.LocalList
{
    using System.IO;
    using System.Text.Json;

    public class RoleLocalRepository 
    {
        private readonly ILogger<RoleLocalRepository> _logger;
        private List<Role> _roles;
        private string _filePath;

        public RoleLocalRepository(string filePath, List<Role> roles, ILogger<RoleLocalRepository> logger)
        {
            _filePath = filePath;
            _roles = roles;
            _logger = logger;
        }

        public async Task SaveChangesAsync()
        {
            var json = JsonSerializer.Serialize(_roles);
            await File.WriteAllTextAsync(_filePath, json);
            _logger.LogInformation("Cambios guardados");
        }
    }

}
