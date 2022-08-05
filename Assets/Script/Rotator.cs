using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int speed = 500;
        float degree = Time.deltaTime * speed;
        transform.Rotate(0, degree, 0);
    }
}
