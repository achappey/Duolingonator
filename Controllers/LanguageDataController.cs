using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Duolingonator.Models;
using Duolingonator.Services;
using Duolingonator.Extensions;

namespace Duolingonator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguageDataController : ControllerBase
{
    private readonly ILogger<LanguageDataController> _logger;

    private readonly DuolingoService _duolingoService;

    public LanguageDataController(ILogger<LanguageDataController> logger, DuolingoService duolingoService)
    {
        _logger = logger;
        _duolingoService = duolingoService;
    }

    [HttpGet(Name = "GetLanguageData")]
    [EnableQuery]
    public async Task<LanguageData> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _duolingoService.GetLanguageData(user.Username, user.Password);
    }
}
