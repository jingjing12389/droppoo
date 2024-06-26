using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private bool isTouchLeft;
    private bool isTouchRight;
    void Update()
    {
        // 왼쪽 화살표가 눌렸을 때
        if (Input.GetKey(KeyCode.LeftArrow)&&!isTouchLeft)
        {
            transform.Translate(-speed, 0, 0); // 왼쪽으로 「3」 움직인다
        }

        // 오른쪽 화살표가 눌렸을 때
        if (Input.GetKey(KeyCode.RightArrow)&&!isTouchRight)
        {
            transform.Translate(speed, 0, 0); // 오른쪽으로 「3」 움직인다
        }
    }
    private void onTriggerEnter2D(Collider2D collision) 
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
    private void onTriggerExit2D(Collider2D collision)
    {

    }
}