using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControler : MonoBehaviour
{
    [Serializable]
    public class WeaponSlot
    {
        public Weapons weapon;
        [HideInInspector] public float timer;

        [Header("Upgrades")]
        public float cooldownMult = 1f;
        public float damageMult = 1f;

    }

    public List<WeaponSlot> weapons = new List<WeaponSlot>();

    //public Weapons weapon;
    //private float timer;

    private void Update()
    {
        //timer += Time.deltaTime; //soma segundos em tempo real
       
        //if(timer >= weapon.cooldown)
        //{
        //    Attack();
        //    timer = 0;
        //}

        for(int i = 0; i < weapons.Count; i++)
        {
            WeaponSlot w = weapons[i];
            if (w.weapon == null) continue;

            w.timer += Time.deltaTime;

            float finalCooldown = w.weapon.cooldown * w.cooldownMult;

            if(w.timer >= finalCooldown)
            {
                Attack(w);
                w.timer = 0;
            }
        }
    }

    void Attack(WeaponSlot weaponSlot) {
        GameObject wp = Instantiate(weaponSlot.weapon.atackPrefab, transform.position, Quaternion.identity);
        int finalDamage = (int)(weaponSlot.weapon.dano * weaponSlot.damageMult);
        wp.GetComponent<AttackArea>().damageDealer.SetDamage(finalDamage);
    }

    public bool HasWeapon(Weapons weapon)
    {
        return GetSlot(weapon) != null; 
    }
    public void UpgradeWeaponDamage(Weapons weapon, float percent)
    {
        WeaponSlot slot = GetSlot(weapon);

        if (slot == null) return;

        slot.cooldownMult *= (1f + percent);
        
    }

    public void UpgradeWeaponCooldown(Weapons weapon, float percent)
    {
        WeaponSlot slot = GetSlot(weapon);

        if (slot == null) return;

        slot.cooldownMult *= (1f - percent);
        slot.cooldownMult = Mathf.Max(0.1f, slot.cooldownMult);
    }

    WeaponSlot GetSlot(Weapons weapon)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapon == weapons[i].weapon)
            {
                return weapons[i];
            }
        }
        return null;
    }
}
