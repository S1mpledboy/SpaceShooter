using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private float _laserSpeed = 7f;
    void Update()
    {
        transform.Translate((Vector3.up)*_laserSpeed*Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (transform.position.y > GameManager.screenBounds.y*-1.5f)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
