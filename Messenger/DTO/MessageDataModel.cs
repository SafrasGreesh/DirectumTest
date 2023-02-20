public class MessageDataModel
{
    public int UserId { get; set; }
    public int ContactId { get; set; }
    public DateTime SendTime { get; set; }

    public DateTime DeliveryTime { get; set; }
    public string Content { get; set; }
}