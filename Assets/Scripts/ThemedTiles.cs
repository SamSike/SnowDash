using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemedTiles : MonoBehaviour
{
    public GameObject snowTile;
    public GameObject lavaTile;
    public GameObject desertTile;

    public List<GameObject> tileList;

    // Start is called before the first frame update
    void Start()
    {
        tileList = new List<GameObject>();
        tileList.Add(snowTile);
        tileList.Add(lavaTile);
        tileList.Add(desertTile);
    }
}
