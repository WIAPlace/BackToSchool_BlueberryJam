using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMove : MonoBehaviour
{
    
    public float speed = 1f;
    private Animator anim;

    
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        anim.SetInteger("Vertical", 0);
        anim.SetInteger("Horizontal", 0);

        
        
        
        

        if (Input.GetKey(KeyCode.S))
        {
            pos.y = pos.y - speed * Time.deltaTime;
            anim.SetInteger("Vertical", -1);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            pos.x = pos.x - speed * Time.deltaTime;
            anim.SetInteger("Horizontal", -1);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
            anim.SetInteger("Horizontal", 1);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            pos.y = pos.y + speed * Time.deltaTime;
            anim.SetInteger("Vertical", 1);
        }
        transform.position = pos;
    }

    
    
}
