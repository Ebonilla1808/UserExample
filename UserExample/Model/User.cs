using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExample.Model
{
    public class User
    {
        public User()
        {
        }

        public User(NameVo nane, ContactInformationVo contactInformation, AddressVo address, string userName, string roleId)
        {
            Name = nane;
            ContactInformation = contactInformation;
            Address = address;
            UserName = userName;
            RoleId = roleId;
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public NameVo Name { get; set; }

        public ContactInformationVo ContactInformation { get; set; }

        public AddressVo Address { get; set; }

        public string UserName { get; set; }

        public string RoleId { get; set; }
    }
}
