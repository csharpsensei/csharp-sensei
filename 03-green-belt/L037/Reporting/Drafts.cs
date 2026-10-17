using FacadePattern.Publishing;

namespace FacadePattern.Reporting;

/// <summary>Two fixed drafts, so every run prints the same.</summary>
public static class Drafts
{
    public static Draft Clean() =>
        new Draft("facades", "one door into a complicated room", 2);

    public static Draft WithTypos() =>
        new Draft("typos", "teh steps you recieve", 2);
}
