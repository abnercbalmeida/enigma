namespace Enigma.Core.Machines;

public class M3 : Machine
{
    public M3(Reflector reflector, Rotor[] rotors) : base(reflector, rotors)
    {
        if (_rotors.Length != 3)
        {
            throw new ArgumentException($"3 rotors required");
        }
    }

    public override char PressKey(char letter)
    {
        if (!char.IsLetter(letter))
        {
            throw new ArgumentException($"{letter} is not a letter");
        }

        if (_rotors[^2].IsOnNotch())
        {
            _rotors[^3].Turn();
            _rotors[^2].Turn();
        }
        else if (_rotors[^1].IsOnNotch())
        {
            _rotors[^2].Turn();
        }

        _rotors[^1].Turn();

        letter = _rotors[^1].Next(letter);
        letter = _rotors[^2].Next(letter);
        letter = _rotors[^3].Next(letter);
        letter = _reflector.Reflect(letter);
        letter = _rotors[^3].Prev(letter);
        letter = _rotors[^2].Prev(letter);
        letter = _rotors[^1].Prev(letter);

        return letter;
    }
}
