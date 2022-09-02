using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public float _bulletSpeed = 1.0f;
    public float _bulletDamage = 1.0f;
    public float _bulletRange = 1.0f;
    public float _bulletFireDelay = 1.0f;
    public float _bulletBounce = 0.0f;
    public Bullet _bulletPrefab;
    public SpriteRenderer _spriteRenderer;
    public string _name;
    [SerializeField]
    PlayerCharacter _playerCharacter;
    [SerializeField]
    AudioSource _audioSource;

    float _timer = 0.0f;

    public UnityAction OnHitEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
    }
    public void Fire(Vector2 dir)
    {
        if (_timer < _bulletFireDelay)
            return;
        _audioSource.Play();
        _timer = 0.0f;
        dir.Normalize();
        Bullet bullet =  Instantiate(_bulletPrefab, _playerCharacter.transform.position, Quaternion.identity);
        bullet.OnHitEnemy += HitEnemy;
        bullet.Initialize(_bulletSpeed, _bulletDamage, _bulletRange, _bulletBounce, dir);

    }
    void HitEnemy()
    {
        OnHitEnemy?.Invoke();
    }
}
