using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFlow : MonoBehaviour
{
    public Transform tile1;
    private Vector3 nextTileSpawn;
    // Start is called before the first frame update
    void Start()
    {
        nextTileSpawn.z = 60;
        StartCoroutine(spawnTile());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(2);
        Instantiate(tile1, nextTileSpawn, tile1.rotation);
        nextTileSpawn.z += 20;
        StartCoroutine(spawnTile());
    }
}
