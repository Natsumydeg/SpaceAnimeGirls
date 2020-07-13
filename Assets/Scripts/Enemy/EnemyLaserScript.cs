using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserScript : MonoBehaviour
{
    public float Speed;
    public Vector3 Target;
    public GameObject Targ;
    void Start()
    {
        Targ = GameObject.FindGameObjectWithTag("Player");
        try
        { 
            Target = Targ.transform.position;
            Vector3 Dir = Target - transform.position;

            float Angle = Mathf.Atan2(Dir.z, Dir.x) * Mathf.Rad2Deg;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, Angle, 0);
            GetComponent<Rigidbody>().velocity = Dir;
        }
        catch
        {
            GetComponent<Rigidbody>().velocity = Vector3.back * Speed;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerScript>().GetDamage();
            Destroy(gameObject);
        }
    }
}
