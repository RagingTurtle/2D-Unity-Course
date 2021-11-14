using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float waitTime;
    void OnTriggerEnter2D(Collider2D other) 
    {
        
            if (other.tag == "Player")
            {
                Debug.Log("finish");
                Invoke("ReloadScene", waitTime);
            }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
