using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Weapons/new Weapon")]
public class Weapons : ScriptableObject
{
    public GameObject atackPrefab;
    public float cooldown;
    public int dano;

    
}
