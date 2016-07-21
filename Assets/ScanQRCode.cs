using UnityEngine;
using System.Collections;
using ZXing;
using UnityEngine.UI;

public class ScanQRCode : MonoBehaviour 
{
	private WebCamTexture webCamTexture;
	private string resultText;

	// Use this for initialization
	void Start () 
	{
		webCamTexture = new WebCamTexture (640, 480);
		WebCamDevice[] devices = WebCamTexture.devices;
		webCamTexture.deviceName = devices[0].name;
		webCamTexture.Play ();

		InvokeRepeating ("Scan", 1f, 1f);
	}

	void OnGUI()  
	{  
		GUI.DrawTexture(new Rect(0, 0, 640, 480), webCamTexture, ScaleMode.ScaleToFit);  
	} 

	private void Scan()
	{
		if (string.IsNullOrEmpty(resultText)) 
		{
			if (webCamTexture != null && webCamTexture.width > 100) 
			{
				resultText = Decode(webCamTexture.GetPixels32 (), webCamTexture.width, webCamTexture.height);
				Debug.Log (resultText);
			}
		}
	}

	public string Decode(Color32[] colors, int width, int height)
	{
		BarcodeReader reader = new BarcodeReader ();
		var result = reader.Decode (colors, width, height);
		if (result != null) 
		{
			return result.Text;
		}
		return null;
	}
}
