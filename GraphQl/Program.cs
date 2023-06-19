using ConferencePlanner.GraphQl;
using ConferencePlanner.GraphQL;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using ConferencePlanner.GraphQl.Speakers;
using ConferencePlanner.GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using ConferencePlanner.GraphQL.Tracks;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

void ConfigureServices(IServiceCollection services)
{
    services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=conferences.db"));

    services
        .AddGraphQLServer()
        .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<SpeakerQueries>()
            .AddTypeExtension<SessionQueries>()
            .AddTypeExtension<TrackQueries>()
        .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<SpeakerMutations>()
            .AddTypeExtension<SessionMutations>()
            .AddTypeExtension<TrackMutations>()
        .AddType<SpeakerType>()
        .AddType<AttendeeType>()
        .AddType<SessionType>()
        .AddType<SpeakerType>()
        .AddType<TrackType>()
        .AddGlobalObjectIdentification() //to replace from tutorial .EnableRelaySupport()
        .AddDataLoader<SpeakerByIdDataLoader>()
        .AddDataLoader<SessionByIdDataLoader>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

//app.MapGet("/", () => "Hello World!");

app.Run();
