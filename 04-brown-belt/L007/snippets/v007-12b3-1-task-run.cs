string report = await api.GetReportAsync(1);

int primes = await Task.Run(() => CountPrimes(2000000));
