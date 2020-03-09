namespace ALDQuoteService.Services
{
    /// <summary>
    /// Simple interface for an integration message which can be published
    /// onto the message queue
    /// </summary>
    public interface IMessage
    {
        string Id { get; set; }
        string Status { get; set; }
    }
}
