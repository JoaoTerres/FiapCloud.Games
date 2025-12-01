using FiapCloud.Games.App.common;
using FiapCloud.Games.App.Dtos;
using MediatR;

namespace FiapCloud.Games.App.Features.UpdateGame;

public class UpdateGameCommand : IRequest<Result<GameResult>>
{
    public UpdateGameCommand(Guid id, string title, decimal price)
    {
        Id = id;
        Title = title;
        Price = price;
    }

    public Guid Id { get; }
    public string Title { get; }
    public decimal Price { get; }
}
