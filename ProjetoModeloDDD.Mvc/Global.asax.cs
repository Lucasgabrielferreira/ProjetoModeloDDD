using ProjetoModeloDDD.Mvc.AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ProjetoModeloDDD.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Registra as configurações de mapeamento do AutoMapper
            AutoMapperConfig.RegisterMappings();

            // Garante que o provedor de SQL Server do Entity Framework esteja registrado
            var ensureDLLIsCopied = SqlProviderServices.Instance;
        }
    }
}
