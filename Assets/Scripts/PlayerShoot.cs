using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Weapon weaponData;
    private float time = 0f;

    private ParticleSystem muzzle;

    [SerializeField]
    private bool isSingle = true;
    [SerializeField]
    private bool isAuto = false;

    private AudioSource audioController;

    [SerializeField]
    private AudioClip sound;

    public void Start()
    {
        weaponData = GetComponent<Weapon>();
        audioController = GetComponentInChildren<AudioSource>();
        muzzle = GetComponentInChildren<ParticleSystem>();
    }

    public void Update()
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
            muzzle.Play();
            audioController.clip = sound;
            audioController.Play();
            weaponData.currentMagazine--;
        }
        else if(isAuto && Input.GetMouseButton(0))
        {
            if(Time.time >= time && weaponData.currentMagazine > 0)
            {
                muzzle.Play();
                audioController.clip = sound;
                audioController.Play();
                time = Time.time + 60f / weaponData.bpm;
                weaponData.currentMagazine--;
            }
        }
    }
}
