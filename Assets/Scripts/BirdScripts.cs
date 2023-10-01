using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScripts : MonoBehaviour
{
    // biên di chuyển trái phải
    [SerializeField]
    private float leftBound;
    [SerializeField]
    private float rightBound;

    // tốc độ di chuyển
    [SerializeField]
    private float speed;

    // hướng mặt
    [SerializeField]
    private bool isOnRight;


    void Start()
    {

    }


    void Update()
    {
        float positionX = transform.position.x;
        //float positionX = transform.localPosition.x;
        //float localPX = transform.localPosition.x;
        if (positionX <= leftBound)
        {
            isOnRight = true;
        }
        else if (positionX >= rightBound)
        {
            isOnRight = false;
        }
        if (isOnRight)

        {
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
