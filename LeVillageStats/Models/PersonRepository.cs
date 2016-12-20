using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeVillageStats.Models
{
    public class PersonRepository : IPersonRepository
    {
        PHOEBEEntities phoebe;

        public PersonRepository(PHOEBEEntities _phoebe) {

            phoebe = _phoebe;
        }

        public IEnumerable<Person> GetAllPerson()
        {
            return phoebe.People.ToList();
        }

        public IEnumerable<Person> GetAllPersonWithCity()
        {
            var query = (from p in phoebe.People
                         join nb in phoebe.NeighborHoods on p.neighborhood equals nb.idNeighborHood
                         join c in phoebe.Cities on nb.City equals c.idCity
                         select new { p.firstName, p.lastName, p.gender, p.baptise, p.address, p.telephone, p.email, p.age, nb.neighborhoodName, c.cityName} ).ToList().Cast<Person>();
            return query;
        }


        public int FemalebreakDown() {

            int femaleNumber = phoebe.People.Where(p => p.gender == "Female").Count();
            return femaleNumber / TotalPeople();
        }


        public int MalebreakDown()
        {
            var maleNumber = phoebe.People.Where(p => p.gender == "Male").Count();
            return maleNumber / TotalPeople();

        }

        private int TotalPeople() {

            return phoebe.People.Count();
        }


        public int BaptizedPeople() {

            var baptized = phoebe.People.Where(p => p.baptise == "oui").Count();
            return baptized / TotalPeople();
        }

        public int NotBaptizedPeople()
        {

            var notbaptized = phoebe.People.Where(p => p.baptise == "oui").Count();
            return notbaptized / TotalPeople();
        }


        public void PeopleInCity()
        {
            throw new NotSupportedException();
        }



    }
}