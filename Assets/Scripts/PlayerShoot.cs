using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Weapon weaponData;
    private float time = 0f;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float distance;

    private ParticleSystem muzzle;

    [SerializeField]
    private bool isSingle = true;
    [SerializeField]
    private bool isAuto = false;

    private AudioSource audioController;

    [SerializeField]
    private AudioClip sound;

    [SerializeField]
    private float accuracy;
    [SerializeField]
    private float maxSpreadAngle;
    [SerializeField]
    private float timeTillMaxSpread;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shootPoint;
    [SerializeField]
    private GameObject cameraRot;

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

        ModeScreen.UpdateText(isSingle);
        Shoot();
    }

    public void Shoot()
    {
        if(isSingle && Input.GetMouseButtonDown(0) && weaponData.currentMagazine > 0)
        {
            LaunchBullet();
            muzzle.Play();
            audioController.clip = sound;
            audioController.Play();
            weaponData.currentMagazine--;
        }
        else if(isAuto && Input.GetMouseButton(0))
        {
            if(Time.time >= time && weaponData.currentMagazine > 0)
            {
                LaunchBullet();
                muzzle.Play();
                audioController.clip = sound;
                audioController.Play();
                time = Time.time + 60f / weaponData.bpm;
                weaponData.currentMagazine--;
            }
        }
    }

    public void LaunchBullet()
    {
        /*RaycastHit hit;
        Quaternion fireRotation = Quaternion.LookRotation(cameraRot.transform.forward);
        float currentSpread = Mathf.Lerp(0f, maxSpreadAngle, accuracy / timeTillMaxSpread);
        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0f, currentSpread));

        if(Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, distance))
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, fireRotation);
            tempBullet.GetComponent<Bullet>().speed = speed;
            tempBullet.GetComponent<Bullet>().hitPoint = hit.point;
        }
        */

        RaycastHit hit;
        if (Physics.Raycast(shootPoint.transform.position, cameraRot.transform.forward, out hit, distance))
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.LookRotation(cameraRot.transform.forward));
            tempBullet.GetComponent<Bullet>().speed = speed;
            tempBullet.GetComponent<Bullet>().hitPoint = hit.point;
        }
    }
}
