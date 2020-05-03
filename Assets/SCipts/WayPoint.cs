using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USED AS A DATA CLASS
public class WayPoint : MonoBehaviour
{
    //CONFIG PARAMS
    Color exploredColor = Color.blue;
    const int GRIDSIZE = 10;
    public bool isExplored = false; //CHECKED
    public WayPoint exploredFrom; //WHO found me?

    //GETTER METHOD ON A CONSTANT VALUE.
    public int GetGridSize()
    {
        return GRIDSIZE;
    }
    //GETTER METHOD * math error WE ORIGINALLY MULTIPLIED BY THE GRIDSIZE HERE, WHEN
    //IT SHOULD HAVE BEEN ON THE END SCRIPT.
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
                (Mathf.RoundToInt(transform.position.x / GRIDSIZE)),
                (Mathf.RoundToInt(transform.position.z / GRIDSIZE))
        );
    }
    //CHANGES TOPS TO INDICATE SEARCH.
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRender = transform.Find("Quad TOP").GetComponent<MeshRenderer>();
        topMeshRender.material.color = color;
    }
    //ONLY TO CHANGE COLOR ON EXPLORED
    private void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
        }
    }
    //SHOULD BE AUTOMATIC
    void OnMouseOver()
    {
        Debug.Log("MOUSE-OVER " + gameObject.name);
    }
}
