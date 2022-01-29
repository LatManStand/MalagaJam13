using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public enum MixerType
    {
        Master,
        Ambient,
        Music,
        SFX
    };

    public MixerType mixerType;

    public void OnValueChange(float ammount)
    {
        MusicManager.instance.ChangeVolume(mixerType, ammount);
    }



}
