namespace back.Extensions;

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

public static class EntityExtensions
{
    public static void Update<T>(this T target, T source, DbContext context) where T : class
    {
        var primaryKeyProperties = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;

        var foreignKeyProperties = context.Model.FindEntityType(typeof(T))
            .GetForeignKeys()
            .SelectMany(fk => fk.Properties)
            .ToList();

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            // Skip primary key properties
            if (primaryKeyProperties.Any(pk => pk.Name == property.Name))
            {
                continue;
            }

            // Skip foreign key properties
            if (foreignKeyProperties.Any(fk => fk.Name == property.Name))
            {
                continue;
            }

            // Skip properties that are collections
            if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
            {
                continue;
            }

            if (property.CanWrite)
            {
                var value = property.GetValue(source);
                property.SetValue(target, value);
            }
        }
    }
}