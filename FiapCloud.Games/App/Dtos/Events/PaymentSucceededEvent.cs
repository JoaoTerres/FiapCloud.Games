namespace FiapCloud.Games.App.Dtos.Events;

public class PaymentSucceededEvent
{
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PurchasedAt { get; set; }
}
