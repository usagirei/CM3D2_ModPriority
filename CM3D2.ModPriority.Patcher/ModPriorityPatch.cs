// --------------------------------------------------
// CM3D2.ModPriority.Patcher - ModPriorityPatch.cs
// --------------------------------------------------

using System;
using System.Linq;

using Mono.Cecil;
using Mono.Cecil.Cil;

using ReiPatcher;
using ReiPatcher.Patch;

namespace CM3D2.ModPriority.Patcher
{
    internal class ModPriorityPatch : PatchBase
    {
        private const string TOKEN = "CM3D2_MODPRIORITY";
        public override string Name => "CM3D2 Mod Priority Patch";

        public override bool CanPatch(PatcherArguments args)
        {
            if (args.Assembly.Name.Name != "Assembly-CSharp")
                return false;

            if (GetPatchedAttributes(args.Assembly).Any(attribute => attribute.Info == TOKEN))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Assembly Already Patched");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }
            return true;
        }

        public override void Patch(PatcherArguments args)
        {
            var mod = args.Assembly.MainModule;

            var type = mod.GetType("GameUty");
            var meth = type.Methods.First(def => def.Name == ".cctor");

            meth.Body.Instructions.First(ins => ins.OpCode == OpCodes.Stsfld
                                                && ((FieldReference) ins.Operand).Name == "ModPriorityToModFolder")
                .Previous.OpCode = OpCodes.Ldc_I4_1; // Pop a true instead

            SetPatchedAttribute(args.Assembly, TOKEN);
        }

        public override void PrePatch()
        {
            RPConfig.RequestAssembly("Assembly-CSharp.dll");
        }
    }
}
