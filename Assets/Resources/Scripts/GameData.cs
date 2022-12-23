using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour
{
    public static int PlayerHealth { get; set; }
    public static int PlayerScore { get; set; }
    public static int BulletAmmo { get; set; } = 5;
    public static Vector2 BulletDirection { get; set; } = new Vector2(5f, 0f);
}
