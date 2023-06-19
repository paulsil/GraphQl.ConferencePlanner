using System.Reflection;
using ConferencePlanner.GraphQL.Data;
using HotChocolate.Types.Descriptors;

namespace ConferencePlanner.GraphQl.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        protected override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}