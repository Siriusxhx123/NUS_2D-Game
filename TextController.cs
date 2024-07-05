using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public TMP_Text mEcho = null;
    private static bool way = true; //true-sequence, false-random
    private static bool drive = true; //true-mouse, false-key
    private static int enemies = 0;
    private static int egg = 0;
    private static string waypoints = null;
    private static string driveway = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(way)
        {
            waypoints = "Sequence";
        }else
        {
            waypoints = "Random";
        }
        if (drive)
        {
            driveway = "Mouse";
        }
        else
        {
            driveway = "Key";
        }


        mEcho.text = "WAYPOINTS:(" + waypoints + ")  Hero: Drive(" + driveway + ") TouchedEnemy(" +
            enemies + ")  Egg: OnScreen(" + egg + ")";
    }

    public static void changeWay()
    {
        way = !way;
    }
    public static void changeDrive()
    {
        drive = !drive;
    }
    public static void touchEnemy()
    {
        enemies++;
    }
    public static void addEgg()
    {
        egg++;
    }
    public static void removeEgg()
    {
        egg--;
    }
}
