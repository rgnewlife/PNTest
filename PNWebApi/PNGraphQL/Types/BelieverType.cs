using System;
using System.Collections.Generic;
using System.Text;

using GraphQL.Types;

using PNEntities;

namespace PNGraphQL.Types
{
    public class BelieverType : ObjectGraphType<Believer>
    {
        public BelieverType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id of the Believer");
            Field(x => x.UserName, true);
            Field(x => x.FirstName);
            Field(x => x.LastName);
        }

    }
}
