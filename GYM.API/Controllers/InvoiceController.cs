using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.InvoiceService;
using GYM.ServiceLayer.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _invoiceService.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _invoiceService.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceDto dto)
        {
            var entity = new Invoice
            {
                SubscriptionId = dto.SubscriptionId,
                MemberId = dto.MemberId,
                GymId = dto.GymId,
                Amount = dto.Amount,
                DueDate = dto.DueDate,
                IssuedAt = DateTime.UtcNow,
                StatusId = 1
            };

            var id = await _invoiceService.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:guid}/status/{statusId:int}")]
        public async Task<IActionResult> UpdateStatus(Guid id, int statusId)
        {
            var updated = await _invoiceService.UpdateStatus(id, statusId);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpGet("gym/{gymId:guid}")]
        public async Task<IActionResult> GetByGym(Guid gymId)
        {
            var result = await _invoiceService.GetByGym(gymId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("member/{memberId:guid}")]
        public async Task<IActionResult> GetByMember(Guid memberId)
        {
            var result = await _invoiceService.GetByMember(memberId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("status/{statusId:int}")]
        public async Task<IActionResult> GetByStatus(int statusId)
        {
            var result = await _invoiceService.GetByStatus(statusId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdue()
        {
            var result = await _invoiceService.GetOverdue();
            return Ok(result.Select(ToDto));
        }

        [HttpPut("{id:guid}/mark-paid")]
        public async Task<IActionResult> MarkPaid(Guid id)
        {
            var result = await _invoiceService.MarkPaid(id);
            if (!result) return NotFound();
            return NoContent();
        }

        private static InvoiceDto ToDto(Invoice i) => new InvoiceDto
        {
            InvoiceId = i.InvoiceId,
            SubscriptionId = i.SubscriptionId,
            MemberId = i.MemberId,
            GymId = i.GymId,
            Amount = i.Amount,
            StatusId = i.StatusId,
            IssuedAt = i.IssuedAt,
            DueDate = i.DueDate
        };
    }
}
