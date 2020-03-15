using System;

namespace Brewer.IntegrationTests
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OrderAttribute : Attribute
    {
        public int Order { get; }

        public OrderAttribute(int order)
        {
            Order = order;
        }
    }
}
