using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PressTextPanel : MonoBehaviour 
{
    [SerializeField]
    private TMPro.TMP_Text pressTxt;

    public void ShowText(KeyCode keycode)
    {
        pressTxt.text = "Press " + keycode.ToString() + " for Attack";
    }

    public void CloseText()
    {
        pressTxt.text = "";
    }

 
}
