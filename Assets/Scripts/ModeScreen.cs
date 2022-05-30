using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeScreen : MonoBehaviour
{
    public static Text textValue;

    public void Start()
    {
        textValue = GetComponent<Text>();
    }

    public static void UpdateText(bool single)
    {
        if (single)
        {
            textValue.text = "SINGLE";
        }
        else
        {
            textValue.text = "AUTO";
        }
    }
}
