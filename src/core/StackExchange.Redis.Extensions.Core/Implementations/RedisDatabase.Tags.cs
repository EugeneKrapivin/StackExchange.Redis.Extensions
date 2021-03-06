﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace StackExchange.Redis.Extensions.Core.Implementations
{
    public partial class RedisDatabase : IRedisDatabase
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetByTag<T>(string tag)
        {
            var tagKey = GenerateTagKey(tag);

            var memberKeys = await SetMembersAsync<string>(tagKey);

            return (await GetAllAsync<T>(memberKeys)).Values;
        }
    }
}
