using System;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    internal class Program
    {
        private static void AddEmlpoyee(IRepository<Employee> employeeRepository)
        {
            //employeeRepository.Key = 1;
            employeeRepository.Add(new Employee { FirstName = "Robert" });
            employeeRepository.Add(new Employee { FirstName = "Staszek" });
            employeeRepository.Add(new Employee { FirstName = "Tomek" });
            employeeRepository.Save();
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { FirstName = "Krzysztof" });
            managerRepository.Add(new Manager { FirstName = "Kazik" });
            managerRepository.Save();
        }

        private static void AddOrganization(IRepository<Organization> orgRepository)
        {
            //orgRepositor.Key = new Guid();
            orgRepository.Add(new Organization { Name = "RobertCompany" });
            orgRepository.Add(new Organization { Name = "StaszekCompany" });
            orgRepository.Save();
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee by id 2 is {employee.FirstName}");
        }

        private static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee, int>(new StorageAppDbContext());
            AddEmlpoyee(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var orgRepository = new ListRepository<Organization, Guid>();
            AddOrganization(orgRepository);
            WriteAllToConsole(orgRepository);
            Console.ReadKey();
        }

        private static void WriteAllToConsole(IReadRepository<IEntityBase> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}