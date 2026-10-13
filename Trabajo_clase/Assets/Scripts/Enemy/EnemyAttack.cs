using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [HideInInspector] public bool isAttacking;

    [SerializeField] float rotationSpeed = 10f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isAttacking = false;
    }

    void Update()
    {
        animator.SetBool("Attack", isAttacking);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = true;
            Debug.Log("Esta atacando");
            Debug.Log("Sophia entró al área del enemigo");
        }
    }

    // Se ejecuta en cada frame mientras el jugador sigue dentro del área
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Dirección desde el enemigo hacia el jugador
            Vector3 direction = other.transform.position - transform.position;
            direction.y = 0f; // evita que el enemigo se incline hacia arriba o abajo

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = false;
            Debug.Log("No esta atacando");
            Debug.Log("Sophia salió del área del enemigo");
        }
    }
}
