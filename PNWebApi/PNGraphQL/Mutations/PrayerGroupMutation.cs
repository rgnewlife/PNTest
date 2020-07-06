using System;
using System.Collections.Generic;
using System.Text;

using GraphQL.Types;

using PNGraphQL.Types;

using PNServices;

using PNEntities;

namespace PNGraphQL.Mutations
{
    public class PrayerGroupMutation : ObjectGraphType
    {
        public PrayerGroupMutation(RepositoryService repositoryService)
        {
            Name = "PrayerGroupMutation";

            Field<PrayerGroupType>(
                "CreatePrayerGroup",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PrayerGroupInputType>> { Name = "prayergroup" }
                ),
                resolve: context =>
                {
                    var prayerGroup = context.GetArgument<PrayerGroup>("prayergroup");
                    return repositoryService.PrayerGroupRepository.AddEntityAsync<PrayerGroup>(prayerGroup.Id, prayerGroup);

                });

            Field<PrayerGroupType>(
                "UpdatePrayerGroup",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PrayerGroupInputType>> { Name = "prayergroup" }
                ),
                resolve: context =>
                {
                    var prayerGroup = context.GetArgument<PrayerGroup>("prayergroup");
                    return repositoryService.PrayerGroupRepository.UpdateEntityAsync<PrayerGroup>(prayerGroup.Id, prayerGroup);

                });


            Field<PrayerGroupType>(
                "DeletePrayerGroup",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return repositoryService.PrayerGroupRepository.DeleteEntityAsync<PrayerGroup>(id);
                });
        }
    }
}
