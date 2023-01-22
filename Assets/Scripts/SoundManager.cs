using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> audios;
    public static SoundManager Instance { get; private set; }

    private void Awake() {
        if (!Instance) Instance = this;
    }
    int idx = -1;

    public void AddInstrument() {
        audios[++idx].time = audios[0].time;
        audios[idx].Play();
    }
}
