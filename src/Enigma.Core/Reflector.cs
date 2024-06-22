namespace Enigma.Core;

public class ReflectorA() : Reflector("EJMZALYXVBWFCRQUONTSPIKHGD");
public class ReflectorB() : Reflector("YRUHQSLDPXNGOKMIEBFZCWVJAT");

public abstract class Reflector
{
    protected string _wiring;

    protected Reflector(string wiring)
    {
        _wiring = wiring;
    }

    private static int GetIndex(char letter)
    {
        return letter - 'A';
    }

    public char Reflect(char letter)
    {
        return _wiring[GetIndex(letter)];
    }
}