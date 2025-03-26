using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class DrumsController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float scaleSpeed = 0.1f;
    public float rotationSpeed = 50.0f;

    private InputAction moveAction;
    private InputAction scaleUpAction;
    private InputAction scaleDownAction;
    private InputAction rotateAction;

    void Start()
    {
        // Configurer les actions d'entrée
        var actionMap = new InputActionMap("DrumsControls");

        moveAction = actionMap.AddAction("Move", binding: "<XRController>{LeftHand}/thumbstick");
        scaleUpAction = actionMap.AddAction("ScaleUp", binding: "<XRController>{LeftHand}/secondarybutton"); // Y button
        scaleDownAction = actionMap.AddAction("ScaleDown", binding: "<XRController>{LeftHand}/primarybutton"); // X button
        rotateAction = actionMap.AddAction("Rotate", binding: "<XRController>{RightHand}/thumbstick/x");

        actionMap.Enable();
    }

    void Update()
    {
        // Récupérer les entrées des sticks analogiques des manettes Oculus
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        bool scaleUpInput = scaleUpAction.ReadValue<float>() > 0.5f;
        bool scaleDownInput = scaleDownAction.ReadValue<float>() > 0.5f;
        float rotateInput = rotateAction.ReadValue<float>();

        Debug.Log("Move: " + moveInput + " ScaleUp: " + scaleUpInput + " ScaleDown: " + scaleDownInput + " Rotate: " + rotateInput);

        MoveObject(moveInput);

        ScaleObject(scaleUpInput, scaleDownInput);

        RotateObject(rotateInput);
    }

    public void MoveObject(Vector2 moveInput)
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0.0f, moveInput.y);
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Ignore vertical of camera
        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 finalMoveDirection = (cameraForward * moveDirection.z + cameraRight * moveDirection.x).normalized;

        transform.Translate(finalMoveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    public void ScaleObject(bool scaleUpInput, bool scaleDownInput)
    {
        float scaleChange = 0;
        if (scaleUpInput)
        {
            scaleChange = scaleSpeed * Time.deltaTime;
        }
        else if (scaleDownInput)
        {
            scaleChange = -scaleSpeed * Time.deltaTime;
        }
        transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);
    }

    public void RotateObject(float rotateInput)
    {
        float rotationChange = rotateInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0.0f, rotationChange, 0.0f);
    }
}
