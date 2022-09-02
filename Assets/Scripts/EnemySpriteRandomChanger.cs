using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemySpriteRandomChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public float random_prob;
    private int current_sprite_rand;
    private Sprite current_sprite;
    private string current_sprite_id;
    private int current_sprite_stage;

    void Start()
    {
          spriteArray = Resources.LoadAll<Sprite>("enemy_sprites");
          spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

          current_sprite_rand  = UnityEngine.Random.Range(1,spriteArray.Length);
	   
	  current_sprite = spriteArray[current_sprite_rand];
	  string name = current_sprite.name;
	  int break_idx = name.IndexOf("_");
	  
	  string[] sprite_info = name.Split("_");
	  
	  current_sprite_id = sprite_info[0];
	  current_sprite_stage = Convert.ToInt32(sprite_info[1]);
          spriteRenderer.sprite = current_sprite;
          
          Debug.Log(current_sprite_id);
          Debug.Log(current_sprite_stage);
          
          InvokeRepeating("MoveEnemy", 2.0f, 0.5f);
    }   
    
    void Update()
    {
	
	float prob = UnityEngine.Random.Range(0.0f, 1.0f);
	
	if (prob < random_prob)
	{
	 current_sprite_rand  = UnityEngine.Random.Range(1,spriteArray.Length);
         current_sprite = spriteArray[current_sprite_rand];
	  string name = current_sprite.name;
	  int break_idx = name.IndexOf("_");
	  
	  string[] sprite_info = name.Split("_");
	  
	  current_sprite_id = sprite_info[0];
	  current_sprite_stage = Convert.ToInt32(sprite_info[1]);
          spriteRenderer.sprite = current_sprite; 
	}	   
	
}



    void MoveEnemy()
    {
        if (current_sprite_stage == 0)
	   {
	   	current_sprite_rand += 1;
	   }
	   
	   else if (current_sprite_stage == 2)
	   {
	   current_sprite_rand -= 1;
	   }
	   
	   else
	   {
	   
	   float prob_move = UnityEngine.Random.Range(0.0f, 1.0f);
	   
	   if (prob_move > 0.5)
	   {
	   	current_sprite_rand += 1;
	   }
	   else
	   {
	   current_sprite_rand -= 1;
	   }
	   
	   }
	  
	  current_sprite = spriteArray[current_sprite_rand];
	  string name = current_sprite.name;
	  int break_idx = name.IndexOf("_");
	  
	  string[] sprite_info = name.Split("_");
	  
	  current_sprite_id = sprite_info[0];
	  current_sprite_stage = Convert.ToInt32(sprite_info[1]);
          spriteRenderer.sprite = current_sprite; 	
}


}
