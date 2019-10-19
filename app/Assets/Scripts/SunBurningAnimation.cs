using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBurningAnimation : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
