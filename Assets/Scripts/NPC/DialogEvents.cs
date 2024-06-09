using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvents : Singleton<DialogEvents>
{
    [SerializeField] private Item[] content;

    public ItemID requiredKey1;
    public ItemID requiredKey2;
    public ItemID requiredKey3;

    private static bool NeedHeartKey = false;
    private static bool NeedMysteryKey = false;
    private static bool EndDialog = false;
    private static bool FirstSpeak = true;

    public static bool GetFirstSpeak()
    {
        return FirstSpeak;
    }

    public void NoFirstSpeakNow()
    {
        FirstSpeak = false;
    }

    public static bool GetEndDialog()
    {
        return EndDialog;
    }

    public void EndDialogNow()
    {
        EndDialog = true;
    }

    public void NoEndDialogNow()
    {
        EndDialog = false;
    }

    public static bool GetNeedHeartKey()
    {
        return NeedHeartKey;
    }

    public void NeedHeartKeyNow()
    {
        NeedHeartKey = true;
    }

    public void NoNeedHeartKeyNow()
    {
        NeedHeartKey = false;
    }

    public static bool GetNeedMysteryKey()
    {
        return NeedMysteryKey;
    }

    public void NeedMysteryKeyNow()
    {
        NeedMysteryKey = true;
    }

    public void NoNeedMysteryKeyNow()
    {
        NeedMysteryKey = false;
    }

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

    public void AddCleDuMystere()
    {
        foreach(var item in content)
        {
            if (item.Id == ItemID.Cle_Du_Mystere)
            {
                PlayerItems.AddItem(item);
            }
        }
    }

    public void AddCleDuCoeur()
    {
        foreach(var item in content)
        {
            if (item.Id == ItemID.Cle_Du_Coeur)
            {
                PlayerItems.AddItem(item);
            }
        }
    }
}
