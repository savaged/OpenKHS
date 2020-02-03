using Ninject.Modules;

namespace OpenKHS.Lookups
{
    public class LookupsCoreBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAssignmentTypeService>().To<AssignmentTypeService>()
                .InSingletonScope();
            Bind<IAssigneeService>().To<AssigneeService>()
                .InSingletonScope();
        }
    }
}