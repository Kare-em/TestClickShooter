using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : EntityController
{
    [SerializeField] private Transform _body;

    private Vector3 _lastMousePosition;
    private Rigidbody _rb;
    private Camera _camera;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
        Init();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            LookAtMouse();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void LookAtMouse()
    {
        // Get mouse position in world space
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Calculate direction from camera to mouse position
            Vector3 direction = (hit.point - _body.position).normalized;
            direction.y = 0f;
            _body.LookAt(_body.position + direction);
        }
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0, moveY);
        _rb.MovePosition(transform.position + moveDir * (_moveSpeed * Time.fixedDeltaTime));
    }

    protected override void Die()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}