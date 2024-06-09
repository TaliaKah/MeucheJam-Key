using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvents : MonoBehaviour
{
    [SerializeField] private Item[] content;

    public void AddPetiteCle()
    {
        foreach(var item in content)
        {
            if (item.Id == ItemID.Petite_Cle)
            {
                PlayerItems.AddItem(item);
            }
        }
    }
}
