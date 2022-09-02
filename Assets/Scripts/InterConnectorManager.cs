using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InterConnectorManager : MonoBehaviour
{

    public Weapon Weapon;
    public PlayerCharacter Character;

    public UI_Manager uiManager;
    
    void Awake()
    {
        uiManager = FindObjectOfType<UI_Manager>();
    }

    private void Start()
    {

        if(uiManager !=null)
        {

            uiManager.setCharUI(Character._movementSpeed, Character._maxHealth);
            uiManager.setGunUI(Weapon._spriteRenderer.sprite, Weapon._name, Weapon._bulletSpeed,Weapon._bulletDamage,Weapon._bulletFireDelay);

        }
}
}
