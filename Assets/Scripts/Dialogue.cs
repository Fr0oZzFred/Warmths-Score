using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] List<string> dialogues;
    [SerializeField] List<float> duration;
    [SerializeField] float timeBetweenDialogue = 30;
    [SerializeField] GameObject bulle;
    [SerializeField] TextMeshProUGUI text;
    
    float time;
    int idx = -1;


    private void Start() {
        bulle.SetActive(false);
        StartCoroutine(ShowDialogue(0));
    }
    private void Update() {
        time += Time.deltaTime;
        if(timeBetweenDialogue < time) {
            time = 0;
            if (idx == WorldManager.Instance.GameProgression) return;
            switch (WorldManager.Instance.GameProgression) {
                case 0:
                    StartCoroutine(ShowDialogue(1));
                    break;
                case 1:
                    StartCoroutine(ShowDialogue(2));
                    break;
                case 2:
                    StartCoroutine(ShowDialogue(3));
                    break;
                case 3:
                    StartCoroutine(ShowDialogue(4));
                    break;
            }
            idx = WorldManager.Instance.GameProgression;
        }
    }
    IEnumerator ShowDialogue(int idx) {
        text.SetText(dialogues[idx]);
        bulle.SetActive(true);
        yield return new WaitForSecondsRealtime(duration[idx]);
        bulle.SetActive(false);
    }
}
