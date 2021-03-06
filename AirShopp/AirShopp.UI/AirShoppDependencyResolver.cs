﻿using AirShopp.DataAccess;
using AirShopp.Domain;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AirShopp.UI.Models
{
    public class AirShoppDependencyResolver : IDependencyResolver
    {
        private const string HttpContextKey = "perRequestContainer";
        private readonly IUnityContainer container;
        public AirShoppDependencyResolver()
        {
            this.container = BuildAndInitContainer();
        }
        public object GetService(Type serviceType)
        {
            if (typeof(IController).IsAssignableFrom(serviceType))
            {
                return ChildContainer.Resolve(serviceType);
            }
            return IsRegistered(serviceType) ? ChildContainer.Resolve(serviceType) : null;
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (IsRegistered(serviceType))
            {
                yield return ChildContainer.Resolve(serviceType);
            }
            foreach (var service in ChildContainer.ResolveAll(serviceType))
            {
                yield return service;
            }
        }
        protected IUnityContainer ChildContainer
        {
            get
            {
                var childContainer = HttpContext.Current.Items[HttpContextKey] as IUnityContainer;
                if (childContainer == null)
                {
                    HttpContext.Current.Items[HttpContextKey] = childContainer = container.CreateChildContainer();
                }
                return childContainer;
            }
        }
        public static void DisposeOfChildContainer()
        {
            var childContainer = HttpContext.Current.Items[HttpContextKey] as IUnityContainer;
            if (childContainer != null)
            {
                childContainer.Dispose();
            }
        }
        private bool IsRegistered(Type typeToCheck)
        {
            var isRegistered = true;
            if (typeToCheck.IsInterface || typeToCheck.IsAbstract)
            {
                isRegistered = ChildContainer.IsRegistered(typeToCheck);
                if (!isRegistered && typeToCheck.IsGenericType)
                {
                    var openGenericType = typeToCheck.GetGenericTypeDefinition();
                    isRegistered = ChildContainer.IsRegistered(openGenericType);
                }
            }
            return isRegistered;
        }
        private IUnityContainer BuildAndInitContainer()
        {
            var container = new UnityContainer();
            //Services
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<IOrderservice, Orderservice>();
            container.RegisterType<ICommentService, CommentService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IDeliveryStationService, DeliveryStationService>();
            container.RegisterType<IDeliveryInfoService, DeliveryInfoService>();
            container.RegisterType<ICourierService, CourierService>();

            //Repositories
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<ICartRepository, CartRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IDeliveryStationRepository, DeliveryStationRepository>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<ICityRepository, CityRepository>();
            container.RegisterType<IAreaRepository, AreaRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<IInventoryRepository, InventoryRepository>();
            container.RegisterType<IOrderItemRepository, OrderItemRepository>();
            container.RegisterType<IDeliveryInfoRepository, DeliveryInfoRepository>();
            container.RegisterType<ICourierRepository, CourierRepository>();
            container.RegisterType<ICartItemRepository, CartItemRepository>();
            container.RegisterType<IDeliveryOrderRepository, DeliveryOrderRepository>();
            container.RegisterType<IDeliveryOrderItemRepository, DeliveryOrderItemRepository>();
            container.RegisterType<IDeliveryNoteRepository, DeliveryNoteRepository>();
            container.RegisterType<IProviderRepository, ProviderRepository>();
            container.RegisterType<IWarehouseRepository, WarehouseRepository>();
            container.RegisterType<IDiscountRepository, DiscountRepository>();
            //
            container.RegisterType<IReadFromDb, ReadFromDb>();
            return container;
        }
    }
}