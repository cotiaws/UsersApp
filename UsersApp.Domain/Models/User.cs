using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Enums;

namespace UsersApp.Domain.Models
{
    public class User
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Status? Status { get; set; }
        public Guid? RoleId { get; set; }

        #endregion

        #region Relacionamentos

        public Role? Role { get; set; }

        #endregion
    }
}
