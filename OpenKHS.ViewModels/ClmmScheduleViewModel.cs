using OpenKHS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenKHS.ViewModels
{
    public class ClmmScheduleViewModel : ViewModelBase
    {
        private readonly IDataGateway _dataGateway;

        public ClmmScheduleViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }
    }
}
