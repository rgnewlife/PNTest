using System;
using System.Collections.Generic;
using System.Text;

using GraphQL.Types;

using PNGraphQL.Types;

using PNServices;

using PNEntities;

namespace PNGraphQL.Queries
{
    public class PrayerGroupQuery : ObjectGraphType<PrayerGroup>
    {
        public PrayerGroupQuery(RepositoryService repositoryService)
        {
            Field<PrayerGroupType>(
                "prayergroup",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => repositoryService.PrayerGroupRepository.GetEntityAsync<PrayerGroup>(context.GetArgument<Guid>("id")));


            Field<ListGraphType<PrayerGroupType>>(
                "prayergroups",
                resolve: context => repositoryService.PrayerGroupRepository.GetAllAsync<PrayerGroup>());


        }
    }
}
