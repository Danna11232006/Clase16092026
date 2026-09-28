
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    // Almacena los puntos de movimiento de los enemigos.
    public Transform[] points;

    // Define el primer destino como el primer elemento de la lista.
    private int destPoint = 0;

    // Variable para almacenar el componente del Script de Enemy Aggro
    private EnemyAggro enemyAggro;

    // Para almacenar el transform del jugador.
    private Transform playerTransform;

    // Se almacena la variable para el componente del Nav Mesh.
    private NavMeshAgent navMeshAgent;

    public float starSpeed;
    public float followSpeed;

    private void Start()
    {
        // Se llenan las variables con los componentes
        enemyAggro = GetComponent<EnemyAggro>();

        // Se asegura que se guarda una referencia al jugador
        if(playerTransform == null )
        playerTransform = FindAnyObjectByType<PlayerMovement>().transform; 
        
        // Se guarda el componente del Navmesh en la variable
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Se cambia el punto de destino para que el enemigo se mueva
        NextPoint();
    }

    private void NextPoint()
    {
        // Devuelve si no hay puntos de posici�n en el arreglo.
        if (points == null || points.Length == 0)
            return;

        // Se le da destino al enemigo, el cual es el primer punto de la lista (por ser destpoint = 0).
        navMeshAgent.destination = points[destPoint].position;

        // Se elige el siguiente punto en la lista. Todo numero menor que el divisor esel mismo m�dulo.
        //1=2%3=2 si el numero es menor el residuo es el menor 
        //3%3=0
        destPoint = (destPoint + 1) % points.Length;
    }

    private void Update()
    {
        // Se llama al metodo de movimiento constantemente
       EnemyMovement();
    }

    private void EnemyMovement()
    {
        // Se valida si la variable de EnemyAggro es verdadera, para que el enemigo se mueva a la posici�n del jugador
        // Si es falsa el enemigo mantiene su posici�n
        if (enemyAggro.isAggro)
        {
            navMeshAgent.SetDestination(playerTransform.position);
            navMeshAgent.speed = followSpeed;
            navMeshAgent.stoppingDistance = 3;
        }
        else
        {
            navMeshAgent.stoppingDistance = 0;
            navMeshAgent.speed = starSpeed;

            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                NextPoint();
            }
               
        }
    }

}
