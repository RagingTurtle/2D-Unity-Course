using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip ShootingClip;
    [SerializeField] [Range(0f, 1f)] float ShootingVolume = 1f;
    [Header("Damage")]
    [SerializeField] AudioClip DamageClip;
    [SerializeField] [Range(0f, 1f)] float DamageVolume = 1f;


    public void PlayShootingClip()
    {
        PlayClip(ShootingClip, ShootingVolume);
    }
    public void PlayDamageClip()
    {
        PlayClip(DamageClip, DamageVolume);
    }
    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
