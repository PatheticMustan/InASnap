using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueReader : MonoBehaviour
{
    public Image characterImage;
    public TMP_Text dialogueText;

    private int dialougePointer;

    public void DisplayNode(CharacterProfile character, DialogueNode node) {
        characterImage.sprite = character.GetEmotion(node.emote);
    }

    public IEnumerator ReadText(string text, float tickSpeed) {

        for (int i = 0; i < text.Length; i++) {

        }
        yield return new WaitForSecondsRealtime(tickSpeed);
    }

    public void ReadDialogue(Dialogue dialogue) {
        dialougePointer = 0;
    }
}
