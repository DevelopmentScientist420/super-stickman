using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public abstract class GameData : MonoBehaviour
{
    public static int PlayerHealth { get; set; } = 30;
    public static int PlayerScore { get; set; }
    public static int BulletAmmo { get; set; } = 5;
    public static bool IsWin { get; set; }
    public static Vector2 BulletDirection { get; set; } = new Vector2(5f, 0f);
    public static float[] PlayerPosition { get; set; }
    public static string CurrentScene { get; set; }
}
