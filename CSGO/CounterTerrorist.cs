using static CSGO.Game;

namespace CSGO;

public class CounterTerrorist
{
    public bool IsDead { get; set; }

    public CounterTerrorist()
    {
        IsDead = false;
    }
    public static void DefuseBomb(int defuseTimer)
    {
        defuseTimer--;
        Console.WriteLine($"Defusing bomb... {defuseTimer} rounds remaining");
    }
    public static void AttackTerrorist(Terrorist terrorist, bool isBombPlanted)
    {
        var successChance = isBombPlanted ? 3 : 5;
        if (IsSuccessful(successChance))
        {
            terrorist.Kill();
            Console.WriteLine("Terrorist killed");
        }
        else Console.WriteLine("Terrorist kill failed");
    }
    public static CounterTerrorist? FindLivingCounterTerrorist(CounterTerrorist[] cts)
    {
        var livingCt = Array.Find(cts, ct => ct.IsDead == false);
        return livingCt;
    }
    public void Kill()
    {
        IsDead = true;
    }
}