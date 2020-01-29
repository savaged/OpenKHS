using System;
using OpenKHS.Data;

namespace OpenKHS.CLI.Modules
{
    public class MainModule : BaseModule
    {
        private readonly LocalCongregationAdmin _localCongregationAdmin;

        public MainModule(
            IFeedbackService feedbackService,
            IDbContextFactory dbContextFactory,
            LocalCongregationAdmin localCongregationAdmin)
            : base(feedbackService, dbContextFactory)
        {
            _localCongregationAdmin = localCongregationAdmin ??
                throw new ArgumentNullException(nameof(localCongregationAdmin));
        }

        public override void Load()
        {
            _localCongregationAdmin.Load();
            // TODO more modules based on events??
        }
    }
}