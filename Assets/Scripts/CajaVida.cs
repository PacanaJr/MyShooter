using UnityEngine;

public class CajaVida : MonoBehaviour
{
    private GeneracionVida generador;
    private Vida vidaManager;

    void Start()
    {
        generador = FindAnyObjectByType<GeneracionVida>();
        vidaManager = FindAnyObjectByType<Vida>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Jugador")) return;

        vidaManager.AñadirVida();
        generador.CajaRecogida();
        Destroy(gameObject);
    }
}
