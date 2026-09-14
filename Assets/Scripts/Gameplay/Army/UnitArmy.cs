using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class UnitArmy : MonoBehaviour
{
    private Province actual_province;
    [SerializeField] private SpriteRenderer visual_shield;
    [SerializeField] private SpriteRenderer nation_symbol;
    [SerializeField] private TMP_Text amount_army;
    [SerializeField] private List<UnitType> units = new List<UnitType>();


    //Mov fun
    private MouseActions mouse_actions;
    private bool isUnitSelected = false;
    private Vector3 position_to_move;
    private Coroutine MovingCoroutine;
    private float t;
    //
    void Awake()
    {
        mouse_actions = new MouseActions();
    }
    private void OnEnable()
    {
        mouse_actions.Enable();
        mouse_actions.MouseAction.RightButton.performed += SetNewPositionToMove;
    }
    private void OnDisable()
    {
        mouse_actions.MouseAction.RightButton.performed -= SetNewPositionToMove;
    }
    public void InitUnit(Province province) //Init Province Unit after created
    {
        actual_province = province;
        nation_symbol.sprite = actual_province.owner_province.Data.NationOwnerFlag;
        //
        int amountGarrison = 0;
        foreach (var item in actual_province.garrison.army_garrison)//Checking amount garrison for unit to set TMP text
        {
            amountGarrison += item.amount;
        }
        amount_army.text = amountGarrison.ToString();
        // set list of units
        foreach (var unit in province.garrison.army_garrison)
        {
            units.Add(unit);
        }
    }

    public void SelectArmy()
    {
        visual_shield.color = Color.red;
        isUnitSelected = true;
    }
    public void UnSelectArmy()
    {
        visual_shield.color = Color.white;
        isUnitSelected = false;
    }
    private void SetNewPositionToMove(InputAction.CallbackContext context)
    {
        if (isUnitSelected)
        {
            Vector2 mousePos = mouse_actions.MouseAction.Position.ReadValue<Vector2>();

            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                position_to_move = hit.point;
            }
            //
            if (MovingCoroutine != null)
            {
                t = 0f;
                StopCoroutine(MovingCoroutine);
            }
            MovingCoroutine = StartCoroutine(MovingToPos());
        }
    }
    private IEnumerator MovingToPos()
    {
        while (t < 1f)
        {
            t += 0.001f * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, position_to_move, t);
            yield return null; //yield musi byc w srodku while aby co kazda klatek wykonywal sie lerp
        }
    }
}
