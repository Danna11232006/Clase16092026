using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    public PotionsSO potionsSO;
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Inventory.Instance.potion = potionsSO;
            Inventory.Instance.hasPotion = true;
            HUDManager.Instance.PotionName(potionsSO);
        }
    }
    
}
