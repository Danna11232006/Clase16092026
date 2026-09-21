using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    //singleton
    public static HUDManager Instance;

    public TextMeshProUGUI potionNameText;
    public string emptyInventoryText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        potionNameText.text = emptyInventoryText;
    }

    public void PotionName(PotionsSO potion)
    {
        potionNameText.text = potion.potionName;
    }

    public void ResetPotionName()
    {
        potionNameText.text = emptyInventoryText;
    }
}
