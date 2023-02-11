using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonLVL1 : MonoBehaviour
{
  
    void Start()
    {
        
    }

    public void OpenLvl1() {
        SceneManager.LoadScene("DesktopBluesTest");
    }

}
