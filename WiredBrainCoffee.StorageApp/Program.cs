using System;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var employeeRepository = new GenericRepositoryRemove<Employee, int>();
            employeeRepository.Key = 1;
            employeeRepository.Add(new Employee { FirstName = "Robert" });
            employeeRepository.Add(new Employee { FirstName = "Staszek" });
            employeeRepository.Add(new Employee { FirstName = "Tomek" });
            employeeRepository.Save();

            var orgRepository = new GenericRepository<Organization, Guid>();
            orgRepository.Key = new Guid();
            orgRepository.Add(new Organization { Name = "RobertCompany" });
            orgRepository.Add(new Organization { Name = "StaszekCompany" });
            orgRepository.Save();
            Console.ReadKey();
        }
    }
}