using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using DogSitter.API.Attribute;
using DogSitter.DAL.Enums;
using DogSitter.API.Extensions;
using DogSitter.BLL.Services.Interfaces;
using DogSitter.BLL.Services;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrderService _service;
        private IMapper _mapper;
        private IDogService _dogService;
        private ISitterService _sitterService;
        private IServiceService _serviceService;
        private IWorkTimeService _workTimeService;

        public OrdersController(IMapper mapper, IOrderService orderService, IDogService dogService,
            ISitterService sitterService, IServiceService serviceService, IWorkTimeService workTimeService)
        {
            _service = orderService;
            _mapper = mapper;
            _dogService = dogService;
            _sitterService = sitterService;
            _serviceService = serviceService;
            _workTimeService = workTimeService;
        }

        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpPut("{id}")]
        public ActionResult UpdateOrder([FromRoute] int id, [FromBody] OrderUpdateInputModel order)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            //var newDog = _dogService.GetDogById(order.DogId);
            //var newSitter = _sitterService.GetById(order.SitterId);
            //var newServiceList = new List<ServiceModel>();
            //foreach(var item in order.ServicesId)
            //{
            //    newServiceList.Add(_serviceService.GetServiceById(item));
            //}
            //var newWorkTime = _workTimeService.GetWorkTimeById(order.SitterWorkTimeId);
            //var newOrder = _service.GetOrderById(id);
            //newOrder.Dog = newDog;
            //newOrder.Sitter = newSitter;
            //newOrder.Services = newServiceList;
            //newOrder.SitterWorkTime = newWorkTime;

            _service.Update(userId.Value, _mapper.Map<OrderModel>(order));
            return Ok();
        }

        [AuthorizeRole(Role.Customer)]
        [HttpPost]
        public ActionResult AddOrder([FromBody] OrderInsertInputModel order)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.Add(userId.Value, _mapper.Map<OrderModel>(order));
            return StatusCode(StatusCodes.Status201Created, _mapper.Map<OrderOutputModel>(order));
        }

        //api/orders/42
        [AuthorizeRole(Role.Admin, Role.Customer, Role.Sitter)]
        [HttpPatch("{id}")]
        public IActionResult EditOrderStatusByOrderId(int id, [FromBody] OrderStatusUpdateInputModel order)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.EditOrderStatusByOrderId(userId.Value, id, order.OrderNewStatus);
            return NoContent();
        }

        [AuthorizeRole(Role.Customer)]
        [HttpPatch("leave-comment/{id}")]
        public IActionResult LeaveCommnetAndMark(int id, [FromBody] OrderUpdateCommentAndMarkModel order)
        {
            var userId = this.GetUserId();
            if(userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }
            var userOrder = _service.GetAllOrdersByCustomerId(userId.Value, id).First(w => w.Id == id);
            if(userOrder == null)
            {
                return Unauthorized("Invalid token, acsess denied");
            }

            _service.AddCommentAndMarkAboutOrder(userId.Value, _mapper.Map<OrderModel>(order));
            return Ok();
        }

    }
}
