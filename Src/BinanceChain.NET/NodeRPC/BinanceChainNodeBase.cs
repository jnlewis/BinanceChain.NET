using System;
using System.Collections.Generic;
using System.Reflection;
using BinanceChain.NET.Attributes;

namespace BinanceChain.NET.Api
{
    public abstract class BinanceChainNodeBase
    {
        protected string Path(string value)
        {
            return System.Net.WebUtility.UrlEncode(value);
        }

        protected string Query(object item)
        {
            List<string> values = new List<string>();

            Type type = item.GetType();

            foreach (var properties in type.GetTypeInfo().DeclaredProperties)
            {
                object propertyValue = properties.GetValue(item);
                if (propertyValue != null)
                {
                    var attribute = properties.GetCustomAttribute<QueryStringAttribute>();
                    if (attribute != null)
                    {
                        values.Add(attribute.Value + "=" + propertyValue);
                    }
                    else
                    {
                        values.Add(properties.Name + "=" + propertyValue);
                    }
                }
            }

            if (values.Count > 0)
            {
                return "?" + String.Join("&", values);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
