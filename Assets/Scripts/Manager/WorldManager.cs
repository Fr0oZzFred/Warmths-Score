using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldManager : MonoBehaviour {

    [SerializeField] List<UnityEvent> events;

    public static WorldManager Instance { get; private set; }

    public int GameProgression { get; private set; }
    private void Awake() {
        if (!Instance) Instance = this;
    }

    public void SetGameProgression(int nuProgression) {
        if (nuProgression <= GameProgression) return;
        GameProgression = nuProgression;
        OnProgressionChange();
    }
    public void IncrProgression() {
        GameProgression++;
        OnProgressionChange();
    }

    void OnProgressionChange() {
        switch (GameProgression) {
            case 3:
                events[0].Invoke();
            break;
            case 4:
                events[1].Invoke();
            break;
        }
    }
}
