using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
public class CameraMovement : MonoBehaviour
{
    [Header("Moving Parameters")]
    [SerializeField] private float speed_mov;
    [Header("Zooming Parameters")]
    [SerializeField] private float zoom_speed;
    private float zoom;
    //obracanie sie kamery
    private Keyboard mov_actions;
    void Awake()
    {
        mov_actions = new Keyboard();
    }

    private void OnEnable()
    {
        mov_actions.Enable();
    }
    private void OnDisable()
    {
        mov_actions.Disable();
    }

    private void Update()
    {
        //Mov
        Vector2 mov = mov_actions.Movement.Move.ReadValue<Vector2>();

        Vector3 move = new Vector3(mov.x,0,mov.y);
        transform.Translate(move * Time.deltaTime * speed_mov);

        //Scro
        Vector2 scro = mov_actions.Movement.Zoom.ReadValue<Vector2>();
        //Scro + block zoom system
        float oldZoom = zoom;
        zoom += scro.y * zoom_speed * Time.deltaTime;
        zoom = Mathf.Clamp(zoom, 0, 4.5f); 
        float zoomChange = zoom - oldZoom;
        Camera.main.transform.localPosition += Camera.main.transform.localRotation * Vector3.forward * zoomChange;
        //Localposition zmieniajac to dana zmieniam pozycje kamery wzgledem riga nie świata
        //localrotation uzywam tutaj by poruszac kamere w kierunku w ktorym jest obrocona

        //tutaj skonczylem na zrobieniu poruszania sie kamery
    }
}
