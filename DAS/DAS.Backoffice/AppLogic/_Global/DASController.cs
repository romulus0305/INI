using DAS.Domain.Model;

namespace DAS.Backoffice.AppLogic._Global
{
    public class DASController : IniCore.Web.Mvc.IniController
    {
        private DASEntities db = new DASEntities();

        protected DASEntities Db { get { return db; } }
    }
}
