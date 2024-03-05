using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExample.Model
{
    public class Role
    {
        public Role()
        {
        }

        public Role(string roleName, string? description, PermissionType permissionType)
        {
            RoleName = roleName;
            Description = description;
            PermissionType = permissionType;
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }  
        public string RoleName { get; set; }

        public string? Description { get; set; }

        public PermissionType PermissionType { get; set; }
    }
}
