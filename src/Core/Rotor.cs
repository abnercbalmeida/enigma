namespace Enigma.Core;

public abstract class Rotor
{
    private readonly string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    protected string _wiring;
    protected char _notch;
    protected int _position;

    protected Rotor(string wiring, char notch, char position)
    {
        _wiring = wiring;
        _notch = notch;
        _position = _alphabet.IndexOf(position);
    }

    public char GetPosition()
    {
        return _alphabet[_position];
    }

    public bool IsOnNotch()
    {
        return _alphabet[_position] == _notch;
    }

    public void Turn()
    {
        _position = (_position + 1) % _alphabet.Length;
    }

    public char Next(char letter)
    {
        var key = _wiring[(_alphabet.IndexOf(letter) + _position % _alphabet.Length + _alphabet.Length) % _alphabet.Length];
        return _alphabet[(_alphabet.IndexOf(key) - _position % _alphabet.Length + _alphabet.Length) % _alphabet.Length];
    }

    public char Prev(char letter)
    {
        var key = _alphabet[(_alphabet.IndexOf(letter) + _position % _alphabet.Length + _alphabet.Length) % _alphabet.Length];
        return _alphabet[(_wiring.IndexOf(key) - _position % _alphabet.Length + _alphabet.Length) % _alphabet.Length];
    }
}

public class Rotor1(char position) : Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Q', position);
public class Rotor2(char position) : Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'E', position);
public class Rotor3(char position) : Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'V', position);