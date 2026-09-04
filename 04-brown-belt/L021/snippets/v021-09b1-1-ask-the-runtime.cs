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
