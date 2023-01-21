using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class DialogueReader : InputReciever
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private bool recieveInput;

    private AudioSource characterBlip;

    private Dialogue dialogueObj;
    private DialogueNode currentNode;
    private int dialougePointer;
    private bool dialoguePlaying;
    private bool isTalking;
    private IEnumerator textReading;

    

    private new void Awake() {
        base.Awake();

        characterBlip = GetComponent<AudioSource>();
    }

    protected override void APress() {
        if (recieveInput && dialoguePlaying && !isTalking) {
            NextNode();
        }
    }

    public void ReadDialogue(Dialogue dialogue) {
        dialougePointer = 0;
        dialoguePlaying = true;
        dialogueObj = dialogue;

        currentNode = dialogueObj.dialogue[0];
        DisplayNode(dialogueObj.characters[currentNode.characterID], currentNode);
    }

    public void NextNode() {
        dialougePointer++;

        if (dialougePointer >= dialogueObj.dialogue.Length) {
            dialoguePlaying = false;
            return;
        }

        currentNode = dialogueObj.dialogue[dialougePointer];
        DisplayNode(dialogueObj.characters[currentNode.characterID], currentNode);
    }

    public void DisplayNode(CharacterProfile character, DialogueNode node) {
        characterImage.sprite = character.GetEmotion(node.emote);
        characterBlip.clip = character.textBlip;

        textReading = ReadText(node.text, node.tickSpeed);
        StartCoroutine(textReading);

        if (node.hasMaxTime) {
            StartCoroutine(MaxTimeSkip(node.maxTime));
        }
    }

    public IEnumerator ReadText(string text, float tickSpeed) {

        isTalking = true;

        dialogueText.text = "";
        for (int i = 0; i < text.Length; i++) {

            dialogueText.text += text[i];
            characterBlip.Play();

            yield return new WaitForSecondsRealtime(tickSpeed);
        }

        isTalking = false;
    }

    public IEnumerator MaxTimeSkip(float maxTime) {
        yield return new WaitForSecondsRealtime(maxTime);
        if (textReading != null) {
            StopCoroutine(textReading);
            NextNode();
        } else {
            Debug.LogError("No read?");
        }
    }
}
