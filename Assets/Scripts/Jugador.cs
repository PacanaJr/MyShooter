using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{

    [Header("Movimiento")]
    private Vector2 inputMovimiento;
    public CharacterController characterController;
    public float velocidad = 5;
    private Vector3 movimientoActual;

    [Header("Vista")]
    private Vector2 inputVista;
    public Camera camera;
    private float rangoVisionArribaAbajo = 50f;
    private float rotacionVertical;
  

    [Header("Disparo")]
    public Transform puntoDisparo;
    public GameObject bala;
    public float fuerzaDisparo = 1500f;
    public float tasaDisparo = 0.5f;
    private float tiempoEntreDisparos = 0;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        GestionaMovimiento();
        GestionaRotacion();
    }

    private void OnMove(InputValue inputValue)
    {
        inputMovimiento = inputValue.Get<Vector2>();
    }

    private void OnLook(InputValue inputValue)
    {
        inputVista = inputValue.Get<Vector2>();
    }

    private void OnAttack(InputValue inputValue)
    {
        if (Time.time >= tiempoEntreDisparos)
        {
            GameObject nuevaBala;
            nuevaBala = Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
            nuevaBala.transform.Rotate(90, 0, 0);
            nuevaBala.GetComponent<Rigidbody>().AddForce(puntoDisparo.forward * fuerzaDisparo);

            tiempoEntreDisparos = Time.time + tasaDisparo;
            Destroy(nuevaBala, 2);
        }
    }

    private void GestionaMovimiento()
    {
        Vector3 direccionMundo = CalculaDireccionMundo();
        movimientoActual.x = direccionMundo.x;
        movimientoActual.z = direccionMundo.z;

        characterController.Move(movimientoActual * velocidad * Time.deltaTime);
    }

    private void GestionaRotacion()
    {
        float rotacionRatonX = inputVista.x;
        float rotacionRatonY = inputVista.y;

        AplicarRotacionHorizontal(rotacionRatonX);
        AplicarRotacionVertical(rotacionRatonY);
    }

    private void AplicarRotacionVertical(float rotacionRatonY)
    {
        rotacionVertical = Mathf.Clamp(rotacionVertical - rotacionRatonY, -rangoVisionArribaAbajo, rangoVisionArribaAbajo);
        camera.transform.localRotation = Quaternion.Euler(rotacionVertical, 0, 0);
    }

    private void AplicarRotacionHorizontal(float rotacionRatonX)
    {
        transform.Rotate(0, rotacionRatonX, 0);
    }

    private Vector3 CalculaDireccionMundo()
    {
        Vector3 inputDireccion = new Vector3(inputMovimiento.x, 0, inputMovimiento.y);
        Vector3 direccionMundo = transform.TransformDirection(inputDireccion);
        return direccionMundo.normalized;
    }

}
