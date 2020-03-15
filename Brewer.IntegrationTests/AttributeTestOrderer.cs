using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Brewer.IntegrationTests
{
    public class AttributeTestOrderer : ITestCaseOrderer
    {
        public const string TypeName = "Brewer.IntegrationTests.AttributeTestOrderer";
        public const string AssemblyName = "Brewer.IntegrationTests";

        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            return testCases.OrderBy(x => GetOrder(x));
        }

        private static int GetOrder(ITestCase testCase)
        {
            var className = testCase.TestMethod.TestClass.Class.Name;

            var type = Type.GetType(className);

            if (type == null)
                return 0;

            var method = type.GetMethod(testCase.TestMethod.Method.Name, BindingFlags.Public | BindingFlags.Instance);

            if (method == null)
                return 0;

            var attr = method.GetCustomAttribute<OrderAttribute>();

            return attr?.Order ?? 0;
        }
    }
}
