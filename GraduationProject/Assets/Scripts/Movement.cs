using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f; // гравитация, т.е ускорение свободного падения
                                   // на Земле это 9,81 м/c^2
                                   // дельтаY = 1/2*гравитация * время^2
    public float jumpHeight = 3f;

    public Transform groundCheck; // Проверка 
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // проверка на то, что мы коснулись земли

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); // Считываем движения с клавиатуры
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // y не меняется во время передвижения

        controller.Move(move * speed * Time.deltaTime); // умножение на дельту-тайм, чтобы сделать передвижение независимым от кадров в секунду

        // v = sqrt(h * -2g)
        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
