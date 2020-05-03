using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USED AS A DATA CLASS
public class WayPoint : MonoBehaviour
{
    //CONFIG PARAMS
    //Color exploredColor = Color.blue;
    const int GRIDSIZE = 10;
    public bool isExplored = false;
    public bool isPlaceable = true;
    public WayPoint exploredFrom;
    [SerializeField] GameObject defenderTower;
    [SerializeField] Transform defenderContainer;
    Vector2Int gridPos; //?

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
    //SHOULD BE AUTOMATIC UNITY MWETHON WHEN SCRIPT FILES IS ATTACHED TO A COLLIDER.
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                Debug.Log("MOUSE-CLICK " + gameObject.name);
                GameObject temp_GO = Instantiate(defenderTower, gameObject.transform.position,
                                            Quaternion.identity);
                temp_GO.transform.SetParent(defenderContainer);
                isPlaceable = false;
            }
            else
            {
                Debug.Log("CAN NOT PLACE HERE.");
            }
        }        
    }
    ////CHANGES TOPS TO INDICATE SEARCH.
    //public void SetTopColor(Color color)
    //{
    //    MeshRenderer topMeshRender = transform.Find("Quad TOP").GetComponent<MeshRenderer>();
    //    topMeshRender.material.color = color;
    //}
    //ONLY TO CHANGE COLOR ON EXPLORED
    //private void Update()
    //{
    //    if (isExplored)
    //    {
    //        SetTopColor(exploredColor);
    //    }
    //}

}
