using Xunit;
using Brewer.IntegrationTests;

[assembly: TestCaseOrderer(AttributeTestOrderer.TypeName, AttributeTestOrderer.AssemblyName)]
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, DisableTestParallelization = true)]