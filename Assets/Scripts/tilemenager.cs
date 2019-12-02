using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemenager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ= - 12.0f;
    private float tileLengh = 10f;
    private int amnTilesOnScreen = 7;
    private List<GameObject> activeTiles;
    private float safezon = 15.0f;
    private int lastPrefabIndes = 0;
	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i=0; i <amnTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
          
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z - safezon >(spawnZ - amnTilesOnScreen *tileLengh))
        {
            SpawnTile();
            DeliteTile();
        }
	}
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLengh;
        activeTiles.Add(go);
    }
    private void DeliteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndes;
        while (randomIndex == lastPrefabIndes)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
            lastPrefabIndes = randomIndex;
            return randomIndex;
        
    }

}
