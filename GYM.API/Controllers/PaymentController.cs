using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _paymentService.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _paymentService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto dto)
        {
            var entity = new Payment
            {
                InvoiceId = dto.InvoiceId,
                Amount = dto.Amount,
                Method = dto.PaymentMethod,
                ProviderTransactionId = dto.TransactionRef
            };

            var id = await _paymentService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpGet("invoice/{invoiceId:guid}")]
        public async Task<IActionResult> GetByInvoice(Guid invoiceId)
        {
            var result = await _paymentService.GetByInvoice(invoiceId);
            return Ok(result.Select(ToDto));
        }

        private static PaymentDto ToDto(Payment p) => new PaymentDto
        {
            PaymentId = p.PaymentId,
            InvoiceId = p.InvoiceId.Value,
            Amount = p.Amount,
            PaidAt = p.PaidAt,
            PaymentMethod = p.Method,
            TransactionRef = p.ProviderTransactionId
        };
    }

}
