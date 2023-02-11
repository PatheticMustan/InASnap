using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textspeed;
    private int index;
    public Button SignIN;
    public InputField Password;


    void Start()
    {
        textcomponent.text = string.Empty;
        StartD();
        SignIN.interactable = false;
    }
    private void StartD()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textspeed);
            StopCoroutine(TypeLine());
            if (Password == null) {
                SignIN.interactable = false;
            } else {
                SignIN.interactable = true;
            }
        }
    }


}
