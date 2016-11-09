using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poppel.Models;

namespace Poppel.Models.BusinessModel
{
    public abstract class ServiceManager
    {
       protected PoppelDBEntities db = new PoppelDBEntities();
        public ServiceManager()
        {
           
        }

    }
}
