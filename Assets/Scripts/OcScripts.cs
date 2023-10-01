using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcScripts : MonoBehaviour
{
    public GameObject ocPrefab; // Prefab của "con óc"
    private GameObject ocInstance; // Đối tượng con óc được tạo ra

    private bool isRunning; // Biến đánh dấu xem con óc đang chạy hay không

    private Vector3 runToPosition = new Vector3(5f, 0f, 0f); // Vị trí chạy qua

    private void Start()
    {
        StartCoroutine(RunOc());
    }

    private IEnumerator RunOc()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            // Tạo một đối tượng con óc mới từ prefab
            ocInstance = Instantiate(ocPrefab, transform.position, Quaternion.identity);

            // Di chuyển con óc tới vị trí chạy qua
            isRunning = true;
            while (ocInstance.transform.position.x < runToPosition.x)
            {
                ocInstance.transform.Translate(Vector3.right * 5.0f * Time.deltaTime);
                yield return null;
            }
            isRunning = false;

            yield return new WaitForSeconds(1.0f); // Thời gian chờ trước khi con óc chạy lại

            // Di chuyển con óc trở lại vị trí ban đầu
            isRunning = true;
            while (ocInstance.transform.position.x > transform.position.x)
            {
                ocInstance.transform.Translate(Vector3.left * 5.0f * Time.deltaTime);
                yield return null;
            }
            isRunning = false;

            // Hủy đối tượng con óc sau khi chạy xong
            Destroy(ocInstance);
        }
    }
}