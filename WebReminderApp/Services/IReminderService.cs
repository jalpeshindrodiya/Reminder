using WebReminderApp.Database;

namespace WebReminderApp.Services
{
    public interface IReminderService
    {
        List<Reminders> ReminderList();

        Reminders GetDetail(int id);

        Reminders Post(Reminders reminders);

        Reminders Edit(Reminders reminders);

        Reminders Delete(int id);
    }
}
