using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 0, 0, 1);
    [SerializeField] float packageDestroyDelay = 0.5f;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("bump");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked up");
            hasPackage = true;
            Destroy(other.gameObject, packageDestroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

        Debug.Log("enter");
    }
}
