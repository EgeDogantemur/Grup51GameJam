using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lightNM
{
    public class light : MonoBehaviour
    {
        [SerializeField] AudioSource lightSound;
        public int collectedLights = 0;

        private void Start()
        {
            collectedLights = 0;
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Light"))
            {
                Destroy(other.gameObject);
                collectedLights = 1;
                lightSound.Play();

            }

        }

    }


}









