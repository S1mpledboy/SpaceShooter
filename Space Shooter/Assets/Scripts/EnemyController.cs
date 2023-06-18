using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        if (IsOutOfScreen()) gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
    private bool IsOutOfScreen()
    {
        if(transform.position.y< GameManager.screenBounds.y+1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
