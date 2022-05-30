using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsScreen : MonoBehaviour
{
    public static Text textUI;

    public void Start()
    {
        textUI = GetComponent<Text>();
    }

    public static void UpdateUI(int currentN, int totN)
    {
        textUI.text = currentN + "/" + totN;
    }
}
