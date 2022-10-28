using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFlow : MonoBehaviour
{
    public GameObject tile;
    private Vector3 nextTileSpawn;
    private Vector3 nextObstV;
    public Player player;

    // Obstacles for all themes
    public ObstacleSnowList ObstacleSnowList;

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

    // Start is called before the first frame update
    void Start()
    {
        nextTileSpawn.z = 60;

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

        nextTileSpawn.z += tileSize;
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
            obstacle = ObstacleSnowList.edgeObstacles[Random.Range(0, ObstacleSnowList.edgeObstacles.Count)];
        }
        else if (type == -2 || type == 2)
        {
            obstacle = ObstacleSnowList.doubleObject;
            nextObstV.x /= 4;
        }
        else
        {
            obstacle = ObstacleSnowList.obstacles[Random.Range(0, ObstacleSnowList.obstacles.Count)];
        }

        if (obstacle == ObstacleSnowList.duckObject) 
            nextObstV.y = 0.75f;

        obstaclesInGame.Add(Instantiate(obstacle, nextObstV, obstacle.transform.rotation));
    }

    private int RandomCustom(){
        // Values to be returned: [-1, 0, 1]
        // Return -2 or 2 for stack of trees in that position
        if(nextObstV.z % 300 == 0)
                trulyRandom = !trulyRandom;

        if(trulyRandom){
            return Random.Range(-2,3);
        }
        else{
            if(nextObstV.z % 40 == 0)
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
