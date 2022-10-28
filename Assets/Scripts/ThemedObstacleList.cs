using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemedObstacleList : MonoBehaviour
{
    public ObstacleList ObstacleSnowList;
    public ObstacleList ObstacleLavaList;
    public ObstacleList ObstacleDesertList;

    public List<ObstacleList> ThemedList;

    // Start is called before the first frame update
    void Start()
    {
        ThemedList = new List<ObstacleList>();
        ThemedList.Add(ObstacleSnowList);
        ThemedList.Add(ObstacleLavaList);
        ThemedList.Add(ObstacleDesertList);    
    }

}
