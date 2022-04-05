using static CSGO.Terrorist;
using static CSGO.CounterTerrorist;
namespace CSGO;

public class Game
{
    private int RoundCounter { get; set; }
    public bool IsActive { get; private set; }
    private bool SiteFound { get; set; }
    public bool IsBombPlanted { get; set; }
    public int BombTimer { get; set; }
    public int DefuseTimer { get; set; }
    private string Winner { get; set; }
    
    private Terrorist[] Terrorists { get; }
    private CounterTerrorist[] CounterTerrorists { get; }
    
    public Game()
    {
        RoundCounter = 1;
        IsActive = true;
        IsBombPlanted = false;
        BombTimer = 5;
        DefuseTimer = 5;
        Terrorists = new Terrorist[5];
        CounterTerrorists = new CounterTerrorist[5];
        Winner = "";
    }

    public void RunGameLoop()
    {
        if (SiteFound && !IsBombPlanted) PlantBomb(BombTimer, IsBombPlanted);
        if (IsBombPlanted) BombTimer--;
        if (BombTimer == 0) TerroristsWin();
        
        if (RoundCounter % 2 == 0 || SiteFound)
        {
            var counterTerrorist = FindLivingCounterTerrorist(CounterTerrorists);
            if (counterTerrorist != null) AttackCounterTerrorist(counterTerrorist);
            else TerroristsWin();
        }
        else SiteFound = FindBombSite();
        
        var terrorist = FindLivingTerrorist(Terrorists);
        if (terrorist == null) DefuseBomb(DefuseTimer);
        if (DefuseTimer > 0 && terrorist != null) AttackTerrorist(terrorist, IsBombPlanted);
        else CounterTerroristsWin();
        if(Winner != "") Console.WriteLine($"{Winner} wins");
        RoundCounter++;
    }
    
    public static bool IsSuccessful(int maxValue)

    {
        var rand = new Random();

        return rand.Next(0, maxValue) == 2;
    }
    public void TerroristsWin()
    {
        IsActive = false;
        Console.WriteLine("Terrorists win!");
    }
    public void CounterTerroristsWin()
    {
        IsActive = false;
        Console.WriteLine("CounterTerrorists win!");
    }
    
}