using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject ShipExplosion;

    Rigidbody Enemy;
    public float MinMovingSpeed, MaxMovingSpeed;
    float RandomMovingSpeed;
    public float BottomBorder;
    public float LeftBorder;
    public float RightBorder;

    public GameObject EnemyLaserShot;
    public Transform LaserGun;
    public float ShotDelay;
    private float NextShotTime;
    void Start()
    {
        Enemy = GetComponent<Rigidbody>();
        RandomMovingSpeed = Random.Range(MinMovingSpeed, MaxMovingSpeed);
        Enemy.velocity = new Vector3(RandomMovingSpeed, 0, -RandomMovingSpeed);
    }

    void Update()
    {
        if(transform.position.x <= LeftBorder)
        {
            Enemy.velocity = new Vector3(RandomMovingSpeed, 0, -RandomMovingSpeed);
        }
        else if(transform.position.x >= RightBorder)
        {
            Enemy.velocity = new Vector3(-RandomMovingSpeed, 0, -RandomMovingSpeed);
        }
        if(Time.time > NextShotTime)
        {
            Instantiate(EnemyLaserShot, LaserGun.position, Quaternion.identity);
            NextShotTime = Time.time + ShotDelay;
        }
        if (transform.position.z <= BottomBorder)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Enemy.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        switch (other.tag) 
        {
            case "Player":
                other.gameObject.GetComponent<PlayerScript>().GetDamage();
                Instantiate(ShipExplosion, transform.position, Quaternion.identity);
                GameControllerScript.Instance.AddScore(10);
                Destroy(gameObject);
                break;
            case "Laser":
                Destroy(other.gameObject);
                Instantiate(ShipExplosion, transform.position, Quaternion.identity);
                GameControllerScript.Instance.AddScore(10);
                Destroy(gameObject);
                break;
            case "Enemy":
                Instantiate(ShipExplosion, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Instantiate(ShipExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
        }
    }
}
