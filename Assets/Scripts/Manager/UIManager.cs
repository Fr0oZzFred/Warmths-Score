using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance { get; private set; }

    [SerializeField] List<GameObject> HUDstate;

    private void Awake() {
        if (!Instance) Instance = this;
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        foreach (var e in HUDstate) e.SetActive(false);
    }

    void OnGameStateChanged(GameManager.GameStates newState) {
        HUDstate[(int)GameManager.Instance.CurrentGameState].SetActive(true);
        HUDstate[(int)GameManager.Instance.PreviousGameState].SetActive(false);
    }
}