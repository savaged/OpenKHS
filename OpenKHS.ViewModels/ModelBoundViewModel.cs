using System;
using OpenKHS.Data;
using Savaged.BusyStateManager;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModel : BaseViewModel
    {
        protected IModelService ModelService { get; }

        public ModelBoundViewModel(
            IBusyStateRegistry busyStateManager,
            IModelService modelService)
            : base(busyStateManager)
        {
            ModelService = modelService ??
                throw new ArgumentNullException(nameof(modelService));
        }

    }
}