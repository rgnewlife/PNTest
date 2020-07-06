using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Cosmos;

using PNEntities;


namespace PNData
{
    public class PrayerGroupRepository : IPrayerGroupRepository
    {
        private Microsoft.Azure.Cosmos.Container _container;

        //TODO:  Move to appsettings?
        private const string CONTAINER_NAME = "PrayerGroups";

        public PrayerGroupRepository(CosmosClientService cosmosClientService)
        {
            this._container = cosmosClientService.CosmosClient.GetContainer(cosmosClientService.DatabaseName, CONTAINER_NAME);
        }

        public async Task<PrayerGroup> AddEntityAsync<PrayerGroup>(Guid id, PrayerGroup prayerGroup)
        {
            return await this._container.CreateItemAsync<PrayerGroup>(prayerGroup, new PartitionKey(id.ToString()));
        }


        // TODO: Figure out how to write to return a bool.
        public async Task<PrayerGroup> DeleteEntityAsync<PrayerGroup>(Guid id)
        {
            return await this._container.DeleteItemAsync<PrayerGroup>(id.ToString(), new PartitionKey(id.ToString()));

        }

        public async Task<PrayerGroup> GetEntityAsync<PrayerGroup>(Guid id)
        {
            
            ItemResponse<PrayerGroup> response = await this._container.ReadItemAsync<PrayerGroup>(id.ToString(), new PartitionKey(id.ToString()));
            return response.Resource;
            
            /*
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // TODO:  Implement
                
            }
            */
        }

        public async Task<IEnumerable<PrayerGroup>> GetAllAsync<PrayerGroup>()
        {
            var query = this._container.GetItemQueryIterator<PrayerGroup>(new QueryDefinition("SELECT * FROM p"));
            List<PrayerGroup> results = new List<PrayerGroup>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<PrayerGroup> UpdateEntityAsync<PrayerGroup>(Guid id, PrayerGroup prayerGroup)
        {
            return await this._container.UpsertItemAsync<PrayerGroup>(prayerGroup, new PartitionKey(id.ToString()));
        }
    }
}

