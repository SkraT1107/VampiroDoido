using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth health = collision.GetComponent<EnemyHealth>();

        if(health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
