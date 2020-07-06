using System;
using System.Collections.Generic;
using System.Text;

using GraphQL.Types;

using PNEntities;

namespace PNGraphQL.Types
{
    public class PrayerGroupType : ObjectGraphType<PrayerGroup>
    {

        public PrayerGroupType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of the PrayerGroup");
            Field(x => x.PrayerGroupName, true);
            Field(x => x.PrayerGroupDescription);
            Field(x => x.DateCreated);
            Field(x => x.DateLastModified);

            // TODO:  Implement
            //Field<ListGraphType<BelieverType>>("believers");

        }

    }
}
