using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

public class ProvinceSelector : MonoBehaviour
{
    [Inject] private SignalBus _signal;
    public LayerMask layer;
    Ray ray;
    private MouseActions mouse_actions;

    void Awake()
    {
        mouse_actions = new MouseActions();
    }
    private void OnEnable()
    {
        mouse_actions.Enable();
        mouse_actions.MouseAction.LeftButton.performed += LeftButtonMouse;
    }
    private void OnDisable()
    {
        mouse_actions.Disable();
        mouse_actions.MouseAction.LeftButton.performed -= LeftButtonMouse;
    }
    private void LeftButtonMouse(InputAction.CallbackContext context)
    {
        if (TryRaycast(out RaycastHit hit))
        {
            _signal.Fire<ProvinceSelectEvent>(new ProvinceSelectEvent(hit.collider.gameObject.GetComponent<Province>()));
        }
    }
    private bool TryRaycast(out RaycastHit hit)
    {
        Vector2 mouse_input = mouse_actions.MouseAction.Position.ReadValue<Vector2>();
        Vector3 mouse_pos = new Vector3(mouse_input.x, mouse_input.y, 0); 
        Ray ray = Camera.main.ScreenPointToRay(mouse_pos);
        return Physics.Raycast(ray, out hit, Mathf.Infinity, layer);
    }
}
