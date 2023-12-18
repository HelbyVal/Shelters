using ClientShelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Controllers
{
    internal interface IController
    {
        public (List<IMyModel>, int) GetEntities(User user, int pageSize, int lastId);
        public void CancelFilters();
        public bool DeleteEntity(User user, int id);
        public bool UpdateEntity(User user, IMyModel entity);
    }
}
