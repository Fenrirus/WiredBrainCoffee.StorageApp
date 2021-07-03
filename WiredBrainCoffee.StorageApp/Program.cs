using System;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    internal class Program
    {
        private static void AddEmlpoyee(GenericRepository<Employee, int> employeeRepository)
        {
            employeeRepository.Key = 1;
            employeeRepository.Add(new Employee { FirstName = "Robert" });
            employeeRepository.Add(new Employee { FirstName = "Staszek" });
            employeeRepository.Add(new Employee { FirstName = "Tomek" });
            employeeRepository.Save();
        }

        private static void AddOrganization(GenericRepository<Organization, Guid> orgRepository)
        {
            orgRepository.Key = new Guid();
            orgRepository.Add(new Organization { Name = "RobertCompany" });
            orgRepository.Add(new Organization { Name = "StaszekCompany" });
            orgRepository.Save();
        }

        private static void GetEmployeeById(GenericRepository<Employee, int> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee by id 2 is {employee.FirstName}");
        }

        private static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee, int>();
            AddEmlpoyee(employeeRepository);
            GetEmployeeById(employeeRepository);

            var orgRepository = new GenericRepository<Organization, Guid>();
            AddOrganization(orgRepository);
            Console.ReadKey();
        }
    }
}