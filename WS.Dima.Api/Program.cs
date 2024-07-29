using WS.Dima.Api;
using WS.Dima.Api.Common.Api;
using WS.Dima.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContext();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if(app.Environment.IsDevelopment())
    app.ConfigureDevelopmentEnv();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();
app.MapEndpoints();
app.Run();
