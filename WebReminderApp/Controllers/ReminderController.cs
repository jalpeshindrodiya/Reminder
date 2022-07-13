using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebReminderApp.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebReminderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        // GET: api/<ReminderController>
        [Route("RemenderList")]
        [HttpGet]
        public IEnumerable<Reminders> Get()
        {
            using (var db = new DataContext())
            {
                return db.Reminders.ToList();
            }
        }

        // GET api/<ReminderController>/5
        [HttpGet]
        [Route("Detail")]
        public Reminders GetDetail(int id)
        {
            using (var db = new DataContext())
            {
                Reminders reminder = db.Reminders.FirstOrDefault(x => x.Id == id);
                return reminder;
            }

        }

        // POST api/<ReminderController>
        [HttpPost]
        [Route("Create")]
        public Reminders Post()
        {
            var Iscompleted = false;
            if (Request.Form["isCompleted"].Equals("on"))
            {
                Iscompleted = true;
            }
            Reminders reminders = new()
            {
                Name = Request.Form["name"],
                Title = Request.Form["title"],
                Description = Request.Form["description"],
                DueDate = DateTime.Parse(Request.Form["dueDate"]),
                IsCompleted = Iscompleted
            };

            using (var db = new DataContext())
            {
                if (!string.IsNullOrEmpty(Request.Form["id"].ToString()))
                {
                    reminders.Id = int.Parse(Request.Form["id"]);
                    db.Entry(reminders).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Reminders.Add(reminders);
                    db.SaveChanges();
                }
            }
            return reminders;
        }

        [HttpPost]
        [Route("Edit")]
        public Reminders Edit()
        {
            var Iscompleted = false;
            if (Request.Form["isCompleted"].Equals("on"))
            {
                Iscompleted = true;
            }
            Reminders reminders = new()
            {
                Name = Request.Form["name"],
                Title = Request.Form["title"],
                Description = Request.Form["description"],
                DueDate = DateTime.Parse(Request.Form["dueDate"]),
                IsCompleted = Iscompleted
            };

            using (var db = new DataContext())
            {
                if (!string.IsNullOrEmpty(Request.Form["id"].ToString()))
                {
                    reminders.Id = int.Parse(Request.Form["id"]);
                    db.Entry(reminders).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return reminders;
        }

        // PUT api/<ReminderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReminderController>/5
        [HttpDelete("{id}")]
        [Route("Delete")]
        public Reminders Delete()
        {
            int id = int.Parse(Request.Form["id"]);

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
