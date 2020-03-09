namespace ALDQuoteService.Services
{
    /// <summary>
    /// Service for interacting with system message queue
    /// </summary>
    public class MessageQueueService
    {
        /// <summary>
        /// Publishes the supplied <see cref="IMessage"/> onto the message queue
        /// </summary>
        /// <param name="message"><see cref="IMessage"/> implementation</param>
        public void Publish(IMessage message)
        {
            // For the purposes of this exercise, this method emulates a connection
            // to a message queue, where events can be published
            System.Diagnostics.Debug.WriteLine($"Message Published:  Quote Id {message.Id}. Status: {message.Status}");
        }
    }
}