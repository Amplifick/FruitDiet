using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public enum Sound
    {
        ClickOnUI,
        PickItem,
        PlayerDie,
        GuideTalkingStory,
        GuideExplainingTutorial,
    }

    public class SoundManager : MonoBehaviour
    {
        [System.Serializable]
        public class SoundAudioClip
        {
            public Sound sound;
            public AudioClip audioClip;
        }

        private Dictionary<Sound, float> soundTimerDictionary = new();

        [Header("Audio Settings")]
        public SoundAudioClip[] bankOfAudios;
        private GameObject oneShotAudioGameObject;
        private AudioSource oneShotAudioSource;

        private void Awake()
        {
            //soundTimerDictionary[Sound.whatEverSoundNeedsATimer] = 0f;
        }

        public void PlayOneShotAudio(AudioSource source, AudioClip clip)
        {
            source.PlayOneShot(clip);
        }

        public void PlaySoundOneShot(Sound sound)
        {
            if (CanPlaySound(sound))
            {
                if(oneShotAudioGameObject == null)
                {
                    oneShotAudioGameObject = new GameObject("One Shot Sound");
                    oneShotAudioSource = oneShotAudioGameObject.AddComponent<AudioSource>();
                    oneShotAudioGameObject.transform.SetParent(transform);
                }

                oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
            }

        }

        private bool CanPlaySound(Sound sound)
        {
            switch (sound)
            {
                default:
                    return true;
                    //case Sound.typeOfSound:
                    //    if (soundTimerDictionary.ContainsKey(sound))
                    //    {
                    //        float lastTimePlayed = soundTimerDictionary[sound];
                    //        float howOftenSoundWillBePlayed = .05f;
                    //        if(lastTimePlayed + howOftenSoundWillBePlayed < Time.deltaTime)
                    //        {
                    //            soundTimerDictionary[sound] = Time.deltaTime;
                    //            return true;
                    //        }
                    //        else
                    //        {
                    //            return false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        return true;
                    //    }
            }
        }

        private AudioClip GetAudioClip(Sound sound)
        {
            foreach (SoundAudioClip soundAudioClip in bankOfAudios)
            {
                if (soundAudioClip.sound == sound)
                {
                    return soundAudioClip.audioClip;
                }
            }
            Debug.LogError("Sound " + sound + "not found!");
            return null;
        }
    }
}

