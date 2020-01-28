using System;

namespace OpenKHS.CLI.Modules
{
    public class Main : IModule
    {
        private readonly LocalCongregationAdmin _localCongregationAdmin;

        public Main(LocalCongregationAdmin localCongregationAdmin)
        {
            _localCongregationAdmin = localCongregationAdmin ??
                throw new ArgumentNullException(nameof(localCongregationAdmin));
        }

        public void Load()
        {
            _localCongregationAdmin.Load();
            // TODO more modules based on events??
        }
    }
}