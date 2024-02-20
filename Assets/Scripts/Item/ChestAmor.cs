using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAmor : Item
{
    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>("Icon/chest leather armor");
    }

    public int GetMaxStack()
    {
        return 1;
    }

    public string GetName()
    {
        return "Chest Armor";
    }
}
