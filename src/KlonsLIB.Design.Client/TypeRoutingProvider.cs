using Microsoft.DotNet.DesignTools.Client.TypeRouting;
using System.Collections.Generic;

namespace KlonsLIB.Design.Client
{
    [ExportTypeRoutingDefinitionProvider]
    internal class TypeRoutingProvider : TypeRoutingDefinitionProvider
    {
        public override IEnumerable<TypeRoutingDefinition> GetDefinitions()
        {
            return new[]
            {
                new TypeRoutingDefinition(TypeRoutingKinds.Editor, nameof(GenericCollectionEditor), typeof(GenericCollectionEditor)),
                new TypeRoutingDefinition(TypeRoutingKinds.Editor, nameof(GenericStringDropDownEditor), typeof(GenericStringDropDownEditor)),
                new TypeRoutingDefinition(TypeRoutingKinds.Editor, "KlonsLIB.Design.GenericCollectionEditor", typeof(GenericCollectionEditor)),
                new TypeRoutingDefinition(TypeRoutingKinds.Editor, "KlonsLIB.Design.GenericStringDropDownEditor", typeof(GenericStringDropDownEditor)),
                new TypeRoutingDefinition(TypeRoutingKinds.Editor, "KlonsLIB.Design.GenericCollectionEditor, KlonsLIB.Design", typeof(GenericCollectionEditor)),
                new TypeRoutingDefinition(TypeRoutingKinds.Editor, "KlonsLIB.Design.GenericStringDropDownEditor, KlonsLIB.Design", typeof(GenericStringDropDownEditor)),
            };
        }
    }

}
