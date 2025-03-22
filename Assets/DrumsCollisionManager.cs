using UnityEngine;

public class DrumsCollisionManager : MonoBehaviour
{
    public AudioClip defaultDrumSounds;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Drum hit with : " + collision.gameObject.name);
        audioSource.clip = defaultDrumSounds;
        audioSource.Play();
    }
}
