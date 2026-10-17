namespace CoordinatingTasks.Taxis;

/// <summary>One firm's answer: who, and how many minutes away.</summary>
public sealed record Quote(string Firm, int MinutesAway);
