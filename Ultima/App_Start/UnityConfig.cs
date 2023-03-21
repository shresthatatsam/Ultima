using System.Web.Mvc;
using Ultima.Models;
using Ultima.Models.Interface;
using Unity;
using Unity.Mvc5;

namespace Ultima
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();
			
			// register all your components with the container here
			// it is NOT necessary to register your controllers
			
		   container.RegisterType<ICart, Cart>();
			
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}