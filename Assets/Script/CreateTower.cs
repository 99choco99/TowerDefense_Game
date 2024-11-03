using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTower : MonoBehaviour
{

    public GameObject[] towers;
    GameData data;
    Tilemap tilemap;
    bool isBuildTower;

    Vector2 mousePosition;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        isBuildTower = false;
    }

    private void Update()
    {
        if (!isBuildTower && Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Create(mousePosition);
        }
    }


    void Create(Vector2 mpos)
    {
        if (GameManager.instance.isLive && !isBuildTower && GameManager.instance.gold >= 25)
        {
            isBuildTower = true;
            Vector3Int tpos = tilemap.WorldToCell(mpos);
            if (tilemap.GetTileFlags(tpos) == TileFlags.None) { isBuildTower = false; return; }
            GameObject tower = Instantiate(towers[Random.Range(0, towers.Length)]);
            tower.transform.position = tilemap.GetCellCenterWorld(tpos) + new Vector3(0,0.585f,0);
            tilemap.SetTileFlags(tpos, TileFlags.None);
            GameManager.instance.gold -= 25;
        }
        isBuildTower = false;
    }


}
