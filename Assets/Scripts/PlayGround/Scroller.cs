using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float Speed;
    Vector3 StartPosition;
    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        var Offset = Mathf.Repeat(Time.time * Speed, 120);
        transform.position = StartPosition + Vector3.back * Offset;
    }
}
