using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class DrumsCollisionManager : MonoBehaviour
{
    public AudioClip defaultDrumSounds;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Drum hit with : " + collision.gameObject.name);
        audioSource.clip = defaultDrumSounds;
        audioSource.Play();

        SendHapticFeedback();
    }

    void SendHapticFeedback()
    {
        // Définir l'intensité et la durée du retour haptique
        float intensity = 0.5f;
        float duration = 0.1f;

        // Envoyer le retour haptique à la manette droite
        var hapticDevice = InputSystem.GetDevice<XRController>(CommonUsages.RightHand);
        if (hapticDevice != null)
        {
            //hapticDevice.SendImpulse(0, intensity, duration);
        }
    }
}
