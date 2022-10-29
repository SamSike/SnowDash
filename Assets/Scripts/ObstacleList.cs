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

    private List<GameObject> obstacles;
    private List<GameObject> edgeObstacles;

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

    public GameObject GetRandomObstacle(){ return obstacles[Random.Range(0, obstacles.Count)]; }
    public GameObject GetRandomEdgeObstacle(){ return edgeObstacles[Random.Range(0, edgeObstacles.Count)]; }
}
