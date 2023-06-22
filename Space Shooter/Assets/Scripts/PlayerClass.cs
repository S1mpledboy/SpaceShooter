using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public float playerSpeed = 4f;
    public int health = 3;
    public Mesh mesh;
    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    public void DealDamageToPlayer()
    {
       health--;
        print(health);
    }
}
