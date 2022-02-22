using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 birdStartPosition;
    public float maxDragDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
        birdStartPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() 
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    public void OnMouseUp()
    {
        float force = Random.Range(800f, 1000f);
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 currentPosition = rb.position;
        Vector2 direction = birdStartPosition - currentPosition;
        direction.Normalize();
        rb.isKinematic = false;
        rb.AddForce(direction * force);
        //Debug.Log(force);       // checking random force.
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        // mouse position coverted to world point.
        Vector2 desiredPosition = mousePosition;
        if(desiredPosition.x > birdStartPosition.x)
        {
            desiredPosition.x = birdStartPosition.x;
        }
        // transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);       // assigning mouse position to bird position.
        float distance = Vector2.Distance(desiredPosition,birdStartPosition);
        if(distance > maxDragDistance)
        {
            Vector2 direction = desiredPosition - birdStartPosition;
            direction.Normalize();
            desiredPosition = birdStartPosition + (direction * maxDragDistance);
        }
        rb.position = desiredPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelete());        
    }

    IEnumerator ResetAfterDelete()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("this is a coroutine function");
        rb.position = birdStartPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }

}
