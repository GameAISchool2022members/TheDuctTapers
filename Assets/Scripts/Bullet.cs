using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    float _bulletSpeed = 1.0f;
    public float _bulletDamage = 1.0f;
    float _bulletRange = 1.0f;
    float _bulletBounce = 0.0f;
    Vector2 _bulletDir = new Vector2();
    [SerializeField]
    Rigidbody2D _rigidbody2D;

    public UnityAction OnHitEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize(float bulletSpeed, float bulletDamage, float bulletRange, float bulletBounce, Vector2 bulletDir)
    {
        _bulletSpeed = bulletSpeed;
        _bulletDamage = bulletDamage;
        _bulletRange = bulletRange;
        _bulletBounce = bulletBounce;
        _bulletDir = bulletDir;
        _rigidbody2D.velocity = _bulletDir * _bulletSpeed;
        Destroy(gameObject, _bulletRange);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            if (_bulletBounce <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
