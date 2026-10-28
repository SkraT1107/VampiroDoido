using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public float spawnDistance = 15f;
    private Transform player;

    private void Start()
    {
        player = PlayerControler.Instance.transform;
    }

    public Vector3 GetSpawnPosition()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;
        return  player.position + (Vector3)(direction * spawnDistance);
    }
}
