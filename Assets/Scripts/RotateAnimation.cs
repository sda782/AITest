using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    private float start_angle;
    void Start()
    {
        start_angle = Random.Range(0, 360);
        transform.Rotate(Vector3.forward, start_angle);
    }
    void Update()
    {
        transform.Rotate(Vector3.forward, 10 * Time.deltaTime);
    }
}
