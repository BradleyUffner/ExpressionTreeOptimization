using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeOptimization.EntityFrameworkStuff
{
    class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsEnabled { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
