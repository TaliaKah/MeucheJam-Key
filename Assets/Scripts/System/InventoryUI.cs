using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // Panel to hold the item icons
    public GameObject itemIconPrefab; // Prefab for the item icon

    private Dictionary<ItemID, GameObject> itemIcons = new Dictionary<ItemID, GameObject>();

    public void AddItemToUI(Item item)
    {
        if (!itemIcons.ContainsKey(item.Id))
        {
            GameObject icon = Instantiate(itemIconPrefab, inventoryPanel.transform);
            // Assuming the item prefab has an Image component as a child
            Image iconImage = icon.GetComponentInChildren<Image>();
            iconImage.sprite = item.Icon; // Set the icon sprite
            itemIcons[item.Id] = icon;
        }
    }

    public void RemoveItemFromUI(ItemID itemId)
    {
        if (itemIcons.ContainsKey(itemId))
        {
            Destroy(itemIcons[itemId]);
            itemIcons.Remove(itemId);
        }
    }
}
