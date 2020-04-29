using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //will allow scripts to execute in the editor
[SelectionBase] //this will make the selection in editor grab base only.
public class CubeEditor : MonoBehaviour
{
    [Header("Cube settings")]
    [Range(1f, 20f)][SerializeField] float gridSize = 10f;
    //
    TextMesh textMesh;
    //WE DID NOT USE START BECAUSE THE SCRIPT EXECUTES FOR EDIT MODE IN UPDATE ONLY.
    void Update()
    {
        Debug.Log("Editor causes this Update");
        textMesh = GetComponentInChildren<TextMesh>();
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;

        transform.position = new Vector3(snapPos.x, 0, snapPos.z);
    }
}
