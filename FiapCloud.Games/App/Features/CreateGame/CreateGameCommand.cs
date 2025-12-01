using FiapCloud.Games.App.common;
using FiapCloud.Games.App.Dtos;
using MediatR;

namespace FiapCloud.Games.App.Features.CreateGame;

public class CreateGameCommand : IRequest<Result<GameResult>>
{
    public CreateGameCommand(string title, decimal price)
    {
        Title = title;
        Price = price;
    }

    public string Title { get; }
    public decimal Price { get; }
}
