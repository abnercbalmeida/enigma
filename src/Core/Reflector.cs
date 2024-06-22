namespace Enigma.Core;

public abstract class Reflector
{
    private readonly string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    protected string _wiring;

    protected Reflector(string wiring)
    {
        _wiring = wiring;
    }

    public char Reflect(char letter)
    {
        return _wiring[_alphabet.IndexOf(letter)];
    }
}

public class ReflectorA() : Reflector("EJMZALYXVBWFCRQUONTSPIKHGD");
public class ReflectorB() : Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");