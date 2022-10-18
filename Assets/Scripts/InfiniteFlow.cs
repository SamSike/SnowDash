using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFlow : MonoBehaviour
{
    public GameObject tile1;
    private Vector3 nextTileSpawn;
    private Vector3 nextObstV;
    public GameObject tree1;
    public GameObject branch1;
    public GameObject treeStump1;

    public Camera mainCamera;
    private List<GameObject> tilesInGame;
    private List<GameObject> obstaclesInGame;

    private List<GameObject> obstacles;
    private List<GameObject> edgeObstacles;
    
    private int randX;
    private float tileSize = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<GameObject>();
        edgeObstacles = new List<GameObject>();
        nextTileSpawn.z = 60;
        obstacles.Add(tree1);
        obstacles.Add(treeStump1);
        edgeObstacles.AddRange(obstacles);
        edgeObstacles.Add(branch1);
        StartCoroutine(spawnTile());

        tilesInGame = new List<GameObject>();
        obstaclesInGame = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        try{
            if(tilesInGame[0].transform.position.z + tileSize < mainCamera.transform.position.z){
                Destroy(tilesInGame[0]);
                tilesInGame.RemoveAt(0);
            }
            if(obstaclesInGame[0].transform.position.z < mainCamera.transform.position.z){
                Destroy(obstaclesInGame[0]);
                obstaclesInGame.RemoveAt(0);
            }
        }
        catch(System.ArgumentOutOfRangeException e){
            ;
        }
    }
    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(2);
        randX = Random.Range(-1, 2);

        tilesInGame.Add(Instantiate(tile1, nextTileSpawn, tile1.transform.rotation));
        nextObstV = nextTileSpawn;
        nextObstV.x = randX;
        GameObject obst;

        if (randX == -1 || randX == 1)
        {
            obst = edgeObstacles[Random.Range(0, edgeObstacles.Count)];
        }
        else
        {
            obst = obstacles[Random.Range(0, obstacles.Count)];
        }

        if (obst == branch1) nextObstV.y = 0.75f;
        obstaclesInGame.Add(Instantiate(obst, nextObstV, obst.transform.rotation));

        nextTileSpawn.z += 20;
        StartCoroutine(spawnTile());
    }
}
