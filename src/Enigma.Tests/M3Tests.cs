using Enigma.Core;
using Enigma.Core.Machines;
using FluentAssertions;
using System.Text;

namespace Enigma.Tests;

public class M3Tests
{
    [Test]
    public void TheStartPosistionIsADO_ShouldTurnTheRotorsProperly()
    {
        var m3 = new M3(new ReflectorB(), [new Rotor3('A'), new Rotor2('D'), new Rotor1('O')], new Plugboard());

        m3.GetRotorPositions().Should().Be("ADO");

        m3.PressKey('A');
        m3.GetRotorPositions().Should().Be("ADP");

        m3.PressKey('A');
        m3.GetRotorPositions().Should().Be("ADQ");

        m3.PressKey('A');
        m3.GetRotorPositions().Should().Be("AER");

        m3.PressKey('A');
        m3.GetRotorPositions().Should().Be("BFS");

        m3.PressKey('A');
        m3.GetRotorPositions().Should().Be("BFT");

        m3.PressKey('A');
        m3.GetRotorPositions().Should().Be("BFU");
    }

    [Test]
    public void TheKeyIsPressed10000Times_ShouldReturnTheExpectedCypher()
    {
        var m3 = new M3(new ReflectorB(), [new Rotor1('A'), new Rotor2('A'), new Rotor3('A')], new Plugboard());

        var input = new StringBuilder();

        for (int i = 0; i < 10000; i++)
        {
            input.Append(m3.PressKey('A'));
        }

        var cypher = input.ToString();

        cypher.Should().StartWith("BDZGOWCXLTKSBTMCDLPBMUQOFXYHCXTGYJFLINHNXSHIUNTHEORXPQPKOVHCBUBTZSZSOOSTGOTFSODBBZZLXLCYZXIFGWFDZEEQIBMGFJBWZFCKPFMGBXQCIVIBBRNCOCJUVYDKMVJPFMDRMTGLWFOZLXGJEYYQPVPBWNCKVKLZTCBDLDCTSNRCOOVPTGBVBBISGJSOYHDENCTNUUKCUGHREVWBDJCTQXXOGLEBZMDBRZOSXDTZSZBGDCFPRBZYQGSNCCHGYEWOHVJBYZGKDGYNNEUJIWCTYCYTUUMBOYVUNNQUKKSOBSCORSUOSCNVROQLHEUDSUKYMIGIBSXPIHNTUVGGHIFQTGZXLGYQCNVNSRCLVPYOSVRBKCEXRNLGDYWEBFXIVKKTUGKPVMZOTUOGMHHZDREKJHLEFKKPOXLWBWVBYUKDTQUHDQTREVRQJMQWNDOVWLJHCCXCFXRPPXMSJEZCJUFTBRZZMCSSNJNYLCGLOYCITVYQXPDIYFGEFYVXSXHKEGXKMMDSWBCYRKIZOCGMFDDTMWZTLSSFLJMOOLUUQJMIJSCIQVRUISTLTGNCLGKIKTZHRXENRXJHYZTLXICWWMYWXDYIBLERBFLWJQYWONGIQQCUUQTPPHBIEHTUVGCEGPEYMWICGKWJCUFKLUIDMJDIVPJDMPGQPWITKGVIBOOMTNDUHQPHGSQRJRNOOVPWMDNXLLVFIIMKIEYIZMQU");
        cypher.Should().EndWith("XLQQTMCNJFZHHFTGTGHTUMCWZDIFILDYPWRCBODXRMQORYQIDUPTEBWSSXBVLRVSHSDGOSNWXTRKQJGEIDMXWSORLSSBMZOTUCLRRJQUJEGDLSQJOKNPJYMFDDWHHUSDRVDCOMPNORGPGKRNRKTOQQQCGVHBOQZOSHTCRFJQUHELBIZGRQWJCUPKJIEXPJMYXBCFNJUHDHLISSRRECUCZGOBYGKLUHYMEVKYIKQLNNNVJPJFWTMIHOMXRVFOBFLSSGRIBCQSSZBQLEGBGWONFCKEIIGBHYEQLCQZCBNHPOQXQXHFEMHGPRMQRXHSBWIHGPJHITONCIDCYYBWBDMSNLEOFKEJZQLDYBDZTEDJCLZNPFYIFIDMNIWVGCIIKYBCSJEGWIQJLHGIHPETTKDGFETVRVVYQJNULVWOJQJJRBJQZMNPCISJYGCOZLPFDIEJCHZCSJMPMSMLEFNGXTESKPQNRWGHSUPKNDQBGZTDHPOILETWSOFDDUGRTPJQJQPUGKJISERHECOMKKCZOCVEDVRVJOROBTZTYSCDWUSNMQQNMUHITGYDEUFMSHRCVCIYPWLGWSCYOQMRRVTIJYQJNUFVMFJLRJDOISCOTLUHBTUMRJQUIEUDZVCJYEIWNBVZCCGBYHKUVTTOSQQVWZHSJGRDLXDISTUCKOVLFOZKEYDWHOJBNOONQIJHQPOQLPTWSCEQOBVMOPJSUDVVNEWXQPNMYVOM");
    }

    [Test]
    public void PlugboardHasPlugs_ShouldReturnTheExpectedCypher()
    {
        var plugboard = new Plugboard();
        plugboard.AddPlug('A', 'V');
        plugboard.AddPlug('B', 'W');
        plugboard.AddPlug('C', 'X');
        plugboard.AddPlug('D', 'Y');
        plugboard.AddPlug('E', 'Z');

        var m3 = new M3(new ReflectorB(), [new Rotor1('A'), new Rotor2('A'), new Rotor3('A')], plugboard);

        var input = new StringBuilder();

        for (int i = 0; i < 10000; i++)
        {
            input.Append(m3.PressKey('A'));
        }

        var cypher = input.ToString();

        cypher.Should().StartWith("RUQDKYSHNMREUPLOKBXRXNIHYOJIEFJMXFJBOPDEURUDZKPUDZLTHJYTWVQYXBDMLXYZEBUBWPKUCUBMRUGFJIHGZBBUTTSJDDLROONQOUHWRERZNLJQBRLCKVFGMMUDTSYPVBDSHVGCTYGTWSYFYORCTSRHFRXOWVYCZRMTVIRWDYTCGPQYGFWYMTVFFIHVHCFKPHOMSBBMZGWEJKMMJLODGVDYCHYJEFPUBHCUNBLUSPXQMBNUIBJUTTSBDZUTHRJZRIMCMFZPEVSCQPSORDXPBCERBJMGBEIWOTZFQFVHQJBQPQCNUYMDQCWNTMJVJGRKTKIHFNSWFLUPSEEXCIIXPVCONGPOQNBOWNOZHMVZGXMKVINMQVHIDLUIUMQFBUQPUTNYVHIGZRXWVRGXQZBTULRHGDNBSRNJDCYSNTOPYMVLWEEHDEPFEPPZIVZNNTYNGIEVJYGQISSHDZNWXWYBMSTYNPSXMWFXZWLOWMUCHDWCTQFHKVGCYDFTPSOFYEVWWSBMTSBOCCDOTTCOSXNZMUUCCSIQDYUWWERZFQBFFFYWKXHELQFZDVYEJICDJNPEQMBKXLIIFDQROTPFHKCPIQKRDHEZMDSQSPRSGESYEXPQCQTXZWWWRFYNOQLPKSGYVLOSMHEF");
        cypher.Should().EndWith("WTXSILWQFZBMGWFGNTFHQPYTWFSKEHYKWKMEBQGGEPKQWGNGJDVIDYKEFBFTEDYZBIZMIZDLKYVBSXKZHPOSNBYFSHEJFGOJBSURXRDBQEPXSGCKGNNUSOULKQKZQOWNQTOKNHKWFYDOHTPHJEVLTRRWXRZEVGYIXISPHWYNLTVCKRPPQNBMUNKKHHCSFOGNXBHPUBIMTOROFSNNHGJIOPNCWQLLWDYOWCBQUTBDXQNYMEZCGZOLXMSBGITTHLKLKZNDQUPUSGBSYIHYUKSEUMUKNRDSBIUNTMPDDPXIVMHBDCMTPPGSCZRCTXSCTYUOQLOCYIFGVWVVJMLBJXVDYQJISKYQNOUPYWUBKUBRUIGDQUPUSGDFZQBPGZYQGRYTWQPQKMLIIFUQTXJGLYOIQJJSBXUFDDBOUYTEZDHNGNDCXPOFKDBHUONTMLFJQGJJFJRVYPVGVQREYTWKHUURKCHJISMXCPFQNSXZKOJISZQKOVDOKNHBFIWLBYGEFGVFBNUCNHIJVJYGMISKPPFHBPFGNIPJIHGNDTOQNBVWWKJMKTCVOYHUNOYFYVWDHUJUVPLWLDTJWEBWHINCNCDVXIQQPBSGLFJGXZBXUTJQOJJFGYNHQZPPSGHVTBGWJMBVVMNEEEOSEGVSY");
    }

    [Test]
    public void TextIsCyphered_ShouldReturnTheExpectedOriginalText()
    {
        var plugboard = new Plugboard();
        plugboard.AddPlug('A', 'V');
        plugboard.AddPlug('B', 'W');
        plugboard.AddPlug('C', 'X');
        plugboard.AddPlug('D', 'Y');
        plugboard.AddPlug('E', 'Z');

        var senderM3 = new M3(new ReflectorB(), [new Rotor1('A'), new Rotor2('A'), new Rotor3('A')], plugboard);

        var cypher = senderM3.Type("LOREMIPSUMDOLORSITAMET");

        var receiverM3 = new M3(new ReflectorB(), [new Rotor1('A'), new Rotor2('A'), new Rotor3('A')], plugboard);

        var plainText = receiverM3.Type(cypher);

        plainText.Should().Be("LOREMIPSUMDOLORSITAMET");
    }
}