using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private BoxCollider body;

    public void Start()
    {
        body = GetComponent<BoxCollider>();
    }
}
