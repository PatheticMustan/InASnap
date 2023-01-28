using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combo System/Combo List")]
public class ComboList : ScriptableObject
{
    public string listName;
    public Combo[] list;
}
