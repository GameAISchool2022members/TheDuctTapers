using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float _moveX = 0.0f;
    public float _moveY = 0.0f;

    public float _fieldOfView = 100.0f;
    public bool _isAggressive = false;
    public bool _isDefensive = false;

    [SerializeField]
    EnemyCharacter _enemyCharacter;

    public float _actionDelay = 3.0f;
    float _timer = 3.0f;

    private float r;

 private bool movingRight = true;

    public Transform wallDetection;   

    // Start is called before the first frame update
    void Start()
    {
            r = Random.Range(0f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log("!");
        _timer += Time.deltaTime;
        if (_timer > _actionDelay)
        {
            // MoveRandom();
            
            _timer = 0.0f;
        }
    }
    void FixedUpdate()
    {RaycastHit2D wallInfo;
       
        if( r >= 15f){
 wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, 3f);
        }else  if( r >= 10f){
            wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, 3f);
 
        }else  if( r >= 5f){
             wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.up, 3f);
 
        }else{
 wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.down, 3f);
 
        }

          Debug.Log(wallInfo.collider.tag);
        if(wallInfo.collider.tag == "Wall")
{
  float dist = Vector2.Distance(this.transform.position,wallInfo.collider.transform.position);
    Debug.Log(dist);

    float step = 10 * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, wallInfo.collider.transform.position, step);


}else{
     _enemyCharacter._moveX = Random.Range(-10, 10);
        _enemyCharacter._moveY = Random.Range(-10, 10);
          r = Random.Range(0f, 20f);
}
    }

    
}
