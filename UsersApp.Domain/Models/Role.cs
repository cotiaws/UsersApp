using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Domain.Models
{
    public class Role
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Name { get; set; }

        #endregion

        #region Relacionamentos

        public ICollection<User>? Users { get; set; }

        #endregion
    }
}
