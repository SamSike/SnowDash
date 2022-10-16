using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFlow : MonoBehaviour
{
    public Transform tile1;
    private Vector3 nextTileSpawn;
    private Vector3 nextObstV;
    public Transform tree1;
    public Transform branch1;
    public Transform treeStump1;

    private List<Transform> obstacles;
    private List<Transform> edgeObstacles;
    private int randX;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<Transform>();
        edgeObstacles = new List<Transform>();
        nextTileSpawn.z = 60;
        obstacles.Add(tree1);
        obstacles.Add(treeStump1);
        edgeObstacles.AddRange(obstacles);
        edgeObstacles.Add(branch1);
        StartCoroutine(spawnTile());

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(2);
        randX = Random.Range(-1, 2);

        Instantiate(tile1, nextTileSpawn, tile1.rotation);
        nextObstV = nextTileSpawn;
        nextObstV.x = randX;
        Transform obst;

        if (randX == -1 || randX == 1)
        {
            obst = edgeObstacles[Random.Range(0, edgeObstacles.Count)];
        }
        else
        {
            obst = obstacles[Random.Range(0, obstacles.Count)];
        }

        if (obst == branch1) nextObstV.y = 0.75f;
        Instantiate(obst, nextObstV, obst.rotation);

        nextTileSpawn.z += 20;
        StartCoroutine(spawnTile());
    }
}
