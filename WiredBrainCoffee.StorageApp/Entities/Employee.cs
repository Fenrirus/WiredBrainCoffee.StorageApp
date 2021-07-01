namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Employee
    {
        public string? FirstName { get; set; }
        public int Id { get; set; }

        public override string ToString() => $"Id = {Id}, FirstName = {FirstName}";
    }
}