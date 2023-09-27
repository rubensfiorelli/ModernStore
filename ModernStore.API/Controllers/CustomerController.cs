using Microsoft.AspNetCore.Mvc;
using ModernStore.Data.Transactions;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Handlers;
using ModernStore.Domain.Repositories;

namespace ModernStore.API.Controllers
{
    [Route("v1")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IUow _uow;
        private readonly CustomerCommandHandler _handler;
        private readonly ICustomerRepository _repository;

        public CustomerController(IUow uow, CustomerCommandHandler handler, ICustomerRepository repository)
        {
            _uow = uow;
            _handler = handler;
            _repository = repository;
        }

        [HttpGet("customers/{id}")]
        public IActionResult Get(Guid id)
        {
            var customers = _repository.Get(id);

            return Ok(customers);
        }

        [HttpPost("customers")]
        public IActionResult Post(CreateCustomerCommand create)
        {
            var result = _handler.Handle(create);

            if (_handler.IsValid())
            {
                _uow.Commit();
                return Ok(result);
            }
            else
            {
                return BadRequest("Erro");
            }
                

            
        }
    }
}
