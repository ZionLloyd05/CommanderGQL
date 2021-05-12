using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL
{
    public class Resolvers
    {
        public IQueryable<Command> GetCommandsByPlatform (Platform platform, [ScopedService] AppDbContext context) 
        {
            return context.Commands
                .Where(platform => platform.PlatformId == platform.Id);
        }

        public Platform GetPlatformByCommand(Command command, [ScopedService] AppDbContext context)
        {
            return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
        }
    }
}