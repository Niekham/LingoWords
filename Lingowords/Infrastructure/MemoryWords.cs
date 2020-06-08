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

        public void Save( string path, Words words ){
            _cache.Set( words.Language(), words );
        }

        public bool Exists( string key )
        {
            if( _cache.Get<Words>( key ) == null ){
                return false;
            }

            return true;
        }
    
        public Words Read( string key )
        {
            return _cache.Get<Words>( key );
        }

    }
}
