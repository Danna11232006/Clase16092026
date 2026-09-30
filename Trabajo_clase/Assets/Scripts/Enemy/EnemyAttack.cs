using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [HideInInspector] public bool isAttacking;

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

    public void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        transform .rotation = Quaternion.LookRotation(other.transform.position, Vector3.up);
        isAttacking = true;
        Debug.Log ("Esta atacando");
    }

    public void OnTriggerExit (Collider other)
    {
        {
            if (other.CompareTag("Player"))
            isAttacking = false;
            Debug.Log ("No esta atacando");
        }
    }
}
