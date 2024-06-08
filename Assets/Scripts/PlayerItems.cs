using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemID
{
    Cle_Allen,
    Cle_A_Molette,
    Triangle,
    Cle_De_Fa,
    Medicament,
    Sous_Cle,
    Cle_De_Sol,
    Cle_USB,
    Rond,
    Cle_Du_Mystere,
    Cle_Du_Coeur,
    Easter_Egg_Patate
}

[System.Serializable] public class Item
{
    [SerializeField] private string itemName;
    [SerializeField] private ItemID id;

    public string Name => itemName;
    public ItemID Id => id;

    // Constructeur
    public Item(string name, ItemID id)
    {
        this.itemName = name;
        this.id = id;
    }
}

public class PlayerItems : MonoBehaviour
{
    private static Dictionary<ItemID, Item> items = new Dictionary<ItemID, Item>();

    // Ajouter un item
    public static bool AddItem(Item item)
    {
        if (items.ContainsKey(item.Id))
        {
            return false; // L'item existe déjà
        }

        items[item.Id] = item;
        return true;
    }

    // Retirer un item
    public static bool RemoveItem(ItemID itemId)
    {
        return items.Remove(itemId);
    }

    // Récupérer un item
    public static Item GetItem(ItemID itemId)
    {
        items.TryGetValue(itemId, out Item item);
        return item;
    }

    // Lister tous les items
    public static IEnumerable<Item> GetAllItems()
    {
        return items.Values;
    }
}
