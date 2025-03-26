using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class DrumsCollisionManager : MonoBehaviour
{
    public AudioClip defaultDrumSounds;
    public AudioSource audioSource;

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.1f))
        {
            if (hit.collider.CompareTag("Stick"))
            {
                PlayDrumSound(hit.collider.GetComponent<DrumStick>());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Stick"))
            PlayDrumSound(collision.gameObject.GetComponent<DrumStick>());

    }

    private void PlayDrumSound(DrumStick drumStick)
    {
        audioSource.clip = defaultDrumSounds;
        audioSource.Play();

        if(drumStick != null)
            drumStick.SendHapticImpulse();
    }
}
