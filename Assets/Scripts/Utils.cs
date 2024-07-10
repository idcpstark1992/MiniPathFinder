using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{

    public delegate void GenericDelegateArgs<T>(T _input);
    public delegate void GenericDelegateArgs<T, F>(T _TArgs, F _FArgs);
    public delegate void SingleDelegate();

    public static SingleDelegate ON_RESET_VISUAL_STATUS;
    public static SingleDelegate ON_SEND_SIGNAL_BUTTON;
    public static SingleDelegate ON_INSTANTIATE_PLAYER;
    public static SingleDelegate ON_GAME_RESET;
    public static SingleDelegate ON_SET_NEW_PLAYER_POINT;
    public static SingleDelegate ON_GAME_CHECK;

    public static GenericDelegateArgs<Vector3, Vector3> ON_RAY_POSITION_SENDED;
    public static GenericDelegateArgs<int> ON_ROTATION_PRESSED;
    public static GenericDelegateArgs<List<Vector3>> ON_TRAVEL_PATH_CREATED;


    public static Vector3 INITIAL_PLAYER_POINT;
    public static string PlayerTag = "Player";
    public static bool PLAYER_MOVEMENT { get; private set; }
    public static void SetPlayerMovement(bool _isMoving) => PLAYER_MOVEMENT = _isMoving;
}

public enum TilesColors
{
    RED,
    GREEN,
    BLUE,
    PURPLE,
    YELLOW
}
