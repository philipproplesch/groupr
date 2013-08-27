using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Groupr.Mvc.Resources;

namespace Groupr.Mvc
{
    public class LocalizedModelMetadataProvider
        : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
       IEnumerable<Attribute> attributes,
       Type containerType,
       Func<object> modelAccessor,
       Type modelType,
       string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return base.CreateMetadata(
                    attributes,
                    containerType,
                    modelAccessor,
                    modelType,
                    propertyName);
            }

            var newAttributes = new List<Attribute>(attributes);

            if (newAttributes.All(
                x => x.GetType() != typeof(DisplayNameAttribute)))
            {
                var value = Labels.ResourceManager.GetString(propertyName);

                if (!string.IsNullOrEmpty(value))
                {
                    var attribute = new DisplayNameAttribute(value);
                    newAttributes.Add(attribute);
                }
            }

            return base.CreateMetadata(
                newAttributes,
                containerType,
                modelAccessor,
                modelType,
                propertyName);
        }
    }
}