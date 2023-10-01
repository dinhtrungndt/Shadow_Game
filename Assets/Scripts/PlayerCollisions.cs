using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerAminations playerAminations;

    // coin text:
    [SerializeField]
    private TextMeshProUGUI coinText;
    private int coinNumber;

    //time text
    [SerializeField]
    private TextMeshProUGUI timeText;
    private int timeNumber;


    // Start is called before the first frame update
    void Start()
    {
        playerAminations = GetComponent<PlayerAminations>();
        coinNumber = 0;
        coinText.text = coinNumber + "";
        // chạy đồng hồ 
        timeNumber = 0;
        StartCoroutine(UpdateTime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAminations.SetJumping(true);
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.SetActive(false);
            coinNumber += 1;
            coinText.text = coinNumber + "";
        }
        else if (collision.gameObject.CompareTag("ChuyenMan"))
        {
            // Chuyển đến Scene2
            SceneManager.LoadScene("ASM_Man2");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("---------->>>>>>>>>>>>> CoinNumber + CoinText" + coinNumber + coinText);
        if (collision.gameObject.CompareTag("Coin"))
        {
            // tăng điểm
            coinNumber++;
            coinText.text = coinNumber + "";

        }
    }

    // [0s, 1s, 2s, 3s, ...]
    IEnumerator UpdateTime()
    {
        while (true)
        {
            timeNumber++;
            timeText.text = timeNumber + "s";
            yield return new WaitForSeconds(1);
        }
    }

}
