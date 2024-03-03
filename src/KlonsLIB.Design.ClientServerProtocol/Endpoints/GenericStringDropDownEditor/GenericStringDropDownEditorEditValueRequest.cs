using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace KlonsLIB.Design.Protocol.Endpoints
{
    public class GenericStringDropDownEditorEditValueRequest : Request
    {
        public object? OwnerObj { get; private set; }
        public string? PropertyName  { get; private set; }

        public GenericStringDropDownEditorEditValueRequest(object ownerobj, string propertyName)
        {
            OwnerObj = ownerobj ?? throw new ArgumentNullException(nameof(ownerobj));
            PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        }

        public GenericStringDropDownEditorEditValueRequest(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            OwnerObj = reader.ReadObject(nameof(OwnerObj));
            PropertyName = reader.ReadString(nameof(PropertyName));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(OwnerObj), OwnerObj);
            writer.Write(nameof(PropertyName), PropertyName);
        }

    }
}
