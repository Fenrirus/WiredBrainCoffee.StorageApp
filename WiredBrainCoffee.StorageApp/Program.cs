using System;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    public class Program
    {
        private static void AddEmlpoyee(IRepository<Employee> employeeRepository)
        {
            //employeeRepository.Key = 1;
            var employees = new[]
            {
                 new Employee { FirstName = "Robert" },
                new Employee { FirstName = "Staszek" },
                new Employee { FirstName = "Tomek" }
            };
            //metoda rozszerzalna
            employeeRepository.AddBatch(employees);
            //RepositoryExtensions.AddBatch(employeeRepository, employees);
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var item = new Manager { FirstName = "Krzysztof" };
            var itemCopy = item.Copy();
            managerRepository.Add(item);

            if (itemCopy != null)
            {
                itemCopy.FirstName += " _copy";
                managerRepository.Add(itemCopy);
            }
            managerRepository.Add(item);

            managerRepository.Add(new Manager { FirstName = "Kazik" });
            managerRepository.Save();
        }

        private static void AddOrganization(IRepository<Organization> orgRepository)
        {
            var organizations = new[]
            {
                 new Organization { Name = "RobertCompany" },
                 new Organization { Name = "StaszekCompany" },
            };
            RepositoryExtensions.AddBatch(orgRepository, organizations);
            //orgRepositor.Key = new Guid();
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