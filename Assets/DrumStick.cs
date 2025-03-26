using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class DrumStick : MonoBehaviour
{
    [SerializeField] private HapticImpulsePlayer _hapticImpulsePlayer;
    [SerializeField] private float _amplitude = 0.5f;
    [SerializeField] private float _duration = 0.2f;

    public void SendHapticImpulse()
    {
        _hapticImpulsePlayer.SendHapticImpulse(_amplitude, _duration);
    }
}
