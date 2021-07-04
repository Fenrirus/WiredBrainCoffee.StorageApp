using System.Text.Json;

namespace WiredBrainCoffee.StorageApp.Entities
{
    public static class EntityExtension
    {
        public static T? Copy<T>(this T item) where T : IEntityBase
        {
            var json = JsonSerializer.Serialize(item);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}