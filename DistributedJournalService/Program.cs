﻿using System;
using System.Fabric;
using System.Threading;

namespace DistributedJournalService
{
    using DistributedJournalService.Replica;

    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                // Creating a FabricRuntime connects this host process to the Service Fabric runtime.
                using (var fabricRuntime = FabricRuntime.Create())
                {
                    // The ServiceManifest.XML file defines one or more service type names.
                    // RegisterServiceType maps a service type name to a .NET class.
                    // When Service Fabric creates an instance of this service type,
                    // an instance of the class is created in this host process.
                    fabricRuntime.RegisterStatefulServiceFactory("DistributedJournalServiceType", new ServiceFactory());

                    // Prevents this host process from terminating to keep the service host process running.
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }

    internal class ServiceFactory : IStatefulServiceFactory {
        /// <summary>
        /// Return an instance of a service
        ///             The framework will set the serviceTypeName, serviceName, initializationData, partitionId and instanceId properties on the service
        /// </summary>
        /// <returns/>
        public IStatefulServiceReplica CreateReplica(
            string serviceTypeName,
            Uri serviceName,
            byte[] initializationData,
            Guid partitionId,
            long replicaId)
        {
            return new JournalReplica(new KeyValueStore());
        }
    }
}

