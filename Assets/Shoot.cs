using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody2D bulletPrefab;

    [SerializeField] private float shootDelay = 0.5f;
    private float lastShootTime = -Mathf.Infinity;

    [Header("Projectile Settings")]
    [SerializeField] private float gravity = -9.8f;  // แรงโน้มถ่วง (คุณสามารถปรับค่าได้)
    [SerializeField] private float timeToTarget = 1f; // เวลาในการยิงไปถึงเป้าหมาย (ปรับตามต้องการ)

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastShootTime + shootDelay)
        {
            lastShootTime = Time.time;

            // แปลงตำแหน่งเมาส์ในจอ เป็นตำแหน่งในโลก 2D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.magenta, 5f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                // ย้าย Target ไปที่ตำแหน่งคลิก
                target.transform.position = new Vector2(hit.point.x, hit.point.y);

                // สร้างกระสุนใหม่
                Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

                // คำนวณความเร็วเริ่มต้นและทิศทางสำหรับการยิง
                Vector2 direction = hit.point - (Vector2)shootPoint.position; // คำนวณระยะห่าง
                float distance = direction.magnitude; // ระยะห่างจากจุดยิงถึงเป้าหมาย
                direction.Normalize(); // ทิศทางของการยิง

                // คำนวณความเร็วในแกน Y
                float velocityY = (distance / timeToTarget) + 0.5f * Mathf.Abs(gravity) * timeToTarget;
                // คำนวณความเร็วในแกน X
                float velocityX = direction.x * (distance / timeToTarget);

                // ใช้ความเร็วที่คำนวณมา
                Vector2 projectileVelocity = new Vector2(velocityX, velocityY);
                firedBullet.velocity = projectileVelocity;

                // เพิ่ม BulletBehavior ให้กระสุน
                if (!firedBullet.GetComponent<BulletBehavior>())
                {
                    firedBullet.gameObject.AddComponent<BulletBehavior>();
                }

                // ทำลายกระสุนหลังจาก 3 วินาที
                Destroy(firedBullet.gameObject, 2f);
            }
        }
    }
}
