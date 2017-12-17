using System;

public static class GameState
{
    public static Loadout[] Loadouts;

    public static void ReadyLoadouts(Loadout[] players)
    {
        Loadouts = players;
    }
}
