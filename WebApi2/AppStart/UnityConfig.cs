using System.Web.Http;
using Unity;
using Unity.Lifetime;
using WebApi2.Repository;

namespace WebApi2
{
    //Используем Di и регистрируем типы
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();          
            //container.RegisterType<IRepository, TestRepository>();
            container.RegisterType<IRepository, RepositoryEF>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}