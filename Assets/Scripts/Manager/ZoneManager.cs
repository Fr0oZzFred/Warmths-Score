using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ZoneManager : MonoBehaviour {

    public static ZoneManager Instance { get; private set; }
    [SerializeField] bool debug = true;
    [SerializeField] Transform center;
    //[SerializeField] [Min(0.01f)]           float radius = 3.0f;
    //[SerializeField] [Min(0.00f)]           float edgeWidth = 0.01f;
    //[SerializeField] [Min(0.01f)]           float noiseScale = 1f;
    //[SerializeField] [Range(0.01f, 1f)]     float radiusNoiseOffset = 0.04f;

    [SerializeField] Zone debugZone;

    [System.Serializable]
    public struct Zone {
        public float radius;
        public float edgeWidth;
        public float noiseScale;
        public float radiusNoiseOffset;
    }


    public List<Zone> presets;

    public int idx = 0;

    [SerializeField] float delay = 0.005f;
    float radius;
    public float Radius { get { return presets[idx].radius; } }
    private void Awake() {
        if (!Instance) Instance = this;
        radius = presets[0].radius;
    }
    void Update() {
        Shader.SetGlobalVector("_Position", center.position);
        Shader.SetGlobalFloat("_Radius", radius);
        Shader.SetGlobalFloat("_EdgeWidth", presets[idx].edgeWidth);
        Shader.SetGlobalFloat("_NoiseScale", presets[idx].noiseScale);
        Shader.SetGlobalFloat("_RadiusNoiseOffset", presets[idx].radiusNoiseOffset);
        
        if (!debug) return;

        Shader.SetGlobalFloat("_Radius", debugZone.radius);
        Shader.SetGlobalFloat("_EdgeWidth", debugZone.edgeWidth);
        Shader.SetGlobalFloat("_NoiseScale", debugZone.noiseScale);
        Shader.SetGlobalFloat("_RadiusNoiseOffset", debugZone.radiusNoiseOffset);
    }
    public void SetIndex(int index) {
        idx = index;
    }
    public void IncrIdx() {
        idx++;
        if (idx >= presets.Count) return;
        if(idx == (presets.Count - 1)) {
            StartCoroutine(LerpSlow());
            return;
        }
        StartCoroutine(Lerp());
    }

    IEnumerator Lerp() {
        for (float t = 0; t <= 1.0f; t += 0.01f) {
            radius = Mathf.Lerp(presets[idx - 1].radius, presets[idx].radius, t);
            yield return new WaitForSecondsRealtime(delay);
        }
    }
    IEnumerator LerpSlow() {
        for (float t = 0; t <= 1.0f; t += 0.0001f) {
            radius = Mathf.Lerp(presets[idx - 1].radius, presets[idx].radius, t);
            yield return new WaitForSecondsRealtime(delay);
        }
    }
}
