using MeLevaAi.Domain.Validations;

namespace MeLevaAi.Domain.Contracts.Responses;

public class ErrorResponse
{
    public IReadOnlyCollection<Notification> Notifications { get; set; }

    public ErrorResponse(IReadOnlyCollection<Notification> notifications)
        => Notifications = notifications;

    public ErrorResponse(Notification notification)
        => Notifications = new List<Notification> { notification };
}