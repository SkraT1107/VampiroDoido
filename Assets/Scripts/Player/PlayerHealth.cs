using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    float lifePercent;

    [Header("UI")]
    public Image healthBar;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void takeDamage(float damage)
    {
        currentHP -= damage;
        
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        lifePercent = currentHP / maxHP;
        healthBar.fillAmount = lifePercent;

        if (currentHP <= 0) Die();

    }
    
    public void Heal(float healAmont)
    {
        currentHP += healAmont;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }

    void Die()
    {

    }
}
