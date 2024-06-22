using System.Text;

namespace Enigma.Core;

public abstract class Machine(Reflector reflector, Rotor[] rotors, Plugboard plugboard)
{
    protected readonly Reflector _reflector = reflector;
    protected readonly Rotor[] _rotors = rotors;
    protected readonly Plugboard _plugboard = plugboard;

    public abstract char PressKey(char letter);

    public string Type(string text)
    {
        var cypher = new StringBuilder();

        foreach (var letter in text)
        {
            cypher.Append(PressKey(letter));
        }

        return cypher.ToString();
    }

    public string GetRotorPositions()
    {
        var positions = new StringBuilder();

        foreach (var rotor in _rotors)
        {
            positions.Append(rotor.Position);
        }

        return positions.ToString();
    }
}
