using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
     public Camera m_camera;
    public GameObject brush;
     [SerializeField] private Transform _tip;
     private RaycastHit _touch;
     private float _tipHeight;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;



    void Start(){
        _tipHeight = _tip.localScale.y;
    }
    private void Update()
    {
        Drawing();
    }

    void Drawing() 
    {
        if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight))
        {
            CreateBrush();
        }
        else if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight))
        {
            PointToMousePos();
        }
        else 
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush() 
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        //because you gotta have 2 points to start a line renderer, 
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos) 
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos() 
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos) 
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

}
