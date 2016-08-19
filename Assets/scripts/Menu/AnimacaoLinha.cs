using UnityEngine;
using System.Collections;

public class AnimacaoLinha : MonoBehaviour {
    
    public float scrollSpeed;
    private Vector2 savedOffset;
    public Renderer renderer;
    private float offset;

	ControladorPlayer controladorPlayer;

    void Start () {
        renderer = GetComponent<Renderer>();
        savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");

		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer> ();
    }

    void Update () {
		if (controladorPlayer.getIsAlive ()) {
			//float x = Mathf.Repeat (Time.time * scrollSpeed , 1);
			float x = Mathf.Repeat (Time.time * controladorPlayer.velocity.x * 0.1f, 2);
			float y = Mathf.Repeat (Time.time * controladorPlayer.velocity.y * 0.1f, 2);
			Vector2 offset = new Vector2 (x, y);
			renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
		} 
    }
    
    void OnDisable () {
        renderer.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
    }
        
}
    
