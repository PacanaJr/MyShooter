using System.Collections.Generic;
using UnityEngine;

public class GeneracionVida : MonoBehaviour
{
    public Transform[] puntosCajaVida;
    public GameObject cajaVidaPrefab;
    public Transform parentObjectCajaVida;

    private GameObject cajaActual;

    private List<int> puntosDisponibles = new List<int>();
    private int ultimoPunto = -1;

    void Start()
    {
        for (int i = 0; i < puntosCajaVida.Length; i++)
        {
            puntosDisponibles.Add(i);
        }

        SpawnCaja();
    }

    public void SpawnCaja()
    {
        if (cajaActual != null) return;

        List<int> puntosValidos = new List<int>(puntosDisponibles);
        if (ultimoPunto != -1)
            puntosValidos.Remove(ultimoPunto);

        int puntoRandom = puntosValidos[Random.Range(0, puntosValidos.Count)];
        ultimoPunto = puntoRandom;

        cajaActual = Instantiate(
            cajaVidaPrefab,
            puntosCajaVida[puntoRandom].position,
            puntosCajaVida[puntoRandom].rotation,
            parentObjectCajaVida
        );
    }

    public void CajaRecogida()
    {
        cajaActual = null;
        SpawnCaja();
    }
}
