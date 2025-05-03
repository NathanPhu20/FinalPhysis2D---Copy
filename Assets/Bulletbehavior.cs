using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public string sceneToLoad; // ชื่อซีนที่ต้องการโหลด
    // ตรวจจับเมื่อกระสุนชนกับศัตรู
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าเป็นศัตรู (ตามที่ตั้งไว้ใน Tag)
        if (other.CompareTag("Enemy1"))
        {
            // ลบศัตรู
            Destroy(other.gameObject);

            // ลบกระสุน
            Destroy(gameObject);
        }
    }
}
