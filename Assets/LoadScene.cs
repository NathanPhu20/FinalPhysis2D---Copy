using UnityEngine;
using UnityEngine.UI;  // ใช้สำหรับ UI
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    public Button loadSceneButton;  // ปุ่มที่ใช้โหลดฉาก
    public string sceneToLoad;  // ชื่อของฉากที่ต้องการโหลด

    void Start()
    {
        // ตั้งค่าให้ปุ่มเมื่อคลิกจะเรียกฟังก์ชัน LoadSceneByName
        loadSceneButton.onClick.AddListener(() => LoadSceneByName(sceneToLoad));
    }

    // ฟังก์ชันโหลดฉาก
    void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
