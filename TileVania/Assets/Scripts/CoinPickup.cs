using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] int pointsForCoin = 100;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToScore(pointsForCoin);
            Destroy(gameObject);
        }
    }
}
