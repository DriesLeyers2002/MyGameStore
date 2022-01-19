using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Data.Model
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public bool IsFranchiseStore { get; set; }

        public List<Person> people = new List<Person>();

        public Store(int id, string name, string street, string number, string addition, string zipcode, string city, bool isFranchiseStore, List<Person> persons)
        {
            Id = id;
            Name = name;
            Street = street;
            Number = number;
            Addition = addition;
            Zipcode = zipcode;
            City = city;
            IsFranchiseStore = isFranchiseStore;
            this.people = persons;
        }

        public Store(int id, string name, string street, string number, string zipcode, string city, bool isFranchiseStore, List<Person> persons)
        {
            Id = id;
            Name = name;
            Street = street;
            Number = number;
            Zipcode = zipcode;
            City = city;
            IsFranchiseStore = isFranchiseStore;
            this.people = persons;
        }

        public Store() { }
    }
}
