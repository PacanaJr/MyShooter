using UnityEngine;
using TMPro;
public class TimerEnemigo : MonoBehaviour
{
    public float timerEnemigo = 0;
    public TMP_Text textoTimerValor;
    void Start()
    {
        timerEnemigo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerEnemigo += Time.deltaTime;
        textoTimerValor.text = timerEnemigo.ToString("f2");
    }

    public float getTimerEnemigo()
    {
        return timerEnemigo;
    }

    public float ReiniciarTimer()
    {
        timerEnemigo = 0;
        return timerEnemigo;
    }
}
