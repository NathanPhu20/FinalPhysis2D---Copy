using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSc : MonoBehaviour
{
    public string sceneToLoad; // ชื่อซีนที่ต้องการโหลด

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่าเป็นผู้เล่นหรือไม่
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
