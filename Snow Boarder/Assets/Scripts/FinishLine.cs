using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float waitTime;
    [SerializeField] ParticleSystem finishEffect;
    bool hasFinished = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasFinished && !(FindObjectOfType<CrashDetector>().hasCrashed))
        {
            if (other.tag == "Player")
            {
                hasFinished = true;
                finishEffect.Play();
                GetComponent<AudioSource>().Play();
                Invoke("ReloadScene", waitTime);
            }
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
