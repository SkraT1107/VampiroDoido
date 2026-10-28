using UnityEngine;

public class WeaponControler : MonoBehaviour
{
    public Weapons weapon;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime; //soma segundos em tempo real
       
        if(timer >= weapon.cooldown)
        {
            Attack();
            timer = 0;
        }
    }

    void Attack() {
        GameObject wp = Instantiate(weapon.atackPrefab, transform.position, Quaternion.identity);
        wp.GetComponent<AttackArea>().damageDealer.SetDamage(weapon.dano);
    }
}
