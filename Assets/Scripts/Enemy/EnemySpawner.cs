using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

     Camera playerCamera;

     BoxCollider2D boxCollider;

    float boxMinX, boxMinY, boxMaxX, boxMaxY, cameraMinX, cameraMinY, cameraMaxX, cameraMaxY;

   [SerializeField] GameObject[] enemies;

     float spawnPadding = 2f;

     float currentSpawnRateTimer;

    float spawnRateTimer = 5;

     int maxAmountOfEnemies = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GetBoxColliderCoordinates();
        currentSpawnRateTimer = spawnRateTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawnRateTimer > 0)
        {
            currentSpawnRateTimer -= Time.deltaTime;
        }
        else if (currentSpawnRateTimer <= 0)
        {
            StartCoroutine(SpawnEnemy());
            currentSpawnRateTimer = spawnRateTimer;
        }
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2();
        int enemiesSpawned= 0;

        while (enemiesSpawned != maxAmountOfEnemies)

        {
            int spawnPlace = Random.Range(1, 5);
            GetCameraLocation();

            switch (spawnPlace)

            {
                case 1:
                    spawnPosition = Leftside();
                    break;
                case 2:
                    spawnPosition = Rightside();
                    break;
                case 3:
                    spawnPosition = TopSide();
                    break;
                case 4:
                    spawnPosition = BottomSide();
                    break;




            }

            if (IsInPlayerArea(spawnPosition))
            {
                int whatEnemy = Random.Range(0,enemies.Length);
                Instantiate(enemies[whatEnemy], spawnPosition, Quaternion.identity);
                enemiesSpawned++;
            }

            Debug.Log(enemiesSpawned);
            yield return null;
        }
    }







    void GetBoxColliderCoordinates()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider != null)
        {
            boxMinX = boxCollider.bounds.min.x;
            boxMinY = boxCollider.bounds.min.y;
            boxMaxX = boxCollider.bounds.max.x;
            boxMaxY = boxCollider.bounds.max.y;
        }
    }

    void GetCameraLocation()
    {
        playerCamera = Camera.main;
        cameraMinY = playerCamera.transform.position.y - playerCamera.orthographicSize;
        cameraMaxY = playerCamera.transform.position.y + playerCamera.orthographicSize;

        float halfSize = playerCamera.orthographicSize * playerCamera.aspect;

        cameraMinX = playerCamera.transform.position.x - halfSize;
        cameraMaxX = playerCamera.transform.position.x + halfSize;
    }

    bool IsInPlayerArea(Vector2 point)
    {
        return point.x >= boxMinX && point.x <= boxMaxX && point.y >= boxMinY && point.y <= boxMaxY;
    }

    Vector2 Leftside()
    {
        float leftX = cameraMinX - spawnPadding;
        float randomY = Random.Range(cameraMinY, cameraMaxY);
        return new Vector2(leftX, randomY);
    }

    Vector2 Rightside()
    {
        float rightX = cameraMaxX + spawnPadding;
        float randomY = Random.Range(cameraMinY, cameraMaxY);
        return new Vector2(rightX, randomY);
    }

    Vector2 TopSide()
    {
        float topY = cameraMaxY + spawnPadding;
        float randomX = Random.Range(cameraMinX, cameraMaxX);
        return new Vector2(randomX, topY);
    }
    Vector2 BottomSide()
    {
        float bottomY = cameraMinY - spawnPadding;
        float randomX = Random.Range(cameraMinX, cameraMaxX);
        return new Vector2(randomX, bottomY);
    }

}
