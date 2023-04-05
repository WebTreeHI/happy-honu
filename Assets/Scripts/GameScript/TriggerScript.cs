using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameLogicScript GameLogic;
    // Start is called before the first frame update
   void Start()
    {
      // this is tricky to remember. but it looks for a game object tagged "GameLogic", you had to make the Tag in Unity 
       GameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogicScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.layer == 3)
      {
      GameLogic.addScore(1);
      }

    }
}
