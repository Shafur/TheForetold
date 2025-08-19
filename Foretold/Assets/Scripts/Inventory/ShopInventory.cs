using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    public static ShopInventory Instance { get; private set; }

    public List<Item> playerItems = new List<Item>();
    public int playerGold = 100;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool CantAfford(int amount) => playerGold >= amount;

    public void AddItem(Item item)
    {
        playerItems.Add(item);
        Debug.Log($"Added {item.itemName} to inventory.");
    }

    public void RemoveItem(Item item)
    {
        playerItems.Remove(item);
        Debug.Log($"Removed {item.itemName} from inventory");
    }

    public void SpendGold(int amount)
    {
        playerGold -= amount;
    }

    public void EarnGold(int amount)
    {
        playerGold += amount;
    }
}
