using GalaSoft.MvvmLight.Messaging;
using OpenKHS.Models;

namespace OpenKHS.ViewModels.Messages
{
    public class ModelSavedMessage<T> : MessageBase
        where T : IModel
    {
        public ModelSavedMessage(
            object sender, 
            int modelId,
            bool isAddition)
        {
            Sender = sender;
            ModelId = modelId;
            IsAddition = isAddition;
        }

        public int ModelId { get; }

        public bool IsAddition { get; }

    }
}