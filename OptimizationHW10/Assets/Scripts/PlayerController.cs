using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Transform _playerTransform;
    [SerializeField] private Camera _playerCamera;

    public float MouseSensitivity = 100f;
    public float MoveSpeed = 5f;

    private Vector3 _moveDir = Vector3.zero;
    private Vector2 _mouseLook = Vector2.zero;
    private float xRotation = 0;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerTransform = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLook();

        PlayerMove();
    }

    private void PlayerLook()
    {
        _mouseLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * MouseSensitivity * Time.deltaTime;

        xRotation -= _mouseLook.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        _playerTransform.Rotate(Vector3.up * _mouseLook.x);
    }

    private void PlayerMove()
    {
        _moveDir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        _characterController.Move(_moveDir * MoveSpeed * Time.deltaTime);
    }
}
