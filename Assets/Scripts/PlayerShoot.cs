using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bpm;
    private float time = 0f;

    public Camera fps_cam;
    private AudioSource audioController;

    [SerializeField]
    private AudioClip sound;
}
