using UnityEngine;
using UnityEngine.InputSystem;

public static class GameParameters
{
    public static float PlayerSpeed = 2f;
    public static float PlayerJumpPower = 3f;
    public static int PlayerStartingLivesCount = 3;

    public static float spiderSpeed = 1.5f;
    
    public static Key MoveLeft  = Key.A;
    public static Key MoveRight = Key.D;
    public static Key MoveUp  = Key.W;
    public static Key MoveDown = Key.S;
    
    public static Key PlaceKey  = Key.E;
    public static Key PickupKey = Key.F;
    public static Key JumpKey = Key.Space;
    
    public static float SpiderMinimumSpawnDelay = 1f;
    public static float SpiderMaximumSpawnDelay = 3f;
    
}
