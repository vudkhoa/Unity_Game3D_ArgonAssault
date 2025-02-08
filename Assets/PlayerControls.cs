using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] InputAction movement; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable() {
        movement.Enable();        
    }

    void OnDisable() {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;
        
        // float horizontalThrow = Input.GetAxis("Horizontal");
        Debug.Log(horizontalThrow);

        // float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(verticalThrow);
    }
}
