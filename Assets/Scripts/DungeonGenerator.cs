using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject _floorTile;
    public GameObject _wallTile;
    public int[,] _dungeonGrid;
    public Vector2 _dungeonSize = new Vector2();
    public List<GameObject> _tileList = new List<GameObject>();
    public float _tileSpacing = 1;
    public PlayerCharacter _playerCharacter;
    [SerializeField]
    GameObject _levelHolder;
    public EnemyCharacter _enemyPrefab;
    public List<EnemyCharacter> _enemyList = new List<EnemyCharacter>();
    public int _maxEnemies = 5;
    int _currentEnemies;
    public UnityAction OnEnemyDied;
    List<Texture2D> _dungeonTextures;
    // Start is called before the first frame update
    void Awake()
    {
        ReadDungeons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateRandomDungeon()
    {
        _dungeonSize.x = Random.Range(10, 30);
        _dungeonSize.y = Random.Range(10, 30);
        _dungeonGrid = new int[(int)_dungeonSize.x, (int)_dungeonSize.y];
        for (int i = 0; i < _dungeonSize.x; i++)
        {
            for (int j = 0; j < _dungeonSize.y; j++)
            {
                if (i == 0 || j == 0 || i == _dungeonSize.x - 1 || j == _dungeonSize.y - 1)
                    _dungeonGrid[i, j] = 1;
                else                
                    _dungeonGrid[i, j] = 0;               
            }
        }
    }
    void DestroyDungeon()
    {
        foreach(GameObject go in _tileList)
        {
            Destroy(go);
        }
        _tileList.Clear();
        foreach(EnemyCharacter en in _enemyList)
        {
            Destroy(en.gameObject);
        }
        _enemyList.Clear();
    }
    void CreateDungeon(int gamesWon)
    {
        int enemiesPlaced = 0;
        _maxEnemies = 10 + gamesWon;

        for (int i = 0; i<_dungeonSize.x; i++)
        {
            for(int j=0; j<_dungeonSize.y; j++)
            {
                GameObject go;
                if(_dungeonGrid[i,j] == 1)
                {
                    go = Instantiate(_floorTile, new Vector2(i * _tileSpacing, j * _tileSpacing), Quaternion.identity);
                    if (i > _dungeonSize.x / 2 && j > _dungeonSize.y / 2 && enemiesPlaced < _maxEnemies && Random.Range(0, 100) < 30 * (i / _dungeonSize.x * 4))
                    {
                        EnemyCharacter en = Instantiate(_enemyPrefab, go.transform.position, Quaternion.identity);
                        en._movementSpeed += gamesWon;
                        en._damage += gamesWon * 5;
                        en._maxHealth += gamesWon * 5;
                        en._currentHealth = en._maxHealth;
                        en.OnDeath += EnemyDied;
                        _enemyList.Add(en);
                        enemiesPlaced++;
                    }
                }
                else
                {
                    go = Instantiate(_wallTile, new Vector2(i * _tileSpacing, j * _tileSpacing), Quaternion.identity);
                }
                _tileList.Add(go);
                go.transform.parent = _levelHolder.transform;

            }
        }
        _currentEnemies = enemiesPlaced;
        _playerCharacter.transform.position = new Vector2(_tileSpacing *1.7f, _tileSpacing * 1.7f);

    }
    public int StartNewLevel(int gamesWon)
    {
        DestroyDungeon();
        //TODO - Load a new dungeon
        GenerateDungeonFromTexture();
        CreateDungeon(gamesWon);
        return _currentEnemies;
    }
    void ReadDungeons()
    {
        var te = Resources.LoadAll("Dungeons", typeof(Texture2D)).Cast<Texture2D>();
        _dungeonTextures = te.ToList();

    }
    void GenerateDungeonFromTexture()
    {
        int dungeonNum = Random.Range(0, _dungeonTextures.Count);
        _dungeonSize.x = _dungeonTextures[dungeonNum].width;
        _dungeonSize.y = _dungeonTextures[dungeonNum].height;
        _dungeonGrid = new int[(int)_dungeonSize.x, (int)_dungeonSize.y];
        for (int i = 0; i < _dungeonSize.x; i++)
        {
            for (int j = 0; j < _dungeonSize.y; j++)
            {
                if (i == 0 || j == 0 || i == _dungeonSize.x - 1 || j == _dungeonSize.y - 1)
                    _dungeonGrid[i, j] = 0;
                else
                    _dungeonGrid[i, j] = Mathf.RoundToInt(_dungeonTextures[dungeonNum].GetPixel(i, j).r);
            }
        }
    }
    void EnemyDied(EnemyCharacter enemy)
    {
        _enemyList.Remove(enemy);
        OnEnemyDied?.Invoke();
    }
}
