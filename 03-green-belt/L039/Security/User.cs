namespace ProxyPattern.Security;

/// <summary>Who is asking, and what they are allowed to see.</summary>
public sealed record User(string Name, string[] Roles);
