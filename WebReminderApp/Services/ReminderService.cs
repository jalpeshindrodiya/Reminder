using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebReminderApp.Database;

namespace WebReminderApp.Services
{
    public class ReminderService : IReminderService
    {
        public List<Reminders> ReminderList()
        {
            using (var db = new DataContext())
            {
                return db.Reminders.ToList();
            }
        }

        // GET api/<ReminderController>/5
        public Reminders GetDetail(int id)
        {
            using (var db = new DataContext())
            {
                Reminders reminder = db.Reminders.FirstOrDefault(x => x.Id == id);
                return reminder;
            }

        }

        public Reminders Post(Reminders reminders)
        {
            using (var db = new DataContext())
            {
                db.Reminders.Add(reminders);
                db.SaveChanges();
            }
            return reminders;
        }
        public Reminders Edit(Reminders reminders)
        {
            using (var db = new DataContext())
            {
                db.Entry(reminders).State = EntityState.Modified;
                db.SaveChanges();
            }
            return reminders;
        }

        // PUT api/<ReminderController>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        public Reminders Delete(int id)
        {
            using (var db = new DataContext())
            {
                Reminders reminders = db.Reminders.Find(id);
                if (reminders == null)
                {
                    //return 1;
                }
                else
                {
                    db.Reminders.Remove(reminders);
                    db.SaveChanges();
                }
                return reminders;
            }
        }
    }
}
