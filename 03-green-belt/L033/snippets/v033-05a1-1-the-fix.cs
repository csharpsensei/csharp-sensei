static void Pass2ThroughTheAdapter()
{
    var box = new HeatwiseController(currentFahrenheit: 64);
    IThermostat thermostat = new HeatwiseThermostat(box);
    var plan = new ComfortPlan(thermostat);

    Log.Pass("Pass 2: the same plan, through the adapter");
    Log.Item("Heatwise    " + plan.Request(21.0));
}
