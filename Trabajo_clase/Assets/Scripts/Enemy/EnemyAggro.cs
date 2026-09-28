using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [HideInInspector] public bool isAggro;

    public float distanceToAggro;

    private Transform playerTransform;

    private EnemyAttack enemtAttack;

    // Start is called before the first frame update
    void Start()
    {
        if(playerTransform == null )
        playerTransform = FindAnyObjectByType<PlayerMovement>().transform;    

        enemtAttack  = GetComponent<EnemyAttack>();
        isAggro = false;

    }

    void Update ()
    {
        CheckEnemyAggro();
    }



    public void CheckEnemyAggro()
    {
        var dis = Vector3.Distance(transform.position,playerTransform.position);

        if (dis < distanceToAggro)
        {
            isAggro = true;
        }
        else 
        {
            isAggro = false;
        }
    }

    public void EnemyDamage()
    {
        Debug.Log ("Salud del jugador es " + playerTransform.GetComponent<PlayerStats>().health);

    }
}
