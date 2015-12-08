#Service Fabric Journal Service
A replicated journal on Service Fabric. Demonstrates how to write a persistent, stateful service which uses Service Fabric for replication.

## [Twitter: @ReubenBond](https://twitter.com/reubenbond) :)

I give zero guarantees about any of this. It's surprising that it appears to work at all, it's almost certainly buggy.

1. Install Service Fabric SDK.
2. Open in VS 2015, and deploy the application to your local cluster.
3. Run TestApp.exe on your local cluster and watch your hard drive slowly fill with replicated operations.

Also check out [Fabric Table Service](https://github.com/ReubenBond/FabricTableService), a distributed database on Service Fabric which uses ESENT as the storage engine and co-operates transactionally with Fabric's provided `IReliableDictionary` & `IReliableQueue`.

There is significant room for optimization, this project was just a learning excercise.