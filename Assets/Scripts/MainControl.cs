using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;
    private Vector2 getScale;
    private bool canMove;
    public GameObject canvasForTakeObj;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
       
        getScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        AnimControl();
        NoiseDetect();
        if (canMove)
        {
            Move();
        }
    }
    void Move()
    {
        
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector2 moving = new Vector2 (horizontalMove, verticalMove);
        rb.velocity = moving.normalized * speed;
    }
    void AnimControl()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("speed", 1);
        }
        else
        {
            anim.SetFloat("speed", 0);
        }
    }
    public void TakeObject()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
        anim.SetBool("take", true);
        canvasForTakeObj.SetActive(true);
    }
    public void StopTaking()
    {
        canMove = true;
        anim.SetBool("take", false);
    }
    void Direction()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = getScale;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector2(-getScale.x, getScale.y);
            }
        }
    }

    public void TakeSliderEffect(float time)
    {
        Slider slid = canvasForTakeObj.transform.Find("Border").gameObject.GetComponent<Slider>();
        
        slid.value += (float)0.02f / time;
        if(slid.value >= slid.maxValue)
        {
            slid.value = 0f;
            
        }
    }
    void NoiseDetect()
    {
        if(rb.velocity != Vector2.zero)
        {
            slider.value -= 0.0025f;
        }
    }

}
