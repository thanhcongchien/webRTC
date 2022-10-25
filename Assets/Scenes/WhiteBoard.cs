using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WhiteBoard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize  = new Vector2(2048, 2048);
    public Button clearButton;
    private Color _colors;
    // Start is called before the first frame update
    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
        _colors = r.material.color;
        Debug.Log("Start: " + _colors);
    }


    public void Clear(){
        texture.SetPixels(0,0,(int)textureSize.x,(int)textureSize.y, Enumerable.Repeat(_colors ,(int)textureSize.x * (int)textureSize.y).ToArray());
        texture.Apply();
    }
}
