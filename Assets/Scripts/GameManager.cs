using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    int _numEnemies;
    public UnityAction OnEnemyDeath;
    public UnityAction OnPlayerWon;
    [SerializeField]
    DungeonGenerator _dungeonGenerator;
    [SerializeField]
    PlayerCharacter _playerCharacter;
    [SerializeField]
    WeaponGenerator _weaponGenerator;
    int _gamesWon = 0;
    // Start is called before the first frame update
    void Start()
    {
        GenerateNewLevel();
        _playerCharacter.OnDeath += PlayerDied;
        _dungeonGenerator.OnEnemyDied += EnemyDied;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        _dungeonGenerator.OnEnemyDied -= EnemyDied;
        _playerCharacter.OnDeath -= PlayerDied;


    }
    void GenerateNewLevel()
    {
        //TODO: Randomize character 
        _numEnemies = _dungeonGenerator.StartNewLevel(_gamesWon);
        _weaponGenerator.GenerateWeapon(10,10,4,0.2f, 0, Random.Range(0,8));
    }
    void EnemyDied()
    {
        OnEnemyDeath?.Invoke();
        _numEnemies--;
        if (_numEnemies <= 0)
        {
            GenerateNewLevel();
            OnPlayerWon?.Invoke();
            _gamesWon++;
        }

        }
    void PlayerDied()
    {
        _gamesWon = 0;
        GenerateNewLevel();
    }
}
