using UnityEngine;

public class CameraRotating : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 3.0f;
    [SerializeField]
    private float smoothing = 2.0f;

    GameObject character;

    public float sensitiveY = 3f;
    public float sensitiveX = 3f;

    public float minY = -60;
    public float maxY = 60;

    private Quaternion originalRot;
    private Quaternion yQuaternion;

    private float rotY;
    private float rotX;

    void Start()
    {
        Cursor.visible = false;
        character = this.transform.parent.gameObject;
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb) { rb.freezeRotation = true; }

        originalRot = transform.localRotation;
    }

    void Update()
    {
        if (GameManager.GM.GetStateByKey("gameOver")) return;
        rotX += Input.GetAxisRaw("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        rotX %= 360;
        rotY %= 360;

        rotY = Mathf.Clamp(rotY, minY, maxY);

        yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);
        character.transform.localRotation = Quaternion.AngleAxis(rotX, character.transform.up);

        transform.localRotation = originalRot * yQuaternion;
    }
}
