using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenKHS.Models.Utils
{
    public static class ModelEx
    {
        public static IList<string> GetPropertyNames(this IModel model)
        {
            var props = model.GetType().GetProperties(
                BindingFlags.Public);
            var list = props.Select(p => p.Name).ToList();
            return list;
        }

        public static bool IsNew(this IModel? model)
        {
            return model?.Id > 0;
        }
    }
}