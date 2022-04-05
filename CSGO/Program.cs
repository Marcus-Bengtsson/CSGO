using CSGO;

var game = new Game();
while (game.IsActive)
{
    game.RunGameLoop();
    //Thread.Sleep(1000);
}



/*
T vs CT
5 per team
alle har property isDead
Ts: 
    FindBombSite() som bruker isSuccessful(10) for at de finner A.
    KillCounterTerrorist(CounterTerrorist ct) som bruker isSuccessful(7).
    PlantBomb() som kalles når A er funnet
    5 tidsenheter for å plante, 15 fra den er plantet til den sprenger
    Hvis den sprenger vinner Ts.
    
CTs:   
    DefuseBomb() som bruker 5 tidsenheter
    KillTerrorist(Terrorist terrorist) som bruker isSuccessful(5)
    når bombe er plantet øker isSuccessful til (3)
    alle Ts må være døde før DefuseBomb() kan kalles
    
Print ut alt som skjer underveis i spillet
Kjører i While(true) fram til noen vinner
Lagene tar tur med å kalle på metodene
Terroristene alternerer mellom FindBombSite og KillCT
CTs bruker KillTs


*/

