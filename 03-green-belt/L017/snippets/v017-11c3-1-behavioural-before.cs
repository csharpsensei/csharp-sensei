            // Problem three: the wording rule, growing one branch at a time.
            string note = string.Empty;
            if (delay > 0 && !quietHours) note = "delayed " + delay + " min";
            else if (delay >= 5) note = "delayed " + delay + " min";
            else if (!quietHours) note = "on time";
