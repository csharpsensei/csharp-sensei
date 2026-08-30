using LinqBasics.Model;

namespace LinqBasics.Data;

/// <summary>
/// The pile on the desk. Twelve applications rather than two hundred, so that
/// every row printed by this program can be read on screen and checked by hand.
/// Named in the README as a deliberate simplification.
///
/// Every phone number is inside Ofcom's 07700 900000 to 07700 900999 range,
/// which is reserved for drama and can never be allocated to a real person.
/// </summary>
public static class CandidatePool
{
    public static IReadOnlyList<Candidate> All { get; } =
    [
        new("Amara Okafor",      "07700 900141", ["C#", "Azure", "SQL"]),
        new("Ben Whitfield",     "07700 900203", ["Java", "Kubernetes"]),
        new("Chidi Nwosu",       "07700 900318", ["C#", "React"]),
        new("Dana Petrova",      "07700 900427", ["Azure", "Terraform"]),
        new("Priya Raghunathan", "07700 900512", ["C#", "Azure"]),
        new("Fenella Cross",     "07700 900630", ["Python", "Pandas"]),
        new("Gareth Lloyd",      "07700 900736", ["C#", "SQL", "Azure"]),
        new("Hana Sato",         "07700 900841", ["Go", "Docker"]),
        new("Ines Moreau",       "07700 900877", ["C#", "Blazor"]),
        new("Jonah Blake",       "07700 900894", ["Azure", "Bicep", "PowerShell"]),
        new("Kwame Mensah",      "07700 900908", ["C#", "Azure", "SQL", "React"]),
        new("Lena Varga",        "07700 900961", ["TypeScript", "Node"]),
    ];
}
