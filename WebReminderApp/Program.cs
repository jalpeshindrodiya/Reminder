using WebReminderApp.Database;
using WebReminderApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IReminderService, ReminderService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.MapGet("/api/RemenderList", (IReminderService service) =>
{
    return Results.Ok(service.ReminderList());
});

app.MapGet("/api/Detail",(int id,IReminderService service) =>
{
    return Results.Ok(service.GetDetail(id));
});

app.MapPost("/api/Create", (HttpRequest Request, IReminderService service) =>
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
    return Results.Ok(service.Post(reminders));
});

app.MapPost("/api/Edit", (HttpRequest Request,IReminderService service) =>
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
    return Results.Ok(service.Edit(reminders));
});
app.MapGet("/api/Delete", (int id,IReminderService service) =>
{
    return Results.Ok(service.Delete(id));
});


app.Run();
