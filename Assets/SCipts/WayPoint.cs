using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    //CONFIG PARAMS
    const int GRIDSIZE = 10;
    Vector2Int gridPos;  // a 2 DIM VARIABLE

    //GETTER METHOD
    public int GetGridSize()
    {
        return GRIDSIZE;
    }
    //GETTER METHOD * math error
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
                (Mathf.RoundToInt(transform.position.x / GRIDSIZE)),
                (Mathf.RoundToInt(transform.position.z / GRIDSIZE))
        );
    }
    //
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRender = transform.Find("Quad TOP").GetComponent<MeshRenderer>();
        topMeshRender.material.color = color;
    }
}
