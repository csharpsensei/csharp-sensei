            string[] parts = row.Split('|');

            // Problem one: deciding what to build, written out here.
            string label = parts[2] == "TRN" ? "Train" : "Bus replacement";
