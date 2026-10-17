public void SetTargetCelsius(double celsius)
{
    int fahrenheit = (int)Math.Round(celsius * 9 / 5 + 32);
    int status = box.SetPointF(fahrenheit);

    if (status == HeatwiseController.OutOfRange)
        throw new TargetRejectedException("Heatwise takes 10 to 30 C");
}
