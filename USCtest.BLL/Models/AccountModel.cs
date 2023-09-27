using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USCtest.BLL.Models
{
    internal class AccountModel
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public UserProfileModel UserProfile { get; set; }
    }
}
