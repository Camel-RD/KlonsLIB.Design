using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System.Composition;

namespace KlonsLIB.Design.Protocol.Endpoints
{
    [Shared]
    [ExportEndpoint]
    public class GenericStringDropDownEditorEditValueEndpoint : Endpoint<GenericStringDropDownEditorEditValueRequest, GenericStringDropDownEditorEditValueResponse>
    {
        public override string Name => EndpointNames.GenericStringDropDownEditorEditValue;

        protected override GenericStringDropDownEditorEditValueRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override GenericStringDropDownEditorEditValueResponse CreateResponse(IDataPipeReader reader)
            => new(reader);

    }
}
