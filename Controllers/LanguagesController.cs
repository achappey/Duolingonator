using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Duolingonator.Models;
using Duolingonator.Services;
using Duolingonator.Extensions;

namespace Duolingonator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguagesController : ControllerBase
{
    private readonly ILogger<LanguagesController> _logger;

    private readonly DuolingoService _duolingoService;

    public LanguagesController(ILogger<LanguagesController> logger, DuolingoService duolingoService)
    {
        _logger = logger;
        _duolingoService = duolingoService;
    }

    [HttpGet(Name = "GetLanguages")]
    [EnableQuery]
    public async Task<IEnumerable<Language>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _duolingoService.GetLanguages(user.Username, user.Password);
    }
}
