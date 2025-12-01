using FiapCloud.Games.App.Features.CreateGame;
using FiapCloud.Games.App.Features.DeleteGame;
using FiapCloud.Games.App.Features.GetAllGames;
using FiapCloud.Games.App.Features.GetGameById;
using FiapCloud.Games.App.Features.UpdateGame;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloud.Games.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : BaseController
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGameCommand command)
    {
        return FromResult(await _mediator.Send(command));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGameCommand command)
    {
        return FromResult(await _mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return FromResult(await _mediator.Send(new DeleteGameCommand(id)));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return FromResult(await _mediator.Send(new GetGameByIdQuery(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return FromResult(await _mediator.Send(new GetAllGamesQuery()));
    }
}
