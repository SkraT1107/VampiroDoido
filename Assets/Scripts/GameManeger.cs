using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public GameObject XpOrb;

    [Header("Timer")]
    public float matchDuration = 1800f; //Em segundos
    private float tempoDecorrido;
    private bool finished;

    public static GameManeger instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (finished)
        {
            return;
        }
        tempoDecorrido += Time.deltaTime;

        if(tempoDecorrido >= matchDuration)
        {
            finished = true;
            Win();
        }
    }

    void Win()
    {

    }

    public void Restart()
    {
        tempoDecorrido = 0f;
        finished = false;
    }

    public string GetTempoDecorrido()
    {
        int minutos = (int)tempoDecorrido / 60;
        int segundos = (int)tempoDecorrido % 60;
        return minutos + ":" + segundos;
    }
}
