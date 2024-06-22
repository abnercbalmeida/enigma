using System.Text;

namespace Enigma.Core;

public abstract class Machine(Reflector reflector, Rotor[] rotors)
{
    protected readonly Reflector _reflector = reflector;
    protected readonly Rotor[] _rotors = rotors;

    public abstract char PressKey(char letter);

    public string GetRotorPositions()
    {
        var positions = new StringBuilder();

        foreach (var rotor in _rotors)
        {
            positions.Append(rotor.GetPosition());
        }

        return positions.ToString();
    }
}
