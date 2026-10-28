using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    public int level = 1;
    public int xp;
    public int xpToNextLevel = 10;
    public Image xpBar;

    [Header("Textos")]
    public TextMeshProUGUI tempo;
    public TextMeshProUGUI textoLevel;

    public void AddXP(int xpGanho)
    {

        xp += xpGanho;

        while (xp >= xpToNextLevel)
        {
            xp -= xpToNextLevel;
            level++;
            xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.25f);
        }

        updateXPBar();
        
    }

    void updateXPBar()
    {
        xpBar.fillAmount = (float) xp / xpToNextLevel;
        textoLevel.text = "Lvl " + level.ToString();
    }

    private void Update()
    {
        tempo.text = GameManeger.instance.GetTempoDecorrido();
    }
}
