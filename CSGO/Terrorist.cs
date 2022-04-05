using static CSGO.Game;

namespace CSGO;

public class Terrorist
{
    public bool IsDead { get; set; }

    public Terrorist()
    {
        IsDead = false;
    }
    public static bool FindBombSite()
    {
        var isBombSiteFound = IsSuccessful(10);
        Console.WriteLine($"Bombsite {(isBombSiteFound ? "was" : "wasn't")} found");
        return isBombSiteFound;
    }

    public static void AttackCounterTerrorist(CounterTerrorist ct)
    {
        if (IsSuccessful(7)) ct.Kill();
    }

    public static void PlantBomb(int bombTimer, bool isBombPlanted)
    {
        bombTimer--;
        Console.WriteLine($"Planting bomb. {bombTimer} rounds remaining");
        if (bombTimer > 0) return;
        isBombPlanted = true;
        bombTimer = 15;
        Console.WriteLine("Bomb planted");
        //5 tidsenheter for å plante, 15 fra den er plantet til den sprenger
    }
    public static Terrorist? FindLivingTerrorist(Terrorist[] terrorists)
    {
        var livingT = Array.Find(terrorists, terrorist => terrorist.IsDead == false);
        return livingT;
    }

    

    public void Kill()
    {
        IsDead = true;
    }
}