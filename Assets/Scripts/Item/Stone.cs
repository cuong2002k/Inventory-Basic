using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Item
{
    public Sprite GetIcon()
    {
        return Resources.Load<Sprite>("Icon/Stone Icon");
    }

    public int GetMaxStack()
    {
        return 10;
    }

    public string GetName()
    {
        return "Stone";
    }
}
