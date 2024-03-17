using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diken : MonoBehaviour
{
    // Düşmanla temas ettiğinde sahneyi yeniden başlatmak için kullanılacak olan tag
    public string enemyTag = "diken";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Temas edilen nesnenin etiketini kontrol et
        if (collision.CompareTag(enemyTag))
        {
            // Sahneyi yeniden başlat
            RestartScene();
        }
    }

    // Sahneyi yeniden başlatan fonksiyon
    private void RestartScene()
    {
        // Aktif sahnenin indeksini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Aktif sahneyi yeniden yükle
        SceneManager.LoadScene(currentSceneIndex);
    }
}
