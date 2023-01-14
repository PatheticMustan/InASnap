using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character Profile")]
public class CharacterProfile : ScriptableObject
{
    public string characterName;
    public CharacterEmotion[] characterEmotionSprites;

    public AudioClip textBlip;
}

public class CharacterEmotion {
    public Emotion emote;
    public Sprite image;
}

public enum Emotion {
    Neutral,
    Happy,
    Sad,
    Angry,
    Worried,
    Loaf,
    WOE
}