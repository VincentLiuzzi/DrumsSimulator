using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class DrumsController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float scaleSpeed = 0.1f;
    public float verticalSpeed = 2.0f;
    public float rotationSpeed = 50.0f;

    private InputAction moveAction;
    private InputAction verticalAction;
    private InputAction scaleAction;
    private InputAction rotateAction;

    void Start()
    {
        // Configurer les actions d'entrée
        var actionMap = new InputActionMap("DrumsControls");

        moveAction = actionMap.AddAction("Move", binding: "<XRController>{LeftHand}/thumbstick");
        verticalAction = actionMap.AddAction("Vertical", binding: "<XRController>{RightHand}/thumbstick/y");
        scaleAction = actionMap.AddAction("Scale", binding: "<XRController>{RightHand}/thumbstick/y");
        rotateAction = actionMap.AddAction("Rotate", binding: "<XRController>{RightHand}/thumbstick/x");

        actionMap.Enable();
    }

    void Update()
    {
        // Récupérer les entrées des sticks analogiques des manettes Oculus
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float verticalInput = verticalAction.ReadValue<float>();
        float scaleInput = scaleAction.ReadValue<float>();
        float rotateInput = rotateAction.ReadValue<float>();

        // Déplacer l'objet avec le stick gauche
        Vector3 moveDirection = new Vector3(moveInput.x, 0.0f, moveInput.y);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Monter ou descendre l'objet avec le stick droit (axe vertical)
        Vector3 verticalDirection = new Vector3(0.0f, verticalInput, 0.0f);
        transform.Translate(verticalDirection * verticalSpeed * Time.deltaTime, Space.World);

        // Agrandir ou rapetisser l'objet avec le stick droit (axe vertical)
        float scaleChange = scaleInput * scaleSpeed * Time.deltaTime;
        transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);

        // Effectuer une rotation avec le stick droit (axe horizontal)
        float rotationChange = rotateInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0.0f, rotationChange, 0.0f);
    }
}
