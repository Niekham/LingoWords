using System;
using Microsoft.Extensions.Caching.Memory;

namespace Lingowords
{
    /**
     * Implementation of IWordsWriter
     */ 
    public class MemoryWords : IWordsMemory
    {
        private readonly IMemoryCache _cache;

        public MemoryWords( IMemoryCache cache ) {
            _cache = cache;
        }

        public void Save( string key, Words words ){
            _cache.Set( key, words );
        }

        public bool Exists(string key)
        {
            if (_cache.TryGetValue(key, out Words words))
            {
                return true;
            }

            return false;
        }
    
        public Words Read( string key )
        {
            if (_cache.TryGetValue(key, out Words words))
            {
                return words;
            }

            return null;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

    }
}
