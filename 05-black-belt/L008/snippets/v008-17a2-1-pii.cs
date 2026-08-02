// Liability, not telemetry
evt.Set("user.email", user.Email);
evt.Set("user.card", card.Number);

// A key you can join on, safely
evt.Set("user.id", user.Id);
