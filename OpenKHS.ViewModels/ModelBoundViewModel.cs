using System;
using OpenKHS.Data;

namespace OpenKHS.ViewModels
{
    public abstract class ModelBoundViewModel : BaseViewModel
    {
        protected IModelService ModelService { get; }

        public ModelBoundViewModel(IModelService modelService)
        {
            ModelService = modelService ??
                throw new ArgumentNullException(nameof(modelService));
        }

    }
}