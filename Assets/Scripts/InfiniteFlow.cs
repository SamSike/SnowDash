using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFlow : MonoBehaviour
{
    public GameObject tile;
    private Vector3 nextTileSpawn;
    private Vector3 nextObstV;
    public GameObject bigObject;
    public GameObject duckObject;
    public GameObject jumpObject;
    public GameObject doubleObject;
    public Player player;
    private List<GameObject> tilesInGame;
    private List<GameObject> obstaclesInGame;

    private List<GameObject> obstacles;
    private List<GameObject> edgeObstacles;

    private int randX;
    private float tileSize = 20;

    private int offset = 5;

    // Start is called before the first frame update
    void Start()
    {
        nextTileSpawn.z = 60;

        obstacles = new List<GameObject>();
        obstacles.Add(bigObject);
        obstacles.Add(jumpObject);

        edgeObstacles = new List<GameObject>();
        edgeObstacles.AddRange(obstacles);
        edgeObstacles.Add(duckObject);

        StartCoroutine(spawnItems());
        tilesInGame = new List<GameObject>();
        obstaclesInGame = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIrrelevant();
    }
    IEnumerator spawnItems()
    {
        if(!player.GetIsGameOver()){
            yield return new WaitForSeconds(tileSize / (2 * player.GetZSpeed()));
            spawnTile();
            StartCoroutine(spawnItems());
        }
    }

    private void spawnTile(){
        randX = RandomCustom();

        tilesInGame.Add(Instantiate(tile, nextTileSpawn, tile.transform.rotation));
        nextObstV = nextTileSpawn;
        nextObstV.x = randX * player.GetLaneWidth();
        GameObject obst;

        if (randX == -1 || randX == 1)
        {
            obst = edgeObstacles[Random.Range(0, edgeObstacles.Count)];
        }
        else if (randX == -2 || randX == 2)
        {
            obst = doubleObject;
            nextObstV.x/=4;
        }
        else
        {
            obst = obstacles[Random.Range(0, obstacles.Count)];
        }

        if (obst == duckObject) nextObstV.y = 0.75f;
        obstaclesInGame.Add(Instantiate(obst, nextObstV, obst.transform.rotation));

        nextTileSpawn.z += 20;
    }

    private int RandomCustom(){
        // Values to be returned: [-1, 0, 1]
        // Return -2 or 2 for stack of trees in that position
        return Random.Range(-2, 3);
    }

    private void DestroyIrrelevant(){
        try
        {
            if (tilesInGame[0].transform.position.z + tileSize < player.transform.position.z - offset)
            {
                Destroy(tilesInGame[0]);
                tilesInGame.RemoveAt(0);
            }
            if (obstaclesInGame[0].transform.position.z < player.transform.position.z - offset)
            {
                Destroy(obstaclesInGame[0]);
                obstaclesInGame.RemoveAt(0);
            }
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            ;
        }
    }
}
