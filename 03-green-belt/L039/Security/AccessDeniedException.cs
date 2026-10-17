namespace ProxyPattern.Security;

/// <summary>The guard's way of saying no, with the reason.</summary>
public sealed class AccessDeniedException(string reason) : Exception(reason);
