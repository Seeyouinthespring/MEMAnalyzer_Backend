using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;

namespace MEMAnalyzer_Backend.Attributes
{
    public class Swagger200Attribute : SwaggerResponseAttribute
    {
        public Swagger200Attribute(Type type) : base((int)HttpStatusCode.OK, type: type)
        {
        }
    }
}
