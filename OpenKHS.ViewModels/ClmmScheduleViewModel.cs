using OpenKHS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ViewModelBase, IDataViewModel
    {
        private readonly IDataGateway _dataGateway;

        public ClmmScheduleViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public bool New()
        {
            throw new NotImplementedException();
        }
    }
}
