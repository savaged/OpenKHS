using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenKHS.Models;

namespace OpenKHS.Data.StaticData
{
    public static class DbSeedData
    {
        public static AssignmentType[] GetAssignmentTypes()
        {
            var index = new List<AssignmentType>();
            var props = typeof(Assignee).GetProperties(
                BindingFlags.Public | BindingFlags.Instance);
            var boolProps = props
                .Where(p => p.PropertyType.Name == typeof(bool).Name);
            var names = boolProps.Select(p => p.Name);
            foreach (var name in names)
            {
                index.Add(new AssignmentType { Name = name });
            }
            return index.ToArray();
        }
    }
}