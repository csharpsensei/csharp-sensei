search: for (int row = 0; row < shelves.Length; row++)
{
    for (int slot = 0; slot < shelves[row].Length; slot++)
    {
        if (shelves[row][slot] == "parcel")
        {
            found = $"row {row}, slot {slot}";
            break search;
        }
    }
}
