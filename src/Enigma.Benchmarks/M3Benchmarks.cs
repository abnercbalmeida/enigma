using BenchmarkDotNet.Attributes;
using Enigma.Core;
using Enigma.Core.Machines;

namespace Enigma.Benchmarks;

[MemoryDiagnoser]
public class M3Benchmarks
{
    [Benchmark]
    [Arguments(1)]
    [Arguments(10)]
    [Arguments(100)]
    [Arguments(1000)]
    [Arguments(10000)]
    public void WithoutPlugboard(int times)
    {
        var m3 = new M3(new ReflectorB(), [new Rotor1('A'), new Rotor2('A'), new Rotor3('A')], new Plugboard());

        for (int i = 0; i < times; i++)
        {
            m3.PressKey('A');
        }
    }

    [Benchmark]
    [Arguments(1)]
    [Arguments(10)]
    [Arguments(100)]
    [Arguments(1000)]
    [Arguments(10000)]
    public void WithPlugboard(int times)
    {
        var plugboard = new Plugboard();
        plugboard.AddPlug('A', 'V');
        plugboard.AddPlug('B', 'W');
        plugboard.AddPlug('C', 'X');
        plugboard.AddPlug('D', 'Y');
        plugboard.AddPlug('E', 'Z');

        var m3 = new M3(new ReflectorB(), [new Rotor1('A'), new Rotor2('A'), new Rotor3('A')], plugboard);

        for (int i = 0; i < times; i++)
        {
            m3.PressKey('A');
        }
    }
}
