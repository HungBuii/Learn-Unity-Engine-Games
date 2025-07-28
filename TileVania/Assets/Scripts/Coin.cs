using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            // gameObject.SetActive(false); // or needn't add this code because has "wasCollected" resolve 
                                            // a bug about player take a coin twice
            Destroy(gameObject);
        }
    }
}
