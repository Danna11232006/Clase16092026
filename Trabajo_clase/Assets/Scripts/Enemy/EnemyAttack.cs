using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [HideInInspector] public bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
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
