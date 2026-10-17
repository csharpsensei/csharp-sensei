public void SetTargetCelsius(double celsius)
{
    double capped = Math.Min(celsius, 24.0);
    box.SetPointF((int)Math.Round(capped * 9 / 5 + 32));
}
