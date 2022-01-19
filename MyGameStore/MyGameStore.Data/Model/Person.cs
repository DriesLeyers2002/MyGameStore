using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Data.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public Person(int id, string lastName, string firstName, int gender, string email, int storeId)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Gender = gender;
            this.Email = email;
            this.StoreId = storeId;
        }

        public Person() { }
    }
}
