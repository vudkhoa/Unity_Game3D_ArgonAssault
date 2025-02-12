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

    [SerializeField] float controlSpeed = 30f;
    [SerializeField] float xRange = 4f;
    [SerializeField] float yRange = 4f;

    // Đặt âm dương vì chiều trong tọa độ. 
    // là một hệ số tự đặt để điều chỉnh mức độ ảnh hưởng của vị trí y (transform.localPosition.y) đến pitch (góc nghiêng).
    // -1 sẽ đưa về bằng phảng nếu không nhấn lên xuống dù ở vị trí nào.
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float positionYawFactor = 4f;

    // là một hệ số tự đặt để điều chỉnh mức độ ảnh hưởng của điều khiển yThrow (input từ người chơi) đến pitch (góc nghiêng).
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float controlRollFactor = -40f;
    float xThrow, yThrow;
    // rawPos: vị trí thô.
     
    void Update() {
        ProcessTranslation();
        ProcessRotation(); 
    }

    void ProcessRotation() {
        // transform.localPosition.y: vì khi điêu khiển lên trên or xuống thì máy bay mới ngẩn or cúi.
        // Bình thường = 0 thì không ngẩng cũng không cúi. 
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pichDueToControlThrow = yThrow * controlPitchFactor;

        // cả hai vì khi bay lên thường ngẩng rất mạnh
        float pitch = pitchDueToPosition + pichDueToControlThrow;
        // ảnh hưởng position thôi, vì quay nghiêng khi bay sang hai bên sẽ do roll đảm nhận.
        float yaw = transform.localPosition.x * positionYawFactor;
        // ảnh hưởng control thôi, vì vị trí có yaw và pitch đảm nhận.
        // xThrow: vì quay tàu hay không do sang bên nào
        float roll = xThrow * controlRollFactor; 
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation() {
        // float horizontalThrow = movement.ReadValue<Vector2>().x;
        // float verticalThrow = movement.ReadValue<Vector2>().y;
    
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
