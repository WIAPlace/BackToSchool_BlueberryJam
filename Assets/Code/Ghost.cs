using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public float distanceBetween;

    [SerializeField]
    [Tooltip("What layer will damage this entity")] 
    private LayerMask damageLayer; // Damage layer is serializable so that only something of this layer will hurt it
    
    private bool continueAI = true;

    //[SerializeField]
    //[Tooltip("how many seconds in between being hit until you can take damage again.")]
    //ivate float hitDelay; // will be multiplied by 50 so that it works in fixed update

    //private float currentDelayTime =0;
   // private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(continueAI){
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            // ^ Move AI
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
            // ^ Rotate AI towards player

            if(distance < distanceBetween)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    { // when hit by light move backwards
        if((damageLayer.value & (1 << collision.gameObject.layer)) != 0 && currentDelayTime <= 0)
        { 
            Debug.Log("Hit");
            currentDelayTime = hitDelay*50;
            
        }
    }
    void FixedUpdate()
    {
        
        if (currentDelayTime > 0)
        {
            currentDelayTime-=1;
            rb.velocity = *(speed*Time.deltaTime);
            Debug.Log(rb.velocity);
        }
    }
    */
}
