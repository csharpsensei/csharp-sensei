public string Warm(double celsius)
{
    int now = box.ReadTemperatureF();
    int fahrenheit = (int)Math.Round(celsius * 9 / 5 + 32);
    int status = box.SetPointF(fahrenheit);

    return $"reads {now} F, asked {Describe.Celsius(celsius)}, "
        + $"sent {fahrenheit} F, status {status}";
}
