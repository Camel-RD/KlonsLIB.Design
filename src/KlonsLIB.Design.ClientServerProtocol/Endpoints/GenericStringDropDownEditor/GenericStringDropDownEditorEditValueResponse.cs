using System;
using System.Collections.Generic;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace KlonsLIB.Design.Protocol.Endpoints
{
    public class GenericStringDropDownEditorEditValueResponse : Response
    {
        internal IReadOnlyList<string>? DropDownStrings { get; private set; } = new List<string>();

        public GenericStringDropDownEditorEditValueResponse() { }

        public GenericStringDropDownEditorEditValueResponse(IDataPipeReader reader) : base(reader) { }

        internal GenericStringDropDownEditorEditValueResponse(IReadOnlyList<string>? dropdownstrings)
        {
            DropDownStrings = dropdownstrings;
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            DropDownStrings = reader.ReadArray<string>(nameof(DropDownStrings), (rdr) => rdr.ReadString());
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteArray(nameof(DropDownStrings), DropDownStrings , (w, o) => w.Write(o));
        }
    }
}
