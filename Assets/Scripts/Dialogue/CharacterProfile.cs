using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character Profile")]
public class CharacterProfile : ScriptableObject
{
    public string characterName;
    public Color32 color;
    public CharacterEmotion[] characterEmotionSprites;

    public AudioClip textBlip;

    public Sprite GetEmotion(Emotion emote) {

        CharacterEmotion characterEmote = null;
        for (int i = 0; i < characterEmotionSprites.Length; i++) {
            characterEmote = characterEmotionSprites[i];

            if (characterEmote.emote == emote) {
                return characterEmote.image;
            }
        }

        #if UNITY_EDITOR
        Debug.LogError(characterEmote + " doesn't have an Image for " + emote);
        #endif
        return null;
    }
}

[System.Serializable]
public class CharacterEmotion {
    public Emotion emote;
    public Sprite image;
}

public enum Emotion {
    Neutral,
    Happy,
    Esctatic,
    Sad,
    Depressed,
    Angry,
    Enraged,
    Worried,
    Loaf,
    WOE
}