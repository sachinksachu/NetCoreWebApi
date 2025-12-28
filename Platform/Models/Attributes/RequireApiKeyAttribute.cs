using System;
namespace NetCoreWebApi.Platform.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequireApiKeyAttribute : Attribute
    {

    }
}

//<note>
//RequireApiKeyAttribute is a marker attribute. It doesn’t contain logic; it simply adds metadata to an endpoint.
//</note>
