using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScripts : MonoBehaviour
{
    // Tên của Scene 2
    public string ASM_Man2;

    // Animator của cánh cửa
    private Animator doorAnimator;

    // Biến kiểm tra cửa đã mở hay chưa
    private bool isDoorOpen = false;

    // Khởi tạo
    void Start()
    {
        // Lấy Animator của cánh cửa
        doorAnimator = GetComponent<Animator>();
    }

    // Kiểm tra va chạm với người chơi
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDoorOpen)
        {
            // Mở cửa bằng cách chuyển trạng thái từ "Close" sang "Open"
            doorAnimator.SetTrigger("OpenDoor");

            // Đánh dấu cửa đã mở
            isDoorOpen = true;

            // Chờ một khoảng thời gian trước khi chuyển sang Scene 2 (nếu cần)
            //StartCoroutine(LoadSceneAfterDelay(2.0f));
        }
    }

}
