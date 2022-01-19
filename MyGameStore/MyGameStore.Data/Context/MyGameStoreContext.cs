using Microsoft.EntityFrameworkCore;
using MyGameStore.Data.Configuration;
using MyGameStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Data.Context
{
    public class MyGameStoreContext : DbContext
    {
        public MyGameStoreContext(DbContextOptions<MyGameStoreContext> dbContextOptions) : base(dbContextOptions){}
        public DbSet<Store> Stores { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new StoreConfiguration());

            for (int i = 1; i <= 20; i++)
            {
                builder.Entity<Store>().HasData(new Store() { Id = i, Name = Faker.Name.First(), Street = Faker.Address.StreetName(), Number = Faker.RandomNumber.Next(1, 100).ToString(), Zipcode = Faker.RandomNumber.Next(1, 3000).ToString(), City = Faker.Address.City(), IsFranchiseStore = Faker.Boolean.Random() });
            }

            for (int i = 1; i <= 10; i++)
            {
                builder.Entity<Person>().HasData(new Person() { Id = i, FirstName = Faker.Name.First(), LastName = Faker.Name.Last(), Gender = 1, Email = Faker.Internet.Email(), StoreId = 2 });
            }

           
        }

    }
}
