using AdminPanel.Data.Entity;

namespace AdminPanel.Data.Dto.DtoExtension
{
    public static class EventDtoExtension
    {
        public static EventDto ToDto(this Event myEvent)
        {
            return new EventDto
            {
                Id = myEvent.Id,
                EventDate = myEvent.EventDate,
                EventName = myEvent.EventName,
                ImagePath = myEvent.ImagePath
            };
        }
    }
}
