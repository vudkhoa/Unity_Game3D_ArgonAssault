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
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3.5f;
    // rawPos: vị trí thô. 
    void Update()
    {
        // float horizontalThrow = movement.ReadValue<Vector2>().x;
        // float verticalThrow = movement.ReadValue<Vector2>().y;
    
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
