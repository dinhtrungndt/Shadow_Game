using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee0 : MonoBehaviour
{
    public bool IsLeft;
    public GameObject Player;
    public float Speed;

    // Update is called once per frame
    void Update()
    {

        Rotation();
        Motivation();
    }

    void Motivation()
    {
        float direction = transform.localScale.x;
        if(direction <= 0)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }

    void Rotation()
    {
        if (Player != null)
        {
            float PlayerX = Player.transform.position.x;
            float PositionX = transform.position.x;
            IsLeft = PlayerX <= PositionX;
            Vector3 scale = transform.localScale;
            if (IsLeft)
            {
                if (scale.x < 0) scale.x *= -1;
            }
            else
            {
                if (scale.x > 0) scale.x *= -1;
            }
            transform.localScale = scale;
        }
    }

    public void InstantiatePlaye(GameObject gameObject)
    {
        Player = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        // quái chạm vào nhân vật
        if (player.transform.position.y > (transform.position.y + 1f))
        {
            Debug.Log("Trên");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Khác");
        }
    }

}
