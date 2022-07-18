using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebReminderApp.Controllers;
using WebReminderApp.Database;
using WebReminderApp.Services;

namespace WebReminderApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IReminderService _reminderService;

        public IndexModel(ILogger<IndexModel> logger,IReminderService service)
        {
            _logger = logger;
            _reminderService = service;
        }

        public void OnGet()
        {
            var reminderlist = _reminderService.ReminderList();

            ViewData["RemindersData"] = reminderlist;
        }
    }
}