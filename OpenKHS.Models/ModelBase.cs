using Newtonsoft.Json;
using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenKHS.Models
{
    public abstract class ModelBase : ObservableObject, IModel
    {
        public int Id { get; set; }

        [NotMapped]
        public bool IsNew => Id < 1;

        [NotMapped]
        public bool IsDirty { get; private set; }

        public string JsonEncode()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
