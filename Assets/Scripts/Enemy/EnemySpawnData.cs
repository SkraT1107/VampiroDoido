using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Enemy/new EnemySpawnData")]
public class EnemySpawnData : ScriptableObject
{
    public GameObject enemyPrefab;

    public float initialCooldown;

    public float minCooldown;
    public float cooldownDecreaseRate;
    public int EnemysPerSpawm;
    public int maxEnemysPerSpawn;

}
