using GYM.BO.ViewModels;
using GYM.EF.Models;
using GYM.ServiceLayer.BodyMetricService;
using Microsoft.AspNetCore.Mvc;

namespace GYM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyMetricController : ControllerBase
    {
        private readonly IBodyMetricService _service;
        private readonly ILogger<BodyMetricController> _logger;

        public BodyMetricController(IBodyMetricService service, ILogger<BodyMetricController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // ------------------- CRUD -------------------

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result.Select(ToDto));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _service.Get(id);
            if (entity == null) return NotFound();
            return Ok(ToDto(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBodyMetricDto dto)
        {
            var entity = new BodyMetric
            {
                MemberId = dto.MemberId,
                MetricTypeId = dto.MetricTypeId,
                Value = dto.Value,
                Unit = dto.Unit,
                MeasuredAt = dto.MeasuredAt,
                SourceId = dto.SourceId
            };

            var id = await _service.Create(entity);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateBodyMetricDto dto)
        {
            if (id != dto.BodyMetricId) return BadRequest("Mismatched IDs");

            var entity = new BodyMetric
            {
                BodyMetricId = dto.BodyMetricId,
                Value = dto.Value,
                Unit = dto.Unit,
                MeasuredAt = dto.MeasuredAt,
                SourceId = dto.SourceId
            };

            var updated = await _service.Update(entity);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // ------------------- Filters -------------------

        [HttpGet("member/{memberId:guid}")]
        public async Task<IActionResult> GetByMember(Guid memberId)
        {
            var result = await _service.GetByMember(memberId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("member/{memberId:guid}/type/{metricTypeId:int}")]
        public async Task<IActionResult> GetByType(Guid memberId, int metricTypeId)
        {
            var result = await _service.GetByType(memberId, metricTypeId);
            return Ok(result.Select(ToDto));
        }

        [HttpGet("member/{memberId:guid}/range")]
        public async Task<IActionResult> GetByDateRange(Guid memberId, [FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var result = await _service.GetByDateRange(memberId, start, end);
            return Ok(result.Select(ToDto));
        }

        // ------------------- Helper -------------------

        private static BodyMetricDto ToDto(BodyMetric m) => new BodyMetricDto
        {
            BodyMetricId = m.BodyMetricId,
            MemberId = m.MemberId,
            MetricTypeId = m.MetricTypeId,
            Value = m.Value,
            Unit = m.Unit,
            MeasuredAt = m.MeasuredAt,
            SourceId = m.SourceId
        };
    }
}
