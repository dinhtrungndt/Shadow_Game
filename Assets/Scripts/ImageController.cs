using System.Collections;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    private bool shouldDisappear = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground_be"))
        {
            StartCoroutine(DisappearAfterDelay(6f));
        }
    }

    private IEnumerator DisappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Biến mất đối tượng "Ground_be" tại đây
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
