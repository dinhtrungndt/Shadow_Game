using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMotivation : MonoBehaviour
{
    public ParticleSystem dust;

    [SerializeField]
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public bool IsRight;

    public PlayerAminations playerAminations;

    // Start is called before the first frame update
    void Start()
    {
        playerAminations = GetComponent<PlayerAminations>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMoving();
        VerticalMoving();
    }

    public void HorizontalMoving()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime);
            playerAminations.SetRunning(1);
            Scaling(true);
            CreateDust();
        }
        else if (horizontalInput < 0)
        {
            transform.Translate(Vector3.left * HorizontalSpeed * Time.deltaTime);
            playerAminations.SetRunning(1);
            Scaling(false);
            CreateDust();
        }
        else
        {
            playerAminations.SetRunning(0);
        }
    }

    public void VerticalMoving()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
        {
            transform.Translate(Vector3.up * VerticalSpeed * Time.deltaTime);
            playerAminations.SetJumping(false);
            CreateDust();
        }
    }

    public void Scaling(bool right)
    {
        if (right != IsRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            IsRight = right;
        }
      
    }

    void CreateDust()
    {
        dust.Play();
    }

}
