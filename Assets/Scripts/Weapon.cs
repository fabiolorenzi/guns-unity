using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int bpm;

    [SerializeField]
    private int fullMagazine;
    [HideInInspector]
    public int currentMagazine;

    public void Start()
    {
        currentMagazine = fullMagazine;
    }

    public void Update()
    {
        if(currentMagazine < fullMagazine && Input.GetKeyUp(KeyCode.R))
        {
            currentMagazine = fullMagazine;
        }

        BulletsScreen.UpdateUI(currentMagazine, fullMagazine);
    }
}
