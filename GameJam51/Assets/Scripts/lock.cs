using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using lightNM;

public class OpenWithLight : MonoBehaviour
{
    [SerializeField] private light lightScript;
    public int sceneId;
    public int requiredLights = 0;


    void OnTriggerEnter2D(Collider2D other)
    {
        int collectedLights = lightScript.collectedLights;

        if (other.CompareTag("Player"))
        {
            if (collectedLights > requiredLights)
            {
                SceneManager.LoadScene(sceneId);
            }
        }
    }


}
