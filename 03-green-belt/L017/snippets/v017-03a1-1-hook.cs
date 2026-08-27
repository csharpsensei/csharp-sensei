            // Problem one: deciding what to build, written out here.
            string label = parts[2] == "TRN" ? "Train" : "Bus replacement";

            // Problem two: the feed's own format, in the middle of the rule.
            string due = parts[0];
            string destination = parts[1];
            int delay = int.Parse(parts[3]);

            // Problem three: the wording rule, growing one branch at a time.
            string note = string.Empty;
            if (delay > 0 && !quietHours) note = "delayed " + delay + " min";
            else if (delay >= 5) note = "delayed " + delay + " min";
            else if (!quietHours) note = "on time";
