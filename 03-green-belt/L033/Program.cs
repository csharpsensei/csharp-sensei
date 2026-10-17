using AdapterPattern.Heating;
using AdapterPattern.Legacy;
using AdapterPattern.Reporting;
using AdapterPattern.Testing;
using AdapterPattern.Vendor;

// Composition root only. Five passes, each proving one claim the lesson
// makes, in the order the lesson makes it.

Pass1Coupled();
Pass2ThroughTheAdapter();
Pass3SecondSupplier();
Pass4Refused();
Pass5Fake();

static void Pass1Coupled()
{
    var box = new HeatwiseController(currentFahrenheit: 64);
    var plan = new CoupledComfortPlan(box);

    Log.Pass("Pass 1: the plan talking to the Heatwise box directly");
    Log.Item(plan.Warm(21.0));
}

static void Pass2ThroughTheAdapter()
{
    var box = new HeatwiseController(currentFahrenheit: 64);
    IThermostat thermostat = new HeatwiseThermostat(box);
    var plan = new ComfortPlan(thermostat);

    Log.Pass("Pass 2: the same plan, through the adapter");
    Log.Item("Heatwise    " + plan.Request(21.0));
}

static void Pass3SecondSupplier()
{
    var device = new ThermoLinkDevice(currentTenths: 184);
    IThermostat thermostat = new ThermoLinkThermostat(device);
    var plan = new ComfortPlan(thermostat);

    Log.Pass("Pass 3: a second supplier, a second adapter, the same plan");
    Log.Item("ThermoLink  " + plan.Request(21.0));
}

static void Pass4Refused()
{
    var heatwise = new ComfortPlan(
        new HeatwiseThermostat(new HeatwiseController(64)));
    var thermoLink = new ComfortPlan(
        new ThermoLinkThermostat(new ThermoLinkDevice(184)));

    Log.Pass("Pass 4: asking both to hold 32 C");
    Log.Item("Heatwise    " + heatwise.Request(32.0));
    Log.Item("ThermoLink  " + thermoLink.Request(32.0));
}

static void Pass5Fake()
{
    var fake = new FakeThermostat(currentCelsius: 18.0);
    var plan = new ComfortPlan(fake);

    plan.Request(21.0);

    Log.Pass("Pass 5: the plan against a fake, no hardware at all");
    Log.Item("calls recorded  " + fake.Targets.Count);
    Log.Item("target asked    " + Describe.Celsius(fake.Targets[0]));
}
