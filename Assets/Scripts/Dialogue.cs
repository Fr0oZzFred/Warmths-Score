using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] List<string> dialogues;
    [SerializeField] List<bool> dialoguesDone;
    [SerializeField] GameObject bulle;
    [SerializeField] TextMeshProUGUI text;


    private void Start() {
        foreach (var item in dialogues) {
            dialoguesDone.Add(false);
        }
        bulle.SetActive(false);
        ShowDialogue(0);
    }
    private void Update() {
        //time += Time.deltaTime;
        //if(timeBetweenDialogue < time) {
        //    time = 0;
        //    if (idx == WorldManager.Instance.GameProgression) return;
        //    switch (WorldManager.Instance.GameProgression) {
        //        case 0:
        //            StartCoroutine(ShowDialogueWithDelay(1));
        //            break;
        //        case 1:
        //            StartCoroutine(ShowDialogueWithDelay(2));
        //            break;
        //        case 2:
        //            StartCoroutine(ShowDialogueWithDelay(3));
        //            break;
        //        case 3:
        //            StartCoroutine(ShowDialogueWithDelay(4));
        //            break;
        //    }
        //    idx = WorldManager.Instance.GameProgression;
        //}
    }
    IEnumerator ShowDialogueWithDelay(int idx, float delay) {
        yield return new WaitForSecondsRealtime(delay);
        text.SetText(dialogues[idx]);
        dialoguesDone[idx] = true;
        bulle.SetActive(true);
    }

    public void ShowDialogue(int idx) {
        if (dialoguesDone[idx]) return;
        switch (idx) {
            case 0:
                StartCoroutine(ShowDialogueWithDelay(3, 60.0f));
                break;
            case 1:
                if (WorldManager.Instance.spawnPuzzleState != 0) return;
                StartCoroutine(ShowDialogueWithDelay(2, 60.0f));
            break;
            case 5:
                StartCoroutine(ShowDialogueWithDelay(6, 160.0f));
            break;
            case 8:
                if (WorldManager.Instance.foretPuzzleState != 0) return;
                StartCoroutine(ShowDialogueWithDelay(9, 60.0f));
            break;
        }
        text.SetText(dialogues[idx]);
        dialoguesDone[idx] = true;
        bulle.SetActive(true);
    }
}
