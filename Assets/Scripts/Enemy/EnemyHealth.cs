using System.Collections;
using UnityEngine;

/// <summary> 
/// Responsável por tirar vida e destruir o inimigo
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    [Header("Renderer")]
    public SpriteRenderer spriteRenderer;
    public Material hitMaterial;
    public float flashTime;

    private Material currentMaterial;
    Coroutine flashCoroutine;

    [Header("Hit Animation")]
    public GameObject hitAnimation;

    [Header("Status")]
    public int maxLife;
    int currentLife;

    private void Awake()
    {
        currentLife = maxLife;
        currentMaterial = spriteRenderer.material;
    }

    public void TakeDamage(int damage)
    {
        currentLife -= damage;
        
        GameObject hit = Instantiate(hitAnimation, transform.position, Quaternion.identity);
        hit.transform.SetParent(transform);
        hit.GetComponent<HitCanvaPrefhab>().changeValue(damage);
        Destroy(hit, 0.6f);

        if(flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        StartCoroutine(FlashCoroutine());
        
        if(currentLife <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashCoroutine()
    {
        spriteRenderer.material = hitMaterial;
        yield return new WaitForSeconds(flashTime);
        spriteRenderer.material = currentMaterial;
        flashCoroutine = null;
    }


    public void Die()
    {
        Instantiate(GameManeger.instance.XpOrb, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
