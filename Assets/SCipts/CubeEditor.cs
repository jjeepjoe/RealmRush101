using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //will allow scripts to execute in the editor
[SelectionBase] //this will make the selection in editor grab base only.
[RequireComponent(typeof(WayPoint))] // will make the component connection by adding it.
public class CubeEditor : MonoBehaviour
{
    //CONFIG PARAMS
    TextMesh textMesh;
    //CASHE
    WayPoint wayPoint;

    //AS SOON AS ALIVE MAKE CONNECTION, THE SCRIPT WILL FIND THE POINT.
    private void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
        if(wayPoint == null)
        {
            Debug.LogWarning("[CubeEditor.cs] waypoint not connected");
        }
    }
    //WE DID NOT USE START BECAUSE THE SCRIPT EXECUTES FOR EDIT MODE IN UPDATE ONLY.
    void Update()
    {
        SnapToGrid();
        UpdateTheLabel();
    }
    //ORRIGINALLY WE DID THE MATH BEFOR HERE, BUT IT WASN'T APPROPIATE, IT SHOULD BE COMPLETED HERE.
    private void SnapToGrid()
    {
        int gridSize = wayPoint.GetGridSize();
        //SETTING POSITION FROM THE WAYPOINT SCRIPT USING 2 DIM VARIABLE X/Y   
        transform.position = new Vector3(
            wayPoint.GetGridPos().x * gridSize, 
            0, 
            wayPoint.GetGridPos().y * gridSize
        );
    }
    //WE NEED TO GET THE INFORMATION FROM THE 2 DIM VARIABLE.
    private void UpdateTheLabel()
    {
        Vector2Int gridPos = wayPoint.GetGridPos();
        //WE WILL USE THE POSITION AS THE NAME OF THE OBJECT.
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x + "," + gridPos.y;
        textMesh.text = labelText;
        gameObject.name = "MOJO-Cube " + labelText;
    }
}
