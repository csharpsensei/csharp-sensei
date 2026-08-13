// DO NOT COPY — deliberately does not compile. Excluded from the real
// project via snippets/** (L011.csproj). This is the point of the still:
// the compiler refuses this before the program ever runs.

public class ExtendedBluRayPlayer : BluRayPlayer
{
    // error CS0509: 'ExtendedBluRayPlayer': cannot derive from sealed type
    // 'BluRayPlayer'
}
