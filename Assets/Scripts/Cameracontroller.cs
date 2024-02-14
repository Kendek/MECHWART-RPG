using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Cameracontroller : MonoBehaviour
{

    public Camera _cam;
    public Tilemap TM;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculatSize();
        var (center, size) = CalculatSize();
        _cam.transform.position = center;
        _cam.orthographicSize = size;   
    }
    private (Vector3 center, float size) CalculatSize()
    {
        
        TM.CompressBounds();

        var bounds = TM.localBounds;

        var vertical = bounds.size.y;
        var horizontal = bounds.size.x * _cam.pixelHeight / _cam.pixelWidth;

        var size = Mathf.Max(horizontal, vertical) * 0.5f;
        var center = bounds.center + new Vector3(0,0,-10);
        return (center, size);
        
    }
    
}