﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * Speed;
    }
}
