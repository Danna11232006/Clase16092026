using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [HideInInspector] public PotionsSO potion;
    [HideInInspector] public bool hasPotion;
    void Awake()
    {
        if (Instance == null)
        {
        Instance = this;
        }  else
        {
         Destroy(this);
        }
        potion = null;
        hasPotion = false;
            
    }
  
    
  
}
