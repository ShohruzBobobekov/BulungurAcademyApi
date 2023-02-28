using BulungurAcademy.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace BulungurAcademy.Core.Controllers;

[ApiController]
[Route("bot")]
public class BotController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update,
        [FromServices] UpdateHandler updateHandler)
    {
        await updateHandler
            .UpdateHandlerAsync(update);

        return Ok();
    }
}
