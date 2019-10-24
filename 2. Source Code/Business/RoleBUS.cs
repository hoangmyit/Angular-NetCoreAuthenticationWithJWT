using Business.Interface;
using DataAccess.Interface;
using DataTransfer;
using Entity;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class RoleBUS : IRoleBUS
    {
        private readonly IBaseDAO<Role> _roleDAO;
        public RoleBUS(IBaseDAO<Role> _roleDAO)
        {
            this._roleDAO = _roleDAO;
        }
        public List<RoleDTO> GetRoles()
        {
            return _roleDAO.GetAll().Select(x => new RoleDTO(x)).ToList();
        }
    }
}
