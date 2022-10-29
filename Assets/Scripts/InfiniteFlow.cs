using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFlow : MonoBehaviour
{
    public GameObject tile;
    public ObstacleList ObstacleList;

    private Vector3 nextTileSpawn;
    private Vector3 nextObstV;
    public Player player;

    // Tiles for all themes
    public ThemedTiles ThemedTiles;

    // Obstacles for all themes
    public ThemedObstacleList ThemedObstacleList;

    // List of Powerups
    public PowerUpList PowerUpList;

    private List<GameObject> tilesInGame;
    private List<GameObject> obstaclesInGame;
    private List<GameObject> powerupsInGame;

    private int randX;
    private float tileSize = 20;

    private int offset = 5;
    private float powerUpOffset = 500;

    private bool trulyRandom = true;
    private int trueRandomLength = 600;
    private int pseudoRandomLength = 300;
    private int themeLength = 400;

    // Start is called before the first frame update
    void Start()
    {
        nextTileSpawn.z = 60;
        tile = ThemedTiles.snowTile;
        ObstacleList = ThemedObstacleList.ObstacleSnowList;

        StartCoroutine(spawnItems());
        tilesInGame = new List<GameObject>();
        obstaclesInGame = new List<GameObject>();
        powerupsInGame = new List<GameObject>();
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
        
        spawnObstacle(randX);
        spawnPowerup();
        randomTheme();

        nextTileSpawn.z += tileSize;
    }

    private void randomTheme(){
        if(nextObstV.z % themeLength == 0){
            var current = ThemedTiles.tileList.IndexOf(tile);
            while(true){
                var newTheme = Random.Range(0, ThemedTiles.tileList.Count);
                if(newTheme != current){    
                    tile = ThemedTiles.tileList[newTheme];
                    ObstacleList = ThemedObstacleList.ThemedList[newTheme];

                    Debug.Log("Changed theme to: ", tile);
                    break;
                }
            }
        }
    }

    private void spawnPowerup(){
        if(nextObstV.z % powerUpOffset == 0 && Random.Range(0,2) == 0){
            randX = Random.Range(-1,2);
            nextObstV.x = randX * player.GetLaneWidth();
            nextObstV.z += tileSize/2;

            GameObject powerup = PowerUpList.powerups[Random.Range(0, PowerUpList.powerups.Count)];

            powerupsInGame.Add(Instantiate(powerup, nextObstV, powerup.transform.rotation));
        }
    }

    private void spawnObstacle(int type){        
        nextObstV.x = type * player.GetLaneWidth();

        GameObject obstacle;
        if (type == -1 || type == 1)
        {
            obstacle = ObstacleList.edgeObstacles[Random.Range(0, ObstacleList.edgeObstacles.Count)];
        }
        else if (type == -2 || type == 2)
        {
            obstacle = ObstacleList.doubleObject;
            nextObstV.x /= 4;
        }
        else
        {
            obstacle = ObstacleList.obstacles[Random.Range(0, ObstacleList.obstacles.Count)];
        }

        if (obstacle == ObstacleList.duckObject) 
            nextObstV.y = 0.75f;

        obstaclesInGame.Add(Instantiate(obstacle, nextObstV, obstacle.transform.rotation));
    }

    private int RandomCustom(){
        // Values to be returned: [-1, 0, 1]
        // Return -2 or 2 for stack of trees in that position
        if(trulyRandom){
            if(nextObstV.z % trueRandomLength == 0 && Random.Range(0, 10) < 3)
                trulyRandom = false;
            return Random.Range(-2,3);
        }
        else{
            if(nextObstV.z % pseudoRandomLength == 0)
                trulyRandom = true;

            if(nextObstV.z % (2 * tileSize) == 0)
                return -2;
            else    
                return 2;
        }
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
            if (powerupsInGame[0].transform.position.z < player.transform.position.z - offset)
            {
                Destroy(powerupsInGame[0]);
                powerupsInGame.RemoveAt(0);
            }
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            ;
        }
    }
}
