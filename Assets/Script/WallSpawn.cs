using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject coinPrefabs;
    public float xSpawn = 0f;
    public float tileLength = 3f;
    public int numberOfTiles = 4;
    private List<GameObject> activeTiles = new List<GameObject>();
    private List<GameObject> activeCoins = new List<GameObject>();
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.x-20 > xSpawn-(numberOfTiles*tileLength)) {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
            DeleteCoin();
        }
        
    }

    public void SpawnTile(int tileIndex) {
        GameObject go = Instantiate(tilePrefabs[tileIndex], new Vector3(transform.position.x + xSpawn, Random.Range(-5, -3), 0), Quaternion.identity);
         // float widthTile = tilePrefabs[tileIndex].GetComponent<SpriteRenderer>().bounds.size.x;
        for (int i = 0; i < 2; i++)
        {
            GameObject coin = Instantiate(coinPrefabs, new Vector3(transform.position.x + Random.Range( xSpawn, xSpawn +2), Random.Range(transform.position.y + 8, transform.position.y + 10), 0), Quaternion.identity);
            activeCoins.Add(coin);
        }
        activeTiles.Add(go);
        xSpawn += tileLength;
    }

    private void DeleteTile() {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
     private void DeleteCoin() {
        Destroy(activeCoins[0]);
        activeCoins.RemoveAt(0);
        Destroy(activeCoins[1]);
        activeCoins.RemoveAt(1);
    }

}