using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back * Speed;   
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerScript Scr = other.GetComponent<PlayerScript>();
            if(Scr.Shield < Scr.MaxShield)
            {
                Scr.Shield++;
                GameControllerScript.Instance.AddScore(5);
                Destroy(gameObject);
            }
        }
    }
}
