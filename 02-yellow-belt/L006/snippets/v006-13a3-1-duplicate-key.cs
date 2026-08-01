customersById.Add(1, aiko);

customersById[1] = aiko;

bool added = customersById.TryAdd(1, aiko);
