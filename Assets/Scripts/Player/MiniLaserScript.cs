using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniLaserScript : MonoBehaviour
{
    public bool IsLeft;
    public float Speed;
    void Start()
    {
        float Dir;
        if (IsLeft == true)
            Dir = -1 * Speed;
        else
            Dir = 1 * Speed;

        GetComponent<Rigidbody>().velocity = new Vector3(Dir, 0, Speed);
    }
}
