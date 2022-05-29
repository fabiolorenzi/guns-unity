using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bpm;
    private float time = 0f;

    [SerializeField]
    private bool isSingle = true;
    [SerializeField]
    private bool isAuto = false;

    private AudioSource audioController;

    [SerializeField]
    private AudioClip sound;

    public void Start()
    {
        audioController = GetComponentInChildren<AudioSource>();
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isSingle = !isSingle;
            isAuto = !isAuto;
        }

        Shoot();
    }

    public void Shoot()
    {
        if(isSingle && Input.GetMouseButtonDown(0))
        {
            Debug.Log("single");
            audioController.clip = sound;
            audioController.Play();
        }
        else if(isAuto && Input.GetMouseButton(0))
        {
            if(Time.time >= time)
            {
                Debug.Log("auto");
                audioController.clip = sound;
                audioController.Play();
                time += 60 / bpm;
            }
        }
    }
}
