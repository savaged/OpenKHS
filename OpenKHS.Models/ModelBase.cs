using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

using GalaSoft.MvvmLight;

using Newtonsoft.Json;

using OpenKHS.Interfaces;
using OpenKHS.Models.Attributes;

namespace OpenKHS.Models
{
    public abstract class ModelBase : ObservableObject, IModel
    {
        private string _name;

        public int Id { get; set; }

        [NotMapped]
        public bool IsNew => Id < 1;

        public virtual string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        [NotMapped]
        public bool IsDirty { get; private set; }

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
