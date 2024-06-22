namespace Enigma.Core;

public class Plugboard
{
    private readonly Dictionary<char, char> _plugs = [];

    public void AddPlug(char from, char to)
    {
        _plugs.Add(from, to);
        _plugs.Add(to, from);
    }

    public char Swap(char letter)
    {
        if (_plugs.TryGetValue(letter, out char value))
        {
            return value;
        }

        return letter;
    }
}
