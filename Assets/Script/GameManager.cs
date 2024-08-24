using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Transform [] Path;
    public Pooling pool;
    private void Awake()
    {
        instance = this;
    }


}
