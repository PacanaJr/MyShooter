using UnityEngine;

public class Bala : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            FindAnyObjectByType<Puntos>().SumaPunto();
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }

}