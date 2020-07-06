using System;
using System.Collections.Generic;
using System.Text;

using GraphQL.Types;

using PNEntities;

namespace PNGraphQL.Types
{
    public class PrayerGroupInputType : InputObjectGraphType<PrayerGroup>
    {
        public PrayerGroupInputType()
        {
            Name = "PrayerGroupInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("prayerGroupName");
            Field<StringGraphType>("prayerGroupDescription");
            Field<DateTimeGraphType>("dateCreated");
            Field<DateTimeGraphType>("dateLastModified");
        }
    }
}
