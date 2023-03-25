using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class DialogueReader : InputReciever
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private bool recieveInput;

    private AudioSource characterBlip;

    private Dialogue dialogueObj;
    private DialogueNode currentNode;
    private int dialougePointer;
    private bool dialoguePlaying;
    private bool isTalking;
    private IEnumerator textReading;
    public Button TranstionButton;


    void Start() {
        if (TranstionButton) TranstionButton.interactable = false;
    }
    private new void Awake() {
        base.Awake();

        characterBlip = GetComponent<AudioSource>();
    }

    protected override void APress() {
        if (recieveInput && dialoguePlaying) {
            if (isTalking && !currentNode.hasMaxTime) {
                SkipDialogue();
            } else {
                NextNode();
            }
            
        }
    }

    public void StartGame() {
        GameManager.Instance.isPlaying = true;
        GameManager.Instance.gameTime = 0;
    }

    public void ReadDialogue(Dialogue dialogue) {
        dialougePointer = 0;
        dialoguePlaying = true;
        dialogueObj = dialogue;

        currentNode = dialogueObj.dialogue[0];
        DisplayNode(dialogueObj.characters[currentNode.characterID], currentNode);
    }

    public void SkipDialogue() {
        if (textReading != null) {
            StopCoroutine(textReading);
            dialogueText.text = currentNode.text;
            isTalking = false;
        }
    }

    public void NextNode() {
        dialougePointer++;

        if (dialougePointer >= dialogueObj.dialogue.Length) {
            dialoguePlaying = false;

            StartGame();

            /*if(dialoguePlaying == false) {
                if (TranstionButton) TranstionButton.interactable = true;
            }*/
           
            return;
        }

        currentNode = dialogueObj.dialogue[dialougePointer];
        DisplayNode(dialogueObj.characters[currentNode.characterID], currentNode);
    }

    public void DisplayNode(CharacterProfile character, DialogueNode node) {
        characterImage.sprite = character.GetEmotion(node.emote);
        characterBlip.clip = character.textBlip;

        characterNameText.text = character.characterName;
        characterNameText.color = character.color;

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

    public void ButtonLvlSelection() {
        SceneManager.LoadScene("LevelSelection");
    }
}