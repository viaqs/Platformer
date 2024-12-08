using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Look : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        var mousePos = Input.mousePosition;
        var WorldPos = cam.ScreenToWorldPoint(mousePos);
        var dir =  (WorldPos - transform.position).normalized;
        var angle =Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
