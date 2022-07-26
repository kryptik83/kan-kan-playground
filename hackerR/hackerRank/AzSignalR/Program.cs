using AzSignalR.SignalRHubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR().AddAzureSignalR();

// builder.Services.AddScoped<IMyHub, MyHub>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseDefaultFiles();
app.UseAuthorization();

app.MapControllers();
app.UseRouting();

// app.UseAzureSignalR(routes => routes.MapHub<MyHub>("/hubs/sr"));
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/hubs/signalr");
});

app.Run();