using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Duolingonator.Models;
using Duolingonator.Services;
using Duolingonator.Extensions;

namespace Duolingonator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly ILogger<ProfileController> _logger;

    private readonly DuolingoService _duolingoService;

    public ProfileController(ILogger<ProfileController> logger, DuolingoService duolingoService)
    {
        _logger = logger;
        _duolingoService = duolingoService;
    }

    [HttpGet(Name = "GetProfile")]
    public async Task<Profile> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _duolingoService.GetProfile(user.Username, user.Password);
    }
}
