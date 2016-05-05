using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PixelateRenderTextureScript : MonoBehaviour {

	public bool increase = false;
	//public int startWidth = 256;
	//public int startHeight = 256;
	public Object camAsset;
	public Canvas canvas;

	private float lastTime;
	private float halfMultiplier = 0.5f;
	private float doubleMultiplier = 2.0f;
	private float multiplier;
	private GameObject image;
	private RenderTexture startTex;
	private Camera cam;
	private bool start = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - lastTime > 1.8 && start) {
			Debug.Log("Res Change");
			setNewRenderTexture();
			lastTime = Time.time;
		}
	}

	public void startEffect() {
		canvas.enabled = true;
		image = GameObject.Find("RawImage");
		GameObject o = (GameObject) GameObject.Instantiate(camAsset, Camera.main.transform.position,  Camera.main.transform.rotation);
		cam = o.GetComponent<Camera>();
		startTex = new RenderTexture((int) cam.pixelWidth, (int) cam.pixelHeight, 16);
		image.GetComponent<RawImage>().texture = startTex;
		cam.targetTexture = startTex;
		lastTime = Time.time;
		setIncreaseMultiplier();
		start = true;
	}

	void setNewRenderTexture() {
		int width = cam.targetTexture.width;
		int height = cam.targetTexture.height;
		if (width <= 0 || height <= 0) {
			return;
		}
		//cam.targetTexture.Release();
		startTex = new RenderTexture((int) (width * multiplier), (int) (height * multiplier), 16);
		startTex.filterMode = FilterMode.Point;
		cam.targetTexture = startTex;
		image.GetComponent<RawImage>().texture = startTex;
	}

	void setIncreaseMultiplier() {
		if (increase) {
			multiplier = doubleMultiplier;
		} else {
			multiplier = halfMultiplier;
		}
	}
}
