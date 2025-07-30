using HotChocolate.Types;
using LanguageExt;
using Uobachi.Application;
using Uobachi.Domain;
using Uobachi.Web;
using Query = Uobachi.Web.Query;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .BindRuntimeType<UserId, UuidType>()
    .AddTypeConverter<UserId, Guid>(x => x.Value)
    .AddTypeConverter<Guid, UserId>(UserId.From)
    .BindRuntimeType<Unit, UnitType>();

builder.Services.AddWebServices();
builder.Services.AddApplicationServices();

var app = builder.Build();
app.UseWebSockets();
app.MapGraphQL();

app.Run();