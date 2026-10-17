using CompositePattern.Packing;

namespace CompositePattern.Reporting;

/// <summary>
/// Walks any packable, to any depth, without asking what it is: every node
/// answers the same three questions.
/// </summary>
public static class Tree
{
    public static IEnumerable<string> Describe(IPackable node, int depth = 0)
    {
        string indent = new string(' ', depth * 2);
        yield return indent + node.Name + ", " + node.Grams() + " g";
        foreach (IPackable child in node.Children)
        {
            foreach (string line in Describe(child, depth + 1))
            {
                yield return line;
            }
        }
    }
}
