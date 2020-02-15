using Newtonsoft.Json;
using GalaSoft.MvvmLight;
using OpenKHS.Models.Attributes;

namespace OpenKHS.Models
{
    public abstract class ModelBase : ObservableObject, IModel
    {
        public int Id { get; set; }

        [Hidden]
        public bool IsNew => Id > 1;

        public string JsonEncode()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
