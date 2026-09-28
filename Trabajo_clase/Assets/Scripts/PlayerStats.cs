using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxLife;
    public int minStamina;
    public int minPower;

    [HideInInspector] public int health;
    [HideInInspector] public int stamina;
    [HideInInspector] public int power;


    // Start is called before the first frame update
    void Start()
    {
        health = maxLife;
        stamina = minStamina;
        power = minPower;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            health--;
            health = Mathf.Max(health, 0);
            Debug.Log("Health is: " + health);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Power is: " + power);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Resistance is: " + stamina);
        }
    }
    
    public void PlayerDamage()
    {
        if (health > 1)
        {
            health --;
            Debug.Log(health);
        }
        else if (health == 1)
        {
            Debug.Log("Player died");
        }
    }
}
