using UnityEngine;  
using System.Collections;  
using ZXing; 
using ZXing.QrCode;  
using UnityEngine.UI;  

public class CreateQRCode : MonoBehaviour  
{   
	public Texture2D encoded;  
	public string Lastresult;  

	//public RawImage ima; 

	void Start()  
	{  
		encoded = new Texture2D(256, 256);  
		Lastresult = "http://www.google.com/ncr";  

		var textForEncoding = Lastresult;  
		if (textForEncoding != null)  
		{  
			var color32 = Encode(textForEncoding, encoded.width, encoded.height);  
			encoded.SetPixels32(color32);  
			encoded.Apply();  

			//ima.texture = encoded;  
		}  
	}  

	// for generate qrcode
	private static Color32[] Encode(string textForEncoding, int width, int height)  
	{  
		var writer = new BarcodeWriter  
		{  
			Format = BarcodeFormat.QR_CODE,  
			Options = new QrCodeEncodingOptions  
			{  
				Height = height,  
				Width = width  
			}  
		};  
		return writer.Write(textForEncoding);  
	}  

	void OnGUI()  
	{  
		GUI.DrawTexture(new Rect(100, 100, 256, 256), encoded);  
	}  
}  