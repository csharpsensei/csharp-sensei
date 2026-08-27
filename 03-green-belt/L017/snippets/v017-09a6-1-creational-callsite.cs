            departures.Add(new Departure(
                Service: ServiceFactory.For(parts[2]),
                Destination: parts[1],
                Due: TimeOnly.Parse(parts[0]),
                DelayMinutes: int.Parse(parts[3])));
