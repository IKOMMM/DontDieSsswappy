using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] deadBoxPrefabs;
    [SerializeField] private float secondsBerweenDeadboxes = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private Camera mainCamera;

    private float timer;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnDeadBox();

            timer += secondsBerweenDeadboxes;
        }
    }

    private void SpawnDeadBox()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0: //Left Side
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1: //Right Side
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2: //Down Side
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3: //Top Side
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedDeadBox = deadBoxPrefabs[Random.Range(0, deadBoxPrefabs.Length)];

        GameObject deadBoxInstance = Instantiate(
            selectedDeadBox, 
            worldSpawnPoint, 
            Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        Rigidbody rb = deadBoxInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}
