using UnityEngine;

public class ZoneManager : MonoBehaviour {

    public static ZoneManager Instance { get; private set; }
    [SerializeField] Transform center;
    [SerializeField] [Min(0.01f)]           float radius = 3.0f;
    [SerializeField] [Min(0.00f)]           float edgeWidth = 0.01f;
    [SerializeField] [Min(0.01f)]           float noiseScale = .4f;
    [SerializeField] [Range(0.01f, 1f)]     float radiusNoiseOffset = 0.01f;
    public float Radius { get { return radius; } }
    private void Awake() {
        if (!Instance) Instance = this;
    }
    void Update() {
        Shader.SetGlobalVector("_Position", center.position);
        Shader.SetGlobalFloat("_Radius", radius);
        Shader.SetGlobalFloat("_EdgeWidth", edgeWidth);
        Shader.SetGlobalFloat("_NoiseScale", noiseScale);
        Shader.SetGlobalFloat("_RadiusNoiseOffset", radiusNoiseOffset);
    }

    public void SetRadius(float value) {
        radius = value;
    }
}
