using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision2D : MonoBehaviour
{
    [Header("ตั้งชื่อซีนที่ต้องการโหลด")]
    public string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
