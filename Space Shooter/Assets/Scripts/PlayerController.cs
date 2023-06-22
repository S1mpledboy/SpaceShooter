using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerClass _player;
    [SerializeField]
    private GameObject _laserBullet;
    [SerializeField]
    private ObjectPooler _Pooler;
    [SerializeField]
    private float _frireRate = 0.3f;
    private Bounds _playerBounds;
    private Vector3 _playerPosition;
    private float _canFire = 0;


    void Start()
    {
        _Pooler = FindObjectOfType<ObjectPooler>();
        _playerBounds = _player.mesh.bounds;
    }

    void Update()
    {
        PlayerMovement();
        PlayerShoot();
    }
    private void LateUpdate()
    {
        CalmpPlayerMovement();
    }
    private void PlayerShoot()
    {
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _frireRate;
            _Pooler.SpawnFromPool(_laserBullet.tag, transform.position, 0f, 1f, 0f);
        }

    }
    private void PlayerMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontal, vertical, 0) * _player.playerSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            _player.DealDamageToPlayer();
            if(_player.health <= 0)
            {
                GameManager.GameOver();
            }
        }
    }
    private void CalmpPlayerMovement()
    {
        _playerPosition = transform.position;
        _playerPosition.x = Mathf.Clamp(_playerPosition.x, GameManager.screenBounds.x + _playerBounds.size.x, GameManager.screenBounds.x * -1 - _playerBounds.size.x);
        _playerPosition.y = Mathf.Clamp(_playerPosition.y, GameManager.screenBounds.y + _playerBounds.size.y, GameManager.screenBounds.y * -1 - _playerBounds.size.y);
        transform.position = _playerPosition;
    }
}
