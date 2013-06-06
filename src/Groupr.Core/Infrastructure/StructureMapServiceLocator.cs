using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Groupr.Core.Infrastructure
{
	public class StructureMapServiceLocator : ServiceLocatorImplBase
	{
		private readonly IContainer _container;

		public StructureMapServiceLocator(IContainer container)
		{
			_container = container;
		}

		protected override object DoGetInstance(Type serviceType, string key)
		{
			return _container.GetInstance(serviceType);
		}

		protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
		{
			return _container.GetAllInstances(serviceType).Cast<object>();
		}
	}
}