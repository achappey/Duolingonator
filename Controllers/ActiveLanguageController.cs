using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Duolingonator.Models;
using Duolingonator.Services;
using Duolingonator.Extensions;

namespace Duolingonator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActiveLanguageController : ControllerBase
{
    private readonly ILogger<ActiveLanguageController> _logger;

    private readonly DuolingoService _duolingoService;

    public ActiveLanguageController(ILogger<ActiveLanguageController> logger, DuolingoService duolingoService)
    {
        _logger = logger;
        _duolingoService = duolingoService;
    }

    [HttpGet(Name = "GetActiveLanguage")]
    [Tags("Languages")]
    [EnableQuery]
    public async Task<ActiveLanguage> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _duolingoService.GetActiveLanguage(user.Username, user.Password);
    }
}
