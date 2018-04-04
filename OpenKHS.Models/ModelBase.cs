using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using OpenKHS.Models.Attributes;
using OpenKHS.Interfaces;

namespace OpenKHS.Models
{
    public abstract class ModelBase : IModel
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return JsonEncode();
        }

        public string JsonEncode()
        {
            return JsonConvert.SerializeObject(this);
        }

        public IDictionary<string, object> GetData(bool withDisplayNames = false)
        {
            var data = new Dictionary<string, object>();
            var type = GetType();
            foreach (var p in type.GetProperties())
            {
                var key = p.Name;
                
                if (!Attribute.IsDefined(p, typeof(HiddenAttribute)))
                {
                    if (withDisplayNames)
                    {
                        if (Attribute.IsDefined(p, typeof(DisplayNameAttribute)))
                        {
                            var attrib = (DisplayNameAttribute)Attribute.GetCustomAttribute(
                                p, typeof(DisplayNameAttribute));
                            key = attrib.DisplayName;
                        }
                    }
                    data.Add(key, p.GetValue(this));
                }
            }
            return data;
        }
    }
}
