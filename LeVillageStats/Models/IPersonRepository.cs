using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeVillageStats.Models
{
    interface IPersonRepository
    {
        IEnumerable<Person> GetAllPerson();
        IEnumerable<Person> GetAllPersonWithCity();

    }
}
