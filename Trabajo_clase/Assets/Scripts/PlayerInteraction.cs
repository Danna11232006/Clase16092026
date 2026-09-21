using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();

    }

   public void DrinkPotion()
   {
    if(Inventory.Instance.hasPotion == false)
    {
        return;
    }
    
    switch(Inventory.Instance.potion.potionType) {
        //Siempre despues del case necesito indicarle al metodo que termine
        case PotionType.Cura: 
            playerStats.health += Inventory.Instance.potion.factor;
            playerStats.health = Mathf.Min(playerStats.health, playerStats.maxLife);
            break;

        case PotionType.Poder:
            playerStats.power += Inventory.Instance.potion.factor;
            break;

        case PotionType.Resistencia:
            playerStats.stamina += Inventory.Instance.potion.factor;
            break;
    }   

   }
}
