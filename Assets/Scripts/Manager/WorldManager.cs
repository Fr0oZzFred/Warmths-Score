using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldManager : MonoBehaviour {

    [SerializeField] List<UnityEvent> onPuzzleCompleted;
    [SerializeField] int taskToDoPuzzleSpawn = 3;
    [SerializeField] int taskToDoPuzzleVille1 = 1;
    [SerializeField] int taskToDoPuzzleForet = 3;

    int spawnPuzzleState = 0;
    int ville1PuzzleState = 0;
    int foretPuzzleState = 0;

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
    }
    public void IncrSpawnPuzzleState() {
        spawnPuzzleState++;
        if (spawnPuzzleState >= taskToDoPuzzleSpawn) {
            onPuzzleCompleted[0].Invoke();
            IncrProgression();
        }
    }
    public void IncrVille1PuzzleState() {
        ville1PuzzleState++;
        if (ville1PuzzleState >= taskToDoPuzzleVille1) {
            onPuzzleCompleted[1].Invoke();
            IncrProgression();
        }
    }
    public void IncrForetPuzzleState() {
        foretPuzzleState++;
        if (foretPuzzleState >= taskToDoPuzzleForet) {
            onPuzzleCompleted[2].Invoke();
            IncrProgression();
        }
    }
}
