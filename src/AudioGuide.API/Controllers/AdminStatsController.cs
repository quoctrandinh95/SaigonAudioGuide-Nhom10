using AudioGuide.BLL;
using AudioGuide.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudioGuide.API.Controllers;

[ApiController]
[Authorize]
[Route("api/admin/stats")]
public class AdminStatsController : ControllerBase
{
    private readonly IStatsService _service;
    public AdminStatsController(IStatsService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<StatsDto>> Get([FromQuery] int days = 30)
    {
        if (days < 5 || days > 30)
            return BadRequest(new { message = "Khoảng thời gian thống kê phải từ 5 đến 30 ngày." });

        return await _service.GetStatsAsync(days);
    }
}
