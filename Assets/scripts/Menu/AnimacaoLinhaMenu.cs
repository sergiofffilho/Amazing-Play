using UnityEngine;
using System.Collections;

public class AnimacaoLinhaMenu : MonoBehaviour {
    public float scrollSpeed;
    private Vector2 savedOffset;
    public Renderer renderer;
    private float offset;

    void Start () {
        renderer = GetComponent<Renderer>();
        savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
    }

    void Update () {
		float x = Mathf.Repeat (Time.time * scrollSpeed , 2);
		Vector2 offset = new Vector2 (x, savedOffset.y);
        renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
    }
    
    void OnDisable () {
        renderer.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
    }
}
    
