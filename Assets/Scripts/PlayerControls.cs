using UnityEngine;
// using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // [SerializeField] InputAction movement; 

    // void OnEnable() {
    //     movement.Enable();        
    // }

    // void OnDisable() {
    //     movement.Disable();
    // }

    // Update is called once per frame

    [SerializeField] float controlSpeed = 10f;
    void Update()
    {
        // float horizontalThrow = movement.ReadValue<Vector2>().x;
        // float verticalThrow = movement.ReadValue<Vector2>().y;
    
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);

    }
}
