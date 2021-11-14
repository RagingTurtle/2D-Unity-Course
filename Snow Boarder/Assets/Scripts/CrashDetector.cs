using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float waitTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground"){
            Debug.Log("bump");
            Invoke("ReloadScene", waitTime);
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
