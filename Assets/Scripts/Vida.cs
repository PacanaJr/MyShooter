using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    private int vida;
    public TMP_Text textoVidaValor;
    public TimerEnemigo timerEnemigo;
    public Jugador jugador;
    public GameObject puntoInicial;
    public GeneracionEnemigos generadorEnemigos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = 2;
        textoVidaValor.text = vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitarVida()
    {
        vida--;
        textoVidaValor.text = vida.ToString();

        if (vida <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
        jugador.characterController.enabled = false;
        jugador.transform.position = puntoInicial.transform.position;
        jugador.characterController.enabled = true;

        DestruirTodosLosEnemigos();
        timerEnemigo.ReiniciarTimer();
    }

    void DestruirTodosLosEnemigos()
    {
        if (generadorEnemigos != null)
        {
            generadorEnemigos.DestruirTodosLosEnemigos();
        }
    }

    public void AñadirVida()
    {
        vida++;
        textoVidaValor.text = vida.ToString();
    }
}
