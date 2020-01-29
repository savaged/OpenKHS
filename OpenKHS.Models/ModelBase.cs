using Newtonsoft.Json;
using GalaSoft.MvvmLight;

namespace OpenKHS.Models
{
    public abstract class ModelBase : ObservableObject, IModel
    {
        public int Id { get; set; }

        public string JsonEncode()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
