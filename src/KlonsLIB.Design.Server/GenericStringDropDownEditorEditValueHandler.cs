using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

using KlonsLIB.Design.Protocol.Endpoints;

namespace KlonsLIB.Design.Server
{
    [ExportRequestHandler(EndpointNames.GenericStringDropDownEditorEditValue)]
    public class GenericStringDropDownEditorEditValueHandler : RequestHandler<GenericStringDropDownEditorEditValueRequest, GenericStringDropDownEditorEditValueResponse>
    {
        public override GenericStringDropDownEditorEditValueResponse HandleRequest(GenericStringDropDownEditorEditValueRequest request)
        {
            if (request.OwnerObj is not IGenericStringDropDownEditorTarget target)
                return new GenericStringDropDownEditorEditValueResponse();

            if (request.PropertyName is null || target is null)
                return new GenericStringDropDownEditorEditValueResponse(Array.Empty<string>());

            var dropdownstings = target.GetValues(request.PropertyName);
            if (dropdownstings is null)
                return new GenericStringDropDownEditorEditValueResponse();

            return new GenericStringDropDownEditorEditValueResponse(dropdownstings);
        }
    }
}
