using TMPro;
using UnityEngine;

public class HitCanvaPrefhab : MonoBehaviour
{
    public TextMeshProUGUI hitText;

    public void changeValue(int damage) 
    {
        hitText.text = damage.ToString();
    }
}
