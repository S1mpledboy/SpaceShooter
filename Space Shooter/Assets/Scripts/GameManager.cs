using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public static Vector3 screenBounds;
    [SerializeField]
    private PlayerClass _player;
    void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    public static void GameOver()
    {
        print("GameOver");
    }
}
