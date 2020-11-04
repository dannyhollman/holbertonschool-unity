using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int ammo = 7;
    public static int targets = 5;
    public static int score = 0;

    public static void PlayAgain()
    {
        ammo = 7;
        targets = 5;
        score = 0;
    }
}
