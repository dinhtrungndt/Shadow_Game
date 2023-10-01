using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaiDauScripts : MonoBehaviour
{
    // biên di chuyển trái phải
    [SerializeField]
    private float leftBound;
    [SerializeField]
    private float rightBound;

    // tốc độ di chuyển
    [SerializeField]
    private float speed;

    // hướng di chuyển
    [SerializeField]
    private bool isOnRight;

    private bool isShot = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float positionX = transform.position.x;
        //float positionX = transform.localPosition.x;

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
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }


}
