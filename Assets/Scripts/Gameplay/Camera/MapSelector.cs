using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MapSelector : MonoBehaviour
{
    [Inject] private SignalBus _signal;
    [SerializeField] private LayerMask province_layer;
    [SerializeField] private LayerMask army_layer;
    [SerializeField] private BoxSelector box_selector;
    private MouseActions mouse_actions;

    // Click Mouse Selection
    private bool selected_province;
    private List<UnitArmy> selected_army = new List<UnitArmy>();
    // Checking Selecting or Click
    private bool _isHolding;
    private bool _isSelecting;
    //Selecting Value
    private Vector2 start_selecting_pos;
    void Awake()
    {
        mouse_actions = new MouseActions();
    }
    private void OnEnable()
    {
        mouse_actions.Enable();
        mouse_actions.MouseAction.LeftButton.started += OnMouseClickStart;
        mouse_actions.MouseAction.LeftButton.canceled += OnMouseClickEnd;
        //Events
        box_selector.SelectionFinished += OnBoxSelectionFinished;
        _signal.Subscribe<UnitsArmySelectEvent>(OnArmySelected);
    }
    private void OnDisable()
    {
        mouse_actions.MouseAction.LeftButton.started -= OnMouseClickStart;
        mouse_actions.MouseAction.LeftButton.canceled -= OnMouseClickEnd;
        mouse_actions.Disable();
        //Events
        box_selector.SelectionFinished -= OnBoxSelectionFinished;
        _signal.TryUnsubscribe<UnitsArmySelectEvent>(OnArmySelected);
    }
    private void LeftButtonMouseClick()
    {
        if (TryRaycast(out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Province>(out var Province))
            {
                SelectProvince(Province);
            }
            else if (hit.collider.TryGetComponent<UnitArmy>(out var Army))
            {
                SelectArmy(Army);
            }
        }
    }
    private bool TryRaycast(out RaycastHit hit)
    {
        Vector2 mouse_input = mouse_actions.MouseAction.Position.ReadValue<Vector2>();
        Vector3 mouse_pos = new Vector3(mouse_input.x, mouse_input.y, 0); 
        Ray ray = Camera.main.ScreenPointToRay(mouse_pos);

        LayerMask selectableLayers = province_layer | army_layer;

        return Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayers);
    }

    private void SelectProvince(Province province)
    {
        if (selected_army.Count > 0)
        {
            UnSelectArmy();
        }

        _signal.Fire<ProvinceSelectEvent>(new ProvinceSelectEvent(province));
        selected_province = true;
    }
    private void SelectArmy(UnitArmy Army)
    {
        if (selected_province)
        {
            UnSelectProvince();
        }
        else if (selected_army.Count > 0)
        {
            UnSelectArmy();
        }
        selected_army.Add(Army);
        _signal.Fire<UnitsArmySelectEvent>(new UnitsArmySelectEvent(selected_army));
    }
    private void SelectMultiplieArmy(List<Collider> selected_objects)
    {
        if (selected_army.Count > 0)
        {
            UnSelectArmy();
        }
        if (selected_province)
        {
            UnSelectProvince();
        }

        foreach (var item in selected_objects)
        {
            if (item.gameObject.GetComponent<UnitArmy>() != null)
            {
                UnitArmy unit = item.gameObject.GetComponent<UnitArmy>();
                selected_army.Add(unit);
            }
            else
            {
                Debug.Log("Error: item is not Unit!");
            }
        }
        if (selected_army.Count > 0)
        {
            _signal.Fire<UnitsArmySelectEvent>(new UnitsArmySelectEvent(selected_army));
        }
    }
    private void UnSelectArmy()
    {
        _signal.Fire<UnitsArmyClearEvent>();
        selected_army.Clear();
    }
    private void UnSelectProvince()
    {
        _signal.Fire<ProvinceSelectClearEvent>();
        selected_province = false;
    }


    private void OnArmySelected(UnitsArmySelectEvent data)
    {
        foreach (var item in data.units)
        {
            item.SelectArmy();
        }
    }
    //Checking Selecting or Clicking
    private void Update()
    {
        if (_isHolding)
        {
            Vector2 mouse_input = mouse_actions.MouseAction.Position.ReadValue<Vector2>();
            if (Vector2.Distance(start_selecting_pos,mouse_input) > 40f)
            {
                _isSelecting = true;
                _isHolding = false;
            }
        }
        if (_isSelecting)
        {
            Vector2 mouse_input = mouse_actions.MouseAction.Position.ReadValue<Vector2>();
            box_selector.UpdateSelection(mouse_input);
        }
    }
    private void OnMouseClickStart(InputAction.CallbackContext context)
    {
        _isHolding = true;
        start_selecting_pos = mouse_actions.MouseAction.Position.ReadValue<Vector2>();
        box_selector.StartSelection(start_selecting_pos);
    }
    private void OnMouseClickEnd(InputAction.CallbackContext context)
    {
        if (_isSelecting == false)
        {
            LeftButtonMouseClick();
            _isHolding = false;
        }
        else
        {
            box_selector.EndSelection();
            _isSelecting = false;
        }
    }

    private void OnBoxSelectionFinished(List<Collider> colliders)
    {
        SelectMultiplieArmy(colliders);
    }
}
