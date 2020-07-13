using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float ShotDelay;
    private float NextShotTime;
    public float MiniShotDelay;
    private float NextMiniShotTime;
    public Transform MiniLaserGunLeft;
    public Transform MiniLaserGunRight;
    public Transform LaserGun;
    public GameObject MiniLaserShotLeft;
    public GameObject MiniLaserShotRight;
    public GameObject LaserShot;

    public float XMin, XMax, YMin, YMax;
    public float Tilt;
    public float Speed;
    Rigidbody Player;

    public GameObject ShipExplosion;
    public int MaxShield;
    public int Shield;
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var HorizontalAxis = Input.GetAxis("Horizontal");
        var VerticalAxis = Input.GetAxis("Vertical");
        Player.velocity = new Vector3(HorizontalAxis, 0, VerticalAxis) * Speed;

        var ClampedX = Mathf.Clamp(Player.position.x, XMin, XMax);
        var ClampedZ = Mathf.Clamp(Player.position.z, YMin, YMax);
        Player.position = new Vector3(ClampedX, 0, ClampedZ);

        Player.rotation = Quaternion.Euler(Player.velocity.z * Tilt,0,-Player.velocity.x * Tilt);

        if (Time.time > NextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(LaserShot, LaserGun.transform.position,Quaternion.identity);
            NextShotTime = Time.time + ShotDelay;
        }
        if (Time.time > NextMiniShotTime && Input.GetButton("Fire2"))
        {
            Instantiate(MiniLaserShotLeft, MiniLaserGunLeft.position, Quaternion.Euler(0, -45, 0));
            Instantiate(MiniLaserShotRight, MiniLaserGunRight.position, Quaternion.Euler(0, 45, 0));
            NextMiniShotTime = Time.time + MiniShotDelay;
        }
    }

    public void GetDamage()
    {
        if (Shield <= 0)
        {
            Instantiate(ShipExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
            Shield--;
    }
}