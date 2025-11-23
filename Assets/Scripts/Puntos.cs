using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{
    private int puntos;
    public TMP_Text textoPuntosValor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntos = 0;
        textoPuntosValor.text = puntos.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SumaPunto()
    {
        puntos++;
        textoPuntosValor.text = puntos.ToString();
    }
}
