using System.Reflection;
using System.Runtime.CompilerServices;
using InsideAsyncAwait.Reporting;

namespace InsideAsyncAwait.Inspect;

/// <summary>
/// Asks the runtime what the compiler generated, and prints it. No decompiler
/// and nothing installed: the compiler stamps every async method with an
/// attribute that names the type it built, and that type's fields are readable
/// like any other type's.
/// </summary>
public static class DocketPrinter
{
    private const BindingFlags Everything =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    public static void Print(Type declaring, string methodName)
    {
        MethodInfo method = declaring.GetMethod(methodName)!;
        AsyncStateMachineAttribute? marker =
            method.GetCustomAttribute<AsyncStateMachineAttribute>();

        if (marker is null)
        {
            Log.Line("  " + methodName + ": no state machine at all");
            return;
        }

        Type machine = marker.StateMachineType;
        Log.Line("  " + methodName + ": generated " + machine.Name);
        Log.Line("    a struct: " + machine.IsValueType);
        Log.Line("    fields it carries:");

        foreach (FieldInfo field in machine.GetFields(Everything))
        {
            Log.Line("      " + field.Name.PadRight(22) + field.FieldType.Name);
        }
    }
}
