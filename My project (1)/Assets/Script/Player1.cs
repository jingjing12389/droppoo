using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private bool isTouchLeft;
    private bool isTouchRight;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        // 왼쪽 화살표가 눌렸을 때
        if (Input.GetKey(KeyCode.LeftArrow)&&!isTouchLeft)
        {
            transform.Translate(-speed, 0, 0); // 왼쪽으로 speed만큼 움직인다
            spriteRenderer.flipX = true;
        }

        // 오른쪽 화살표가 눌렸을 때
        if (Input.GetKey(KeyCode.RightArrow)&&!isTouchRight)
        {
            transform.Translate(speed, 0, 0); // 오른쪽으로 speed만큼 움직인다
            spriteRenderer.flipX = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;

            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;

            }
        }
    }
}
