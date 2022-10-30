using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemedTiles : MonoBehaviour
{
    public GameObject snowTile;
    public GameObject lavaTile;
    public GameObject desertTile;
    public GameObject forestTile;

    private List<GameObject> tileList;

    // Start is called before the first frame update
    void Start()
    {
        tileList = new List<GameObject>();
        tileList.Add(snowTile);
        tileList.Add(lavaTile);
        tileList.Add(desertTile);
        tileList.Add(forestTile);
    }

    public GameObject GetTheme(int index){ return tileList[index]; }
    public int GetListCount(){ return tileList.Count; }
    public int FindTile(GameObject tile){ return tileList.IndexOf(tile); }
}
