using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleList : MonoBehaviour
{
    // Obstacles
    public GameObject bigObject;
    public GameObject duckObject;
    public GameObject jumpObject;
    public GameObject doubleObject;

    public List<GameObject> obstacles;
    public List<GameObject> edgeObstacles;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<GameObject>();
        obstacles.Add(bigObject);
        obstacles.Add(jumpObject);

        edgeObstacles = new List<GameObject>();
        edgeObstacles.AddRange(obstacles);
        edgeObstacles.Add(duckObject);        
    }
}
