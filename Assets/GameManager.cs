using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject minionPrefab;
    Vector3 blueSpawnLocation = new Vector3(-45, 1, -45);
    Vector3 redSpawnLocation = new Vector3(45, 1, 45);
    Vector3 topLane = new Vector3(-45, 1, 45);
    Vector3 midLane = new Vector3(0, 1, 0);
    Vector3 botLane = new Vector3(45, 1, -45);
    bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn == true)
        {
            GameObject minionSpawned;
            // Blue side minions
            minionSpawned = Instantiate(minionPrefab, blueSpawnLocation, Quaternion.identity); // Quaternion.identity is the default rotation
            minionSpawned.GetComponent<MinionAIScript>().destination = midLane;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = redSpawnLocation;
            minionSpawned.GetComponent<MinionAIScript>().isBlue = true;
            minionSpawned = Instantiate(minionPrefab, blueSpawnLocation, Quaternion.identity);
            minionSpawned.GetComponent<MinionAIScript>().destination = topLane;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = redSpawnLocation;
            minionSpawned.GetComponent<MinionAIScript>().isBlue = true;
            minionSpawned = Instantiate(minionPrefab, blueSpawnLocation, Quaternion.identity); 
            minionSpawned.GetComponent<MinionAIScript>().destination = botLane;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = redSpawnLocation;
            minionSpawned.GetComponent<MinionAIScript>().isBlue = true;

            minionSpawned = Instantiate(minionPrefab, redSpawnLocation, Quaternion.identity); // Quaternion.identity is the default rotation
            minionSpawned.GetComponent<MinionAIScript>().destination = midLane;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = blueSpawnLocation;
            minionSpawned.GetComponent<MinionAIScript>().isBlue = false;
            minionSpawned = Instantiate(minionPrefab, redSpawnLocation, Quaternion.identity);
            minionSpawned.GetComponent<MinionAIScript>().destination = topLane;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = blueSpawnLocation;
            minionSpawned.GetComponent<MinionAIScript>().isBlue = false;
            minionSpawned = Instantiate(minionPrefab, redSpawnLocation, Quaternion.identity); 
            minionSpawned.GetComponent<MinionAIScript>().destination = botLane;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = blueSpawnLocation;
            minionSpawned.GetComponent<MinionAIScript>().isBlue = false;

            spawn = false;
        }

    }
}
