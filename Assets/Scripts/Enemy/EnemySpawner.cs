using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnData spawnData;

    SpawnZone spawnZone;
    private float timer;
    float currentCooldown;

    private void Start()
    {
        spawnZone = GetComponent<SpawnZone>();
        currentCooldown = spawnData.initialCooldown;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= currentCooldown)
        {
            SpawnEnemys();
            timer = 0f;

            // dificuldade com o tempo
            currentCooldown = Mathf.Max(spawnData.minCooldown, currentCooldown - spawnData.cooldownDecreaseRate);
        }
    }

    void SpawnEnemys()
    {
        int count = Mathf.Min(spawnData.EnemysPerSpawm, spawnData.maxEnemysPerSpawn); 

        for(int i = 0; i < count; i++)
        {
            Vector3 pos = spawnZone.GetSpawnPosition();
            Instantiate(spawnData.enemyPrefab, pos, Quaternion.identity);
        }
    }

}
