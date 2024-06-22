namespace Enigma.Core;

public abstract class Rotor
{
    protected string _wiring;
    protected char _notch;
    protected int _position;

    protected Rotor(string wiring, char notch, char position)
    {
        _wiring = wiring;
        _notch = notch;
        _position = GetIndex(position);
    }

    private static char GetLetter(int position)
    {
        return (char)(position + 'A');
    }

    private static int GetIndex(char letter)
    {
        return letter - 'A';
    }

    public char GetPosition()
    {
        return GetLetter(_position);
    }

    public bool IsOnNotch()
    {
        return GetLetter(_position) == _notch;
    }

    public void Turn()
    {
        _position = (_position + 1) % 26;
    }

    public char Next(char letter)
    {
        var key = _wiring[(GetIndex(letter) + _position % 26 + 26) % 26];
        return GetLetter((GetIndex(key) - _position % 26 + 26) % 26);
    }

    public char Prev(char letter)
    {
        var key = GetLetter((GetIndex(letter) + _position % 26 + 26) % 26);
        return GetLetter((_wiring.IndexOf(key) - _position % 26 + 26) % 26);
    }
}

public class Rotor1(char position) : Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'Q', position);
public class Rotor2(char position) : Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'E', position);
public class Rotor3(char position) : Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'V', position);