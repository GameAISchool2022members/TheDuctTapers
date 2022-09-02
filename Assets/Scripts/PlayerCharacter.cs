using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : MonoBehaviour
{
    public float _maxHealth = 100.0f;
    public float _currentHealth = 100.0f;
    public float _movementSpeed = 1.0f;
    public float _fieldOfView;
    public float _moveX = 0.0f;
    public float _moveY = 0.0f;
    public float _fireX = 0.0f;
    public float _fireY = 0.0f;
    public bool _isFiring = false;
    public Vector2 _firingDirection = new Vector2();
    public Weapon _weapon;
    public float _invincibilityTime = 2.0f;
    float _currentInvincibilityCooldown = 0.0f;
    [SerializeField]
    Rigidbody2D _rigidbody2D;

    bool _isTakingDamage = false;
    Vector2 _knockbackDir = new Vector2();

    public UnityAction OnDeath;
    public UnityAction OnHitEnemy;
    public UnityAction OnTakeDamage;
    // Start is called before the first frame update
    void Start()
    {
        _weapon.OnHitEnemy += HitEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        _currentInvincibilityCooldown += Time.deltaTime;
        transform.up = new Vector2(0, 1);
        Vector2 movement = new Vector2(_moveX, _moveY);
        movement.Normalize();
        if (!_isTakingDamage)
            _rigidbody2D.velocity = movement * _movementSpeed;

        if (_fireX != 0.0f || _fireY != 0.0f)
        {
            _isFiring = true;
        }
        else
        {
            _isFiring = false;
        }
        if (_isFiring)
        {
            _weapon.Fire(new Vector2(_fireX, _fireY));
        }
    }
    public void TakeDamage(float damage, Vector2 colliderPosition)
    {
        if (_currentInvincibilityCooldown < _invincibilityTime)
            return;
        _currentInvincibilityCooldown = 0.0f;
        Debug.Log("Took " + damage + " damage");
        _currentHealth -= damage;
        _isTakingDamage = true;
        _knockbackDir = (new Vector2(transform.position.x, transform.position.y) - colliderPosition).normalized;
        StartCoroutine(ApplyKnockback(0.3f));
        OnTakeDamage?.Invoke();
        if (_currentHealth <= 0)
        {
            OnDeath?.Invoke();
            _currentHealth = _maxHealth;
        }
    }
    IEnumerator ApplyKnockback(float duration)
    {
        while (duration > 0.0f)
        {
            _rigidbody2D.AddForce(_knockbackDir * 10.0f);
            duration -= Time.deltaTime;
            yield return null;
        }
        _isTakingDamage = false;
    }
    void HitEnemy()
    {
        OnHitEnemy?.Invoke();
    }
}
