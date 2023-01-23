using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameStates {
        Boot,
        MainMenu,
        InGame,
        Pause
    }
    public GameStates CurrentGameState { get; private set; }
    public GameStates PreviousGameState { get; private set; }
    public static GameManager Instance { get; private set; }
    public delegate void GameStateChangeHandler(GameStates newState);
    public event GameStateChangeHandler OnGameStateChanged;

    [SerializeField] PlayerController player;
    public PlayerController Player { get; private set; }


    public Texture2D TongueCursor;
    public Texture2D NormalCursor;

    private void Awake() {
        if (!Instance) Instance = this;
        Player = player;
    }
    private void Start() {
        Cursor.SetCursor(NormalCursor, Vector2.zero, CursorMode.ForceSoftware);
        SetState(GameStates.MainMenu);
    }
    public void SetState(GameStates newState) {
        if (newState == CurrentGameState) return;
        PreviousGameState = CurrentGameState;
        CurrentGameState = newState;
        OnGameStateChanged?.Invoke(newState);
        switch (newState) {
            case GameStates.InGame:
                Player.enabled = true;
                Player.tongue.enabled = true;
                Player.dialogue.enabled = true;
                break;
            default:
                Player.enabled = false;
                Player.tongue.enabled = false;
                Player.dialogue.enabled = false;
                player.SetAnimToIdle();
                Cursor.SetCursor(NormalCursor, Vector2.zero, CursorMode.ForceSoftware);
                break;
        }
    }
    public void SetState(int newState) {
        SetState((GameStates)newState);
    }
    public void StartCinematic(float delay) {
        StartCoroutine(PlayCinematic(delay));
    }
    IEnumerator PlayCinematic(float delay) {
        yield return new WaitForSecondsRealtime(delay);
        SetState(GameStates.InGame);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
