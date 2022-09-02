using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WeaponGenerator : MonoBehaviour
{

    [SerializeField]
    Weapon _weapon;

    List<Sprite> _bananas;
    List<Sprite> _birds;
    List<Sprite> _eggplants;
    List<Sprite> _fires;
    List<Sprite> _guitars;
    List<Sprite> _oranges;
    List<Sprite> _strawberries;
    List<Sprite> _teddies;
    List<Sprite> _waters;
    List<Sprite> _zucchinis;
    List<Sprite> _projectiles;

    List<string> _weaponAdj = new List<string>() { "Petty", "Scary", "Godly", "Fun", "Uber", "Wacky", "Weak", "Rusty", "Leaky", "Icky", "Wonky", "Lucky", "Sassy", "Slow", "Quick", "Corny", "Dark", "Evil", "Shady", "Dingy", "Erect", "Ethic", "Fetid", "Jaggy", "Jerky", "Kinky", "Macho", "Magic", "Manly", "Milky", "Needy", "Noisy", "Perky", "Rabid", "Salty", "Thick", "Zinky" };

    List<string> _weaponName = new List<string>() { "Banana", "Eggplant", "Strawberry", "Guitar", "Orange", "Water", "Fire", "Zucchini" };
    // Start is called before the first frame update
    void Awake()
    {
        LoadWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadWeapons()
    {
        
            var te = Resources.LoadAll("Weapons/Banana", typeof(Sprite)).Cast<Sprite>();
            _bananas = te.ToList();

        te = Resources.LoadAll("Weapons/Bird", typeof(Sprite)).Cast<Sprite>();
        _birds = te.ToList();

        te = Resources.LoadAll("Weapons/Eggplant", typeof(Sprite)).Cast<Sprite>();
        _eggplants = te.ToList();

        te = Resources.LoadAll("Weapons/Fire", typeof(Sprite)).Cast<Sprite>();
        _fires = te.ToList();

        te = Resources.LoadAll("Weapons/Guitar", typeof(Sprite)).Cast<Sprite>();
        _guitars = te.ToList();

        te = Resources.LoadAll("Weapons/Orange", typeof(Sprite)).Cast<Sprite>();
        _oranges = te.ToList();

        te = Resources.LoadAll("Weapons/Strawberry", typeof(Sprite)).Cast<Sprite>();
        _strawberries = te.ToList();

        te = Resources.LoadAll("Weapons/Teddy", typeof(Sprite)).Cast<Sprite>();
        _teddies = te.ToList();

        te = Resources.LoadAll("Weapons/Water", typeof(Sprite)).Cast<Sprite>();
        _waters = te.ToList();

        te = Resources.LoadAll("Weapons/Zucchini", typeof(Sprite)).Cast<Sprite>();
        _zucchinis = te.ToList();

        te = Resources.LoadAll("Weapons/Projectiles", typeof(Sprite)).Cast<Sprite>();
        _projectiles = te.ToList();
    }
    public void GenerateWeapon(float bulletSpeed, float bulletDamage, float bulletRange, float bulletFireDelay, float bulletBounce, int weaponCategory)
    {
        _weapon._bulletSpeed = bulletSpeed;
        _weapon._bulletDamage = bulletDamage;
        _weapon._bulletRange = bulletRange;
        _weapon._bulletFireDelay = bulletFireDelay;
        _weapon._bulletBounce = bulletBounce;
        _weapon._spriteRenderer.sprite = GetListByCategory(weaponCategory)[Random.Range(0, GetListByCategory(weaponCategory).Count)];
        _weapon._name = _weaponAdj[Random.Range(0, _weaponAdj.Count)] + _weaponName[weaponCategory];
        _weapon._bulletPrefab.GetComponent<SpriteRenderer>().sprite = _projectiles[Random.Range(0, _projectiles.Count)];
    }
    List<Sprite> GetListByCategory(int cat)
    {
        switch(cat)
        {
            case 0: return _bananas;
                break;
            case 1: return _birds;
                break;
            case 2: return _eggplants;
                break;
            case 3: return _fires;
                break;
            case 4: return _guitars;
                break;
            case 5: return _oranges;
                break;
            case 6: return _strawberries;
                break;
            case 7: return _teddies;
                break;
            case 8: return _waters;
                break;
            case 9: return _zucchinis;
                break;
            default:
                return _bananas;
                break;
        }
    }
}
