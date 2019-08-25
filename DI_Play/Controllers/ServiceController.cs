using DI_Play.Middleware;
using DI_Play_Lib.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DI_Play.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMyScopedServiceFactory _myScopedServiceFactory;

        public ServiceController(
            ITransientService transientService,
            IScopedService scopedService,
            ISingletonService singletonService,
            IServiceProvider serviceProvider,
            IMyScopedServiceFactory myScopedServiceFactory)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
            _serviceProvider = serviceProvider;
            _myScopedServiceFactory = myScopedServiceFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            var msg = _myScopedServiceFactory.Service.ScopedMesssage;
            return Content(msg);
        }

        public IActionResult GetServiceData()
        {
            var transient2 = (ITransientService)_serviceProvider.GetService(typeof(ITransientService));
            var scoped2 = (IScopedService)_serviceProvider.GetService(typeof(IScopedService));
            var singleton2 = (ISingletonService)_serviceProvider.GetService(typeof(ISingletonService));

            return Json(new
            {
                Tran1 = _transientService.GetMessage(),
                Tran2 = transient2.GetMessage(),
                Scop1 = _scopedService.GetMessage(),
                Scop2 = scoped2.GetMessage(),
                Sing1 = _singletonService.GetMessage(),
                Sing2 = singleton2.GetMessage(),
            });
        }
    }
}