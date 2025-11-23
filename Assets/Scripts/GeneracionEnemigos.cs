using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GeneracionEnemigos : MonoBehaviour
{
    [Header("Puntos de inicio de los enemigos")]
    public Transform parentObjectEnemigos;
    public Transform[] puntosInicio;

    [Header("Prefabs de enemigos")]
    public GameObject enemigo1;
    public GameObject enemigo2;

    [Header("Ajustes de dificultad")]
    public TimerEnemigo timerEnemigo;
    public float refrescoEnemigos = 1.0f;
    public float velocidadEnemigo = 3.5f;
    public float dificultadEnemigo = 0;

    void Start()
    {
        if (timerEnemigo == null)
        {
            timerEnemigo = FindAnyObjectByType<TimerEnemigo>();
        }

        StartCoroutine("DificultadCreacionEnemigo");
    }

    void Update()
    {
        if (timerEnemigo == null) return;

        dificultadEnemigo = timerEnemigo.getTimerEnemigo();

        if (dificultadEnemigo > 0 && dificultadEnemigo < 30)
        {
            refrescoEnemigos = 2.0f;
            velocidadEnemigo = 3.5f;
        }
        else if (dificultadEnemigo >= 30 && dificultadEnemigo < 60)
        {
            refrescoEnemigos = 1.0f;
            velocidadEnemigo = 4.0f;
        }
        else if (dificultadEnemigo >= 60)
        {
            refrescoEnemigos = 0.5f;
            velocidadEnemigo = 4.5f;
        }
    }

    IEnumerator DificultadCreacionEnemigo()
    {
        while (true)
        {
            yield return new WaitForSeconds(refrescoEnemigos);
            CreaEnemigo();
        }
    }

    void CreaEnemigo()
    {
        if (puntosInicio == null || puntosInicio.Length == 0) return;

        int aleatorioPuntosInicio = Random.Range(0, puntosInicio.Length);

        GameObject prefabEnemigo = null;

        // Elegimos uno de los dos prefabs
        if (enemigo1 != null && enemigo2 != null)
        {
            prefabEnemigo = Random.value < 0.5f ? enemigo1 : enemigo2;
        }
        else if (enemigo1 != null)
        {
            prefabEnemigo = enemigo1;
        }
        else if (enemigo2 != null)
        {
            prefabEnemigo = enemigo2;
        }

        if (prefabEnemigo == null) return;

        GameObject nuevoEnemigo = Instantiate(
            prefabEnemigo,
            puntosInicio[aleatorioPuntosInicio].position,
            puntosInicio[aleatorioPuntosInicio].rotation,
            parentObjectEnemigos
        );

        NavMeshAgent agent = nuevoEnemigo.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = velocidadEnemigo;
        }
    }

    public void DestruirTodosLosEnemigos()
    {
        if (parentObjectEnemigos != null)
        {
            foreach (Transform enemigo in parentObjectEnemigos)
            {
                Destroy(enemigo.gameObject);
            }
        }
    }
}
