using AutoMapper;
using BusinessLogic.Managers;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewComponents
{
    public class DeliveryListViewComponent : ViewComponent
    {
        private DeliveryManager _deliveryManager;

        private IMapper _mapper;

        public DeliveryListViewComponent(
            DeliveryManager deliveryManager,
            IMapper mapper)
        {
            _deliveryManager = deliveryManager ?? throw new ArgumentNullException(nameof(DeliveryManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));

        }
        public IEnumerable<DeliveryViewModel> GetTypes()
        {
            var deliveryTypes = _mapper.Map<IEnumerable<DeliveryModel>, IEnumerable<DeliveryViewModel>>(_deliveryManager.GetDeliveryTypes());
            return deliveryTypes;
        }
        public IViewComponentResult Invoke()
        {
            var deliveryTypes = GetTypes();
            return View(deliveryTypes);
        }
    }
}
