using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public static PathFinder instance;

    public Transform[] Path;
    private void Awake()
    {
        instance = this;
    }

}
