using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceChain.NET.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    internal class QueryStringAttribute : System.Attribute
    {
        private string name = null;

        public QueryStringAttribute(string name)
        {
            this.name = name;
        }

        public string Value
        {
            get { return name; }
        }
    }
}
