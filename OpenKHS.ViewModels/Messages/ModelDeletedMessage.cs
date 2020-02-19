using GalaSoft.MvvmLight.Messaging;
using OpenKHS.Models;

namespace OpenKHS.ViewModels.Messages
{
    public class ModelDeletedMessage<T> : MessageBase
        where T : IModel
    {
        public ModelDeletedMessage(
            object sender, 
            int modelId)
        {
            Sender = sender;
            ModelId = modelId;
        }

        public int ModelId { get; }

    }
}