using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodItem : Item
{
    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>("Icon/Wood Icon");
    }

    public int GetMaxStack()
    {
        return 20;
    }

    public string GetName()
    {
        return "Wood";
    }

}
