// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Context
{
    using System;
    using System.Threading;
    using Magnum.Caching;


    public class PublishObjectConverterCache
    {
        readonly Cache<Type, PublishObjectConverter> _typeCache =
            new GenericTypeCache<PublishObjectConverter>(typeof(PublishObjectConverterImpl<>));

        public static PublishObjectConverterCache Instance
        {
            get { return InstanceCache.Cached.Value; }
        }

        public PublishObjectConverter this[Type type]
        {
            get { return _typeCache[type]; }
        }


        static class InstanceCache
        {
            internal static readonly Lazy<PublishObjectConverterCache> Cached =
                new Lazy<PublishObjectConverterCache>(() => new PublishObjectConverterCache(), LazyThreadSafetyMode.PublicationOnly);
        }
    }
}