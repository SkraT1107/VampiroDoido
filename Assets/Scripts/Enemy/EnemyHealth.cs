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


    public GameObject dieEffect;
    public Rigidbody2D rigidbody;
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
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentLife -= damage;

        ApplyKnockback(PlayerControler.Instance.transform.position, 4, 0.1f);
        
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
        GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
        Instantiate(GameManeger.instance.XpOrb, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 2f);
    }


    #region Knockback

    public bool isKnockback;
    Coroutine knockCoroutine;
    public void ApplyKnockback(Vector2 knockback, float force, float duration)
    {
        Vector2 direction = ((Vector2) transform.position - knockback).normalized;

        if(knockCoroutine != null)
        {
            StopCoroutine(knockCoroutine);
        }

        knockCoroutine = StartCoroutine(KnockbackRoutine(direction, force, duration));
    }

    IEnumerator KnockbackRoutine(Vector2 knockback, float force, float duration)
    {
        isKnockback = true;
        rigidbody.linearVelocity = knockback * force;
        yield return new WaitForSeconds(duration);
        rigidbody.linearVelocity = Vector2.zero;
        isKnockback = false;

        knockCoroutine = null;

    }
    #endregion
}
