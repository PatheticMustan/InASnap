using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDisplay : InputReciever
{
    [SerializeField] private Transform iconParent;
    [SerializeField] private ObjectPool iconPrefab;

    //[SerializeField] private int maxIcons;

    [SerializeField] private Sprite[] inputIcons = new Sprite[11];

    private new void Awake() {
        base.Awake();

        iconPrefab.AddObjects();
    }

    protected override void InputAction(InputID inputID) {
        base.InputAction(inputID);

        StartCoroutine(SpawnIcon((int)inputID - 1));
    }

    public IEnumerator SpawnIcon(int id) {
        GameObject obj = iconPrefab.GetObject();
        //obj.transform.parent = iconParent;
        obj.transform.localScale = Vector3.one;
        obj.GetComponent<Image>().sprite = inputIcons[id];

        yield return new WaitForSeconds(3f);

        obj.SetActive(false);
    }
}
