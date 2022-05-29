using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 hitPoint;

    [SerializeField]
    private GameObject dirt;

    public float speed;

    public void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position).normalized * speed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            Instantiate(dirt, this.transform.position, this.transform.rotation);
        }
        else if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}
