using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;            // assign in prefab
    private AudioSource audioSource;
    private bool collected = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f;    // 3D
        audioSource.dopplerLevel = 0f;
        // tune rolloff and min/max distance in Inspector or here:
        // audioSource.minDistance = 1f;
        // audioSource.maxDistance = 20f;
    }

    public void Collect()
    {
        if (collected) return;
        collected = true;

        // Hide visuals and disable collider immediately
        var rend = GetComponent<Renderer>();
        if (rend != null) rend.enabled = false;

        var col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        // Play sound at this coin's position
        if (coinSound != null)
            audioSource.PlayOneShot(coinSound);

        // Destroy the coin object after the clip finishes (fallback 0.1s)
        float destroyDelay = (coinSound != null) ? coinSound.length : 0.1f;
        Destroy(gameObject, destroyDelay);
    }
}
