using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Dialogue")]
public class Dialogue : ScriptableObject
{
    public CharacterProfile[] characters;

    public DialogueNode[] dialogue;
}

[System.Serializable]
public class DialogueNode {

    [Header("Character")]
    public int characterID;
    public Emotion emote;

    [Space(10), Header("Text Info")]
    [TextArea] public string text;
    public float tickSpeed;

    [Space(10)]
    public bool hasMaxTime;
    public float maxTime;
}