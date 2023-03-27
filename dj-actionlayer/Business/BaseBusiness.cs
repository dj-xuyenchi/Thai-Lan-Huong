using dj_actionlayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_actionlayer.Business
{
    public class BaseBusiness
    {
        public DAO.AppContext _context { get; set; }
        public BaseBusiness()
        {
            _context = new DAO.AppContext();
        }
    }
}
