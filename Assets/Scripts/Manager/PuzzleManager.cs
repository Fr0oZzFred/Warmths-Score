using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }
    [SerializeField] List<UnityEvent> onTaskUpdate;
    [SerializeField] UnityEvent onTaskDone;

    //int taskDone;
    //
    //public void UpdateTask(int index) {
    //    if (index < -1) throw new System.Exception("Index is -1");
    //    if (index > onTaskUpdate.Count) throw new System.Exception("Index is greater than nb of task");
    //    onTaskUpdate[index].Invoke();
    //    taskDone++;
    //    if (taskDone == onTaskUpdate.Count) onTaskDone.Invoke();
    //}
    private void Awake() {
        if (!Instance) Instance = this;
    }
    public void UnWearPlayer() {
        GameManager.Instance.Player.UnWear();
    }
    public void TriggerEvent() {
        if (GameManager.Instance.Player.WearingItem <= -1) return;
        onTaskUpdate[GameManager.Instance.Player.WearingItem].Invoke();
    }
}
