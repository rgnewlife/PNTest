using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

namespace PNData
{
    public class CosmosClientService
    {
        public string DatabaseName { get; set; }

        public string Endpoint { get; set; }

        public CosmosClient CosmosClient { get; }

        public CosmosClientService(string databaseName, string endpoint, string key)
        {
            DatabaseName = databaseName;
            Endpoint = endpoint;
            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(endpoint, key);
            CosmosClient client = clientBuilder
                                .WithConnectionModeDirect()
                                .Build();
            CosmosClient = client;
        }
    }
}
