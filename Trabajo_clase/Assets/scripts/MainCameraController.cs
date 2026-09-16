using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    // Guarda la posición del objetivo
    public Transform target;

    // Variables para guardara la velocidad del seguimiento y el desface de la camara
    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        // Se llama el metodo
        FollowTarget();
    }

    public void FollowTarget()
    {
        // Si hay un objetivo, se mueve la posición de la cámara al offset 
        if (target != null)
        {
            var targetPos = target.position + offset;
            transform.position = targetPos;
        }
    }
}
