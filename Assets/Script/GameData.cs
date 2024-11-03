using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public int life;
    public int kill;
    public int gold;
    public int level;


    public void init()
    {
        life = 10;
        kill = 0;
        gold = 50;
        level = 0;
    }
}
