using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Entities;
using PersonApplicationDll.Managers;

namespace PersonApplicationDll
{
    public class DllFacade
    {
        public IServiceGateway<Person> GetPersonManager()
        {
            return new PersonManager();
        }

        public IServiceGateway<PersonStatus> GetPersonStatusManager()
        {
           return new PersonStatusManager();
        }

        public IServiceGateway<Wish> GetWishManager()
        {
            //return new WishManager();
            return new WishServiceGateway();
        }
    }
}
