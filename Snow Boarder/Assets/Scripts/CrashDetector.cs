using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float waitTime;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    public bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasCrashed)
        {
            if (other.tag == "Ground")
            {
                hasCrashed = true;
                FindObjectOfType<PlayerController>().DisableControls();
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                Invoke("ReloadScene", waitTime);
            }
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
