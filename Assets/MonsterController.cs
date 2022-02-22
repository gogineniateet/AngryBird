using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Sprite  newsprite;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdController birdcontroller = collision.gameObject.GetComponent<BirdController>();
        if ((birdcontroller != null) || (collision.gameObject.tag == "Crate"))
        {
            MonsterDeath();
            
            // Destroy(gameObject);
        }
       
    }

    public void MonsterDeath()
    {
        
        //gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = newsprite;
        score = score + 10;
        Debug.Log(score);
    }


}
