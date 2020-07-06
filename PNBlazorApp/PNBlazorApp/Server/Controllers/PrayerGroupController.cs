
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Abstractions.Websocket;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

using PNEntities;

using PNBlazorApp.Server.Containers;

namespace PNBlazorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrayerGroupController : ControllerBase
    {
        static IGraphQLWebsocketJsonSerializer serializer = new NewtonsoftJsonSerializer();
        static IGraphQLClient _client = new GraphQLHttpClient(Startup.PNWebApiUri, serializer);

        private readonly ILogger<PrayerGroupController> logger;

        public PrayerGroupController(ILogger<PrayerGroupController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<List<PrayerGroup>> GetAllPrayerGroupsAsync()
        {
            GraphQLRequest request = new GraphQLRequest();

            string query = @"query GetAllPrayerGroupData
                            {prayergroups
                                {
                                    id
                                    prayerGroupName
                                    prayerGroupDescription
                                    dateCreated
                                    dateLastModified
                                }
                            }";

            request.Query = query;

            // TODO: Can container objects be replaced by anon types and lambda?
            var response = await _client.SendQueryAsync<PrayerGroupContainer>(request);

            if (response.Errors != null && response.Errors.Any())
            {
                throw new ApplicationException(response.Errors[0].Message);
            }

            return response.Data.PrayerGroups.OrderBy(x => x.PrayerGroupName).ToList();
        }

        [HttpGet("{Id}")]
        public async Task<PrayerGroup> GetPrayerGroupByIdAsync([FromRoute] Guid Id)
        {

            GraphQLRequest request = new GraphQLRequest();

            string query = @"query GetPrayerGroupDataById($id:ID!){
                              prayergroup(id:$id)
                              {
                                  id
                                  prayerGroupName
                                  prayerGroupDescription
                                  dateCreated
                                  dateLastModified
                                }
                            }";

            request.Query = query;

            request.Variables = new { id = Id };

            var response = await _client.SendQueryAsync(request, () => new { prayergroup = new PrayerGroup() });
            if (response.Errors != null && response.Errors.Any())
            {
                throw new ApplicationException(response.Errors[0].Message);
            }

            return response.Data.prayergroup;
        }
    
        [HttpPost]
        public async Task<PrayerGroup> CreateNewPrayerGroupAsync([FromBody] PrayerGroup prayerGroup)
        {
            GraphQLRequest request = new GraphQLRequest();

            string query = @"mutation AddPrayerGroupData($pg:PrayerGroupInput!)
                            {
                                createPrayerGroup(prayergroup: $pg)
                                {
                                    id
                                    prayerGroupName
                                    prayerGroupDescription
                                    dateCreated
                                    dateLastModified
                                }
 
                            }";

            request.Query = query;

            // TODO:  Figure out how to send as JSON serialized object
            var variables = new
            {
                id = Guid.NewGuid().ToString(),
                prayerGroupName = prayerGroup.PrayerGroupName,
                prayerGroupDescription = prayerGroup.PrayerGroupDescription,
                dateCreated = DateTime.UtcNow.ToShortDateString(),
                dateLastModified = DateTime.UtcNow.ToShortDateString()
            };

            request.Variables = new { pg = variables };

            // TODO: Can container objects be replaced by anon types and lambda?
            var response = await _client.SendQueryAsync<PrayerGroupContainer>(request);

            if (response.Errors != null && response.Errors.Any())
            {
                throw new ApplicationException(response.Errors[0].Message);
            }

            return response.Data.createPrayerGroup;
        }

        [HttpPut]
        public async Task<PrayerGroup> Update([FromBody] PrayerGroup prayerGroup)
        {
            GraphQLRequest request = new GraphQLRequest();

            string query = @"mutation UpdatePrayerGroupData($pg:PrayerGroupInput!)
                            {
                                updatePrayerGroup(prayergroup: $pg)
                                {
                                    id
                                    prayerGroupName
                                    prayerGroupDescription
                                    dateCreated
                                    dateLastModified
                                }
 
                            }";

            request.Query = query;

            // TODO:  Figure out how to send as JSON serialized object
            var variables = new
            {
                id = prayerGroup.Id,
                prayerGroupName = prayerGroup.PrayerGroupName,
                prayerGroupDescription = prayerGroup.PrayerGroupDescription,
                dateCreated = prayerGroup.DateCreated,
                dateLastModified = DateTime.UtcNow.ToShortDateString()
            };
            
            request.Variables = new { pg = variables };

            // TODO: Can container objects be replaced by anon types and lambda?
            var response = await _client.SendQueryAsync<PrayerGroupContainer>(request);

            if (response.Errors != null && response.Errors.Any())
            {
                throw new ApplicationException(response.Errors[0].Message);
            }

            return response.Data.updatePrayerGroup;
        }

        [HttpDelete("{prayerGroupId}")]
        public async Task<PrayerGroup> Delete(Guid prayerGroupId)
        {
            GraphQLRequest request = new GraphQLRequest();

            string query = @"mutation DeletePGData($id:ID!)
                            {
                              deletePrayerGroup(id: $id)
                              {
                                id
                              }
                            }";

            request.Query = query;

            request.Variables = new { id = prayerGroupId };

            var response = await _client.SendQueryAsync<PrayerGroup>(request);

            if (response.Errors != null && response.Errors.Any())
            {
                throw new ApplicationException(response.Errors[0].Message);
            }

            // TODO: Refactor GraphQL to return a bool
            return response.Data;
        }
    }
}