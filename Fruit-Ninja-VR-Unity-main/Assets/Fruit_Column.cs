using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit_Column : MonoBehaviour
{
    public GameObject[] objectsToSpawn; 
    public float spawnTime = 3f; 
    public float objectLifetime = 5f; 
    public float delayTime = 2f; 

    private GameObject currentObject; 
    private float spawnTimer = 0f; 
    private float objectTimer = 0f; 
    private bool waitingForDelay = false; 

  
    void Start()
    {
        SpawnRandomObject(); 
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime; 
        objectTimer += Time.deltaTime; 

        if (objectTimer >= objectLifetime) 
        {
            Destroy(currentObject); 
            waitingForDelay = true; 
            objectTimer = 0f; 
        }

        if (waitingForDelay) 
        {
            if (objectTimer >= delayTime) 
            {
                waitingForDelay = false; // Reset flag
                SpawnRandomObject(); // Spawn a new random object
            }
        }
        else if (spawnTimer >= spawnTime) // If it's time to spawn a new object
        {
            SpawnRandomObject(); // Spawn a new random object
        }
    }

    void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length); // Get a random index for the array
        GameObject newObject = Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity); // Spawn the object at the generator's position

        if (currentObject != null) // If there's a current object
        {
            Destroy(currentObject); // Destroy it
        }

        currentObject = newObject; // Set the new object as the current object
        objectTimer = 0f; // Reset the object timer
        spawnTimer = 0f; // Reset the spawn timer
    }
   
}


