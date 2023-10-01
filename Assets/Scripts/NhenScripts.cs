using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhenScripts : MonoBehaviour
{
    // Biên di chuyển lên xuống
    [SerializeField]
    private float topBound;
    [SerializeField]
    private float bottomBound;

    // Tốc độ di chuyển
    [SerializeField]
    private float speed;

    // Hướng di chuyển
    [SerializeField]
    private bool isGoingUp;

    private bool isShot = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float positionY = transform.position.y;

        if (positionY <= bottomBound)
        {
            isGoingUp = true;
        }
        else if (positionY >= topBound)
        {
            isGoingUp = false;
        }

        if (isGoingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
