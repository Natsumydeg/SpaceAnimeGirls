using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlegAsteroidScript : MonoBehaviour
{
    public GameObject AsteroidExplosion;
    public GameObject ShipExplosion;

    public float RotationSpeed;
    public float MinMovingSpeed, MaxMovingSpeed;
    Rigidbody Asteroid;
    void Start()
    {
        Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * RotationSpeed;

        var RandomMovingSpeed = Random.Range(MinMovingSpeed, MaxMovingSpeed);
        Asteroid.velocity = new Vector3(0, 0, -RandomMovingSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        switch (other.tag)
        {
            case "Player":
                other.gameObject.GetComponent<PlayerScript>().GetDamage();
                GameControllerScript.Instance.AddScore(1);
                break;
            case "Laser":
                Destroy(other.gameObject);
                GameControllerScript.Instance.AddScore(1);
                break;
            case "Asteroid":
                Destroy(other.gameObject);
                Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);
                break;
            case "Enemy":
                Destroy(other.gameObject);
                Instantiate(ShipExplosion, transform.position, Quaternion.identity);
                break;
        }
        Instantiate(AsteroidExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
