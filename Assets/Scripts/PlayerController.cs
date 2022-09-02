using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _moveX = 0.0f;
    float _moveY = 0.0f;
    float _fireX = 0.0f;
    float _fireY = 0.0f;
    Vector2 _movement;
    [SerializeField]
    PlayerCharacter _playerCharacter;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        _playerCharacter._moveX = Input.GetAxis("Horizontal");
        _playerCharacter._moveY = Input.GetAxis("Vertical");

        _playerCharacter._fireX = Input.GetAxis("HorizontalFire");
        _playerCharacter._fireY = Input.GetAxis("VerticalFire");

        _movement.x = _playerCharacter._moveX;
        _movement.y = _playerCharacter._moveY;

        animator.SetFloat("Horizontal", _playerCharacter._moveX);
        animator.SetFloat("Vertical", _playerCharacter._moveY);
        animator.SetFloat("Speed", _movement.sqrMagnitude);

    }
}
