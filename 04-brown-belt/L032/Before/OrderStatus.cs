namespace WhatsNew.Before;

/// <summary>
/// Before C# 15: an abstract base. Any assembly can derive from it, so the
/// compiler cannot know every case.
/// </summary>
public abstract record OrderStatus;
