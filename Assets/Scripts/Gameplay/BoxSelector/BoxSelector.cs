using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelector : MonoBehaviour
{
    public event Action<List<GameObject>> SelectionFinished;
    [SerializeField] private RectTransform selection_panel;
    [SerializeField] private LayerMask layer_selecting;
    private List<GameObject> selected_objects = new List<GameObject>();
    private Vector2 start_position;
    private Vector2 mouse_position;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    //Setting start position for box selector
    public void StartSelection(Vector2 mousePos)
    {
        start_position = mousePos;
    }
    //Moving Box on moving Cursor
    public void UpdateSelection(Vector2 mousePos)
    {
        if (!selection_panel.gameObject.activeInHierarchy)
        {
            selection_panel.gameObject.SetActive(true);
        }

        mouse_position = mousePos;

        Vector2 size = mousePos - start_position;
        //sizeDelta odleglosc miedzy punktami
        selection_panel.sizeDelta = new Vector2(Mathf.Abs(size.x), Mathf.Abs(size.y));

        minX = Mathf.Min(start_position.x, mousePos.x);
        maxX = Mathf.Max(start_position.x, mousePos.x);
        minY = Mathf.Min(start_position.y, mousePos.y);
        maxY = Mathf.Max(start_position.y, mousePos.y);

        selection_panel.position = new Vector2(minX,maxY); //lewy gorny naroznik 
    }
    public void EndSelection()
    {
        //Creating Detecting inside Box Selector
        Ray ray1 = Camera.main.ScreenPointToRay(new Vector3(start_position.x,start_position.y,0));
        Ray ray2 = Camera.main.ScreenPointToRay(new Vector3(mouse_position.x, mouse_position.y, 0));
        RaycastHit StartHit;
        RaycastHit EndHit;
        Physics.Raycast(ray1,out StartHit,Mathf.Infinity);
        Physics.Raycast(ray2, out EndHit, Mathf.Infinity);
        Vector3 centerBox = (StartHit.point + EndHit.point) / 2;
        Vector3 half_extents = new Vector3(Mathf.Abs(EndHit.point.x - StartHit.point.x), 1, Mathf.Abs(EndHit.point.z - StartHit.point.z)); //Box need to have Y > 0 and x,z cant be -
        Collider[] objects = Physics.OverlapBox(centerBox, half_extents, Quaternion.identity,layer_selecting);
        foreach (var item in objects)
        {
            Debug.Log(item.name);
        }
        selection_panel.gameObject.SetActive(false);
    }
}
