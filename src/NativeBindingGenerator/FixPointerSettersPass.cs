using CppSharp.AST;
using CppSharp.Passes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeBindingGenerator
{
    internal class FixPointerSettersPass : TranslationUnitPass
    {
        public override bool VisitFieldDecl(Field field)
        {
            if (field.Name == "revision" || field.Name == "peg_revision" || field.Name == "merged_value")
            {
                // Check for TypedefType (most likely) or PointerType directly
                var typedefType = field.Type as TypedefType;
                if (typedefType != null)
                {
                    var pointeeType = typedefType.Declaration.Type as PointerType;
                    if (pointeeType != null)
                    {
                        // Make sure we are treating the pointee correctly
                        field.QualifiedType = new QualifiedType(pointeeType.Pointee);
                    }
                }
                else if (field.Type is PointerType)
                {
                    var pointerType = field.Type as PointerType;
                    field.QualifiedType = new QualifiedType(pointerType.Pointee);  // Resolve the pointer to the actual struct
                }

                field.Ignore = false; // Ensure the field is not ignored
            }
            return base.VisitFieldDecl(field);
        }
    }
}