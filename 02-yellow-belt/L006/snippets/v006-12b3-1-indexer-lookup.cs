customersById[aiko.Id] = aiko;
customersById[ben.Id] = ben;
customersById[chidi.Id] = chidi;

Customer found = customersById[2];

Console.WriteLine(found.Name);
