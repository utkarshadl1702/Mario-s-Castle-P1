using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("Hit");
        }
    }
}
