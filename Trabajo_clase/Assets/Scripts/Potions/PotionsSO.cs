using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PotionType { Cura, Poder, Resistencia}

[CreateAssetMenu(fileName = "New potion", menuName = "Potion / New Potion")]
public class PotionsSO : ScriptableObject

{
   public PotionType  potionType;
   public string potionName;
   public int factor;
}
