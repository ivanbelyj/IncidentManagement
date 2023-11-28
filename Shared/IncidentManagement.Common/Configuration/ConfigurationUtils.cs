namespace IncidentManagement.Common.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

public static class ConfigurationUtils
{
    /// <summary>
    /// Creates an object of the given type and binds configuration to it
    /// </summary>
    public static T? Load<T>(string key, IConfiguration? configuration = null)
        //where T : new()
    {
        T? settings = (T?)Activator.CreateInstance(typeof(T));
        //T settings = new T();

        (configuration ?? ConfigurationFactory.Create()).GetSection(key)
            .Bind(settings, (x) => { x.BindNonPublicProperties = true; });

        return settings;
    }
}
