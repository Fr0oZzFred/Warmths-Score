using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameStates {
        Boot,
        MainMenu,
        InGame
    }
    public GameStates CurrentGameState { get; private set; }
    public GameStates PreviousGameState { get; private set; }
    public static GameManager Instance { get; private set; }
    public delegate void GameStateChangeHandler(GameStates newState);
    public event GameStateChangeHandler OnGameStateChanged;

    [SerializeField] PlayerController player;
    public PlayerController Player { get; private set; }
    private void Awake() {
        if (!Instance) Instance = this;
        Player = player;
    }
    private void Start() {
        SetState(GameStates.MainMenu);
    }
    public void SetState(GameStates newState) {
        if (newState == CurrentGameState) return;
        PreviousGameState = CurrentGameState;
        CurrentGameState = newState;
        OnGameStateChanged?.Invoke(newState);
    }
    public void SetState(int newState) {
        if ((GameStates)newState == CurrentGameState) return;
        PreviousGameState = CurrentGameState;
        CurrentGameState = (GameStates)newState;
        OnGameStateChanged?.Invoke((GameStates)newState);
    }
}
