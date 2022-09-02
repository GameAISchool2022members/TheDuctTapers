using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelModelWriter : MonoBehaviour
{
    [SerializeField]
    List<string> _eventNames = new List<string>();
    [SerializeField]
    PlayerCharacter _playerCharacter;
    [SerializeField]
    GameManager _gameManager;
    float _timer = 0.0f;
    [SerializeField]
    float _noEventInterval = 3.0f;
    public string _filePath;
    // Start is called before the first frame update
    void Start()
    {
        _playerCharacter.OnDeath += LoseLevelEvent;
        _playerCharacter.OnHitEnemy += HitEnemyEvent;
        _gameManager.OnEnemyDeath += KillEnemyEvent;
        _gameManager.OnPlayerWon += WinLevelEvent;
        _playerCharacter.OnTakeDamage += PlayerDamageEvent;

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer>_noEventInterval)
        {
            _timer = 0.0f;
            NoEvent();
        }
    }
    public void PlayerDamageEvent()
    {
        FileReadWrite.AddEvent("Player_hurt");

    }
    void NoEvent()
    {
        FileReadWrite.AddEvent("No_event");
    }
    public void HitEnemyEvent()
    {
        FileReadWrite.AddEvent("Hit_enemy");

    }
    public void KillEnemyEvent()
    {
        FileReadWrite.AddEvent("Kill_enemy");

    }
    public void WinLevelEvent()
    {
        FileReadWrite.AddEvent("Win_level");
        FileReadWrite.WriteToCSV(Application.streamingAssetsPath + Path.DirectorySeparatorChar + _filePath);

    }
    public void LoseLevelEvent()
    {
        FileReadWrite.AddEvent("Lose level");
        FileReadWrite.WriteToCSV(Application.streamingAssetsPath + Path.DirectorySeparatorChar + _filePath);
    }
    void WriteEvent(int id)
    {

    }
}
