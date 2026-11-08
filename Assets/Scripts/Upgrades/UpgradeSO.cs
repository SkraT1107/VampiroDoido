using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Upgrades/new Upgrade")]
public class UpgradeSO : ScriptableObject
{
    public enum UpgradeType
    {
        WeaponDamage,
        WeaponCooldown,
        XPGain,
        MaxHP,
        Heal
    }

    public Sprite icon;
    public string title;
    [TextArea] public string description;
    public UpgradeType type;

    public float value;
    public Weapons targetWeapon;
}
