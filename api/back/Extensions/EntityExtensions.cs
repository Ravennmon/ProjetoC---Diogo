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
        var entityType = context.Model.FindEntityType(typeof(T));
        if (entityType == null) throw new InvalidOperationException($"Entidade {typeof(T)} não encontrada.");

        var primaryKey = entityType.FindPrimaryKey();
        if (primaryKey == null) throw new InvalidOperationException($"PK da entidade {typeof(T)} não encontrada.");

        var primaryKeyProperties = primaryKey.Properties;

        var foreignKeyProperties = entityType
            .GetForeignKeys()
            .SelectMany(fk => fk.Properties)
            .ToList();

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            if (primaryKeyProperties.Any(pk => pk.Name == property.Name))
            {
                continue;
            }

            if (foreignKeyProperties.Any(fk => fk.Name == property.Name))
            {
                continue;
            }

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