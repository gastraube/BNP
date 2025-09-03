using BNP.Application.Interfaces;
using BNP.Application.Services;
using BNP.Domain.Interfaces;
using BNP.Infrastructure.Context;
using BNP.Infrastructure.Repositories;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace BNP.Web
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<BNPDbContext>(new PerRequestLifetimeManager());
            container.RegisterType<IMovimentoManualRepository, MovimentoManualRepository>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();
            container.RegisterType<IProdutoCosifRepository, ProdutoCosifRepository>();
            container.RegisterType<IMovimentoManualAppService, MovimentoManualAppService>();

            Container = container;
        }
    }
}