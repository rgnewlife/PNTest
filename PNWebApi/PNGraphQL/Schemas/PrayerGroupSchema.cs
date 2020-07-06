using System;
using System.Collections.Generic;
using System.Text;

using GraphQL;
using GraphQL.Types;

using PNGraphQL.Queries;
using PNGraphQL.Mutations;

namespace PNGraphQL.Schemas
{
    public class PrayerGroupSchema : Schema
    {
        public PrayerGroupSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PrayerGroupQuery>();
            Mutation = resolver.Resolve<PrayerGroupMutation>();
        }
    }
}
