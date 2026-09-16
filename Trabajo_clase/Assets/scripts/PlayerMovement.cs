using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Se crean las variables que modifican el comportamiento del salto y del movimiento.
    [SerializeField] private float speed;
    public float rotationSpeed = 720f;
    [SerializeField] private float gravity = -9.81f;

    // Va a almacenar la velocidad en el eje y
    private float verticalVelocity;

    // Guarda en un vector la direccion inicial que es cero
    private Vector3 moveDirection = Vector3.zero;


    // Variable que va a almacenar el Character Controller.*/
    [HideInInspector] public CharacterController characterController;

    private void Awake()
    {
        // Se almacena el componente de Character Controller en la variable acorde.
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Se llama el metodo del movimiento
        Movement();
    }

    private void Movement()
    {
        // Se aplica el movimiento al objeto.
        verticalVelocity += gravity * Time.deltaTime;

        // En una variable se guarda el input del movimiento
        Vector3 inputDir = new Vector3(InputController.Instance.moveVector.x, verticalVelocity, InputController.Instance.moveVector.y);

        // En una variable se guarda el input de la rotación
        Vector3 rotDir = new Vector3(InputController.Instance.moveVector.x, 0, InputController.Instance.moveVector.y);

        // Se guarda en l variable el movimiento final por la velocidad
        moveDirection = inputDir * speed;

        //Se mueve el personaje
        characterController.Move(moveDirection * Time.deltaTime);

        // Se valida que exista una direccion a la cual rotar
        if (rotDir != Vector3.zero)
        {
            // Se almacena en una variable la rotacion
            Quaternion targetRotation = Quaternion.LookRotation(rotDir);

            // Se rota al personaje desde una rotacion inicial, hacia una rotacion final en un tiempo dado
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}

