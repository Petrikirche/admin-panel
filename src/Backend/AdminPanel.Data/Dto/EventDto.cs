namespace AdminPanel.Data.Dto;

public class EventDto
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime EventDate { get; set; }
    public string? ImagePath { get; set; }
}