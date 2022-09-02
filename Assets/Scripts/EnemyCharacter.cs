using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCharacter : MonoBehaviour
{
    public float _movementSpeed = 1.0f;
    public float _maxHealth = 100.0f;
    public float _currentHealth = 100.0f;
    public float _damage = 10.0f;
    public float _fieldOfView = 100.0f;
    public bool _isAggressive = false;
    public bool _isDefensive = false;

    public float _moveX = 0.0f;
    public float _moveY = 0.0f;

    [SerializeField]
    Rigidbody2D _rigidbody2D;

    public UnityAction<EnemyCharacter> OnDeath;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(_moveX, _moveY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.collider.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<PlayerCharacter>().TakeDamage(_damage, transform.position);
                break;
            case "Bullet":
                TakeDamage(collision.gameObject.GetComponent<Bullet>()._bulletDamage);
                collision.gameObject.GetComponent<Bullet>().OnHitEnemy?.Invoke();
                Destroy(collision.gameObject);
                break;
            case "Wall":
                
                    _rigidbody2D.velocity = new Vector2(Random.Range(-_moveX, _moveX), Random.Range(-_moveY, _moveY));
                
                break;
        }
    }
    void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth<= 0.0f)
        {
            OnDeath?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
