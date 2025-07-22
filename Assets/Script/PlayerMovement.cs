// using UnityEngine;
// using UnityEngine.InputSystem;

// public class PlayerMovement : MonoBehaviour
// {
//     // 인스펙터 창에서 설정할 변수들
//     public float speed = 5f;
//     public float gravity = -9.81f;
// <<<<<<< Updated upstream

//     // ���� ������ �ɱ� ���� ���� �߰� ����
//     [Header("Jump & Crouch Settings")]
//     public float jumpHeight = 1.5f;
//     public float standingHeight = 2.0f;
//     public float crouchingHeight = 1.0f;
//     private bool isCrouching = false;


//     private CharacterController controller;
//     private Vector3 playerVelocity;
//     private Vector2 moveInput;
// =======
//     public float jumpHeight = 1.5f;

//     // 스크립트 내부에서 사용할 변수들
//     private CharacterController controller; // CharacterController를 담을 변수
//     private Vector3 velocity;
//     private bool isGrounded;
// >>>>>>> Stashed changes

//     void Start()
//     {
//         // 게임이 시작될 때 이 오브젝트의 CharacterController 컴포넌트를 찾아 controller 변수에 할당
//         controller = GetComponent<CharacterController>();
// <<<<<<< Updated upstream
//         // ���� ������ �� �� �ִ� Ű�� ���� ����
//         controller.height = standingHeight;
// =======
// >>>>>>> Stashed changes
//     }

//     void Update()
//     {
// <<<<<<< Updated upstream
//         // ���� ������� ���� �߷� �ӵ��� �ʱ�ȭ�մϴ�.
//         if (controller.isGrounded && playerVelocity.y < 0)
// =======
//         // 땅에 닿아있는지 확인
//         isGrounded = controller.isGrounded;

//         if (isGrounded && velocity.y < 0)
// >>>>>>> Stashed changes
//         {
//             velocity.y = -2f; // 중력이 계속 쌓이지 않도록 초기화
//         }

// <<<<<<< Updated upstream
//         // �Է� ���� �������� �̵� ������ ����մϴ�.
//         Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
//         controller.Move(move * speed * Time.deltaTime);

//         // �߷��� �����մϴ�.
//         playerVelocity.y += gravity * Time.deltaTime;
//         controller.Move(playerVelocity * Time.deltaTime);

//         // ���� �ɱ� ���¿� ���� ��Ʈ�ѷ� ���� ���� ���� �߰� ����
//         if (isCrouching)
//         {
//             controller.height = Mathf.Lerp(controller.height, crouchingHeight, Time.deltaTime * 10);
//         }
//         else
//         {
//             // �Ͼ�� �� �Ӹ��� ��ġ�� ���� �߽����� ���� ��ü�� �׷��� �浹�� Ȯ���մϴ�.
//             // �̷��� �ϸ� �ڱ� �ڽŰ� �浹�ϴ� ���� ������ �� �ֽ��ϴ�.
//             Vector3 standingHeadPosition = transform.position + new Vector3(0, standingHeight - controller.radius, 0);
//             if (Physics.CheckSphere(standingHeadPosition, controller.radius, -1, QueryTriggerInteraction.Ignore))
//             {
//                 // �Ӹ� ���� ���� ������ ���� ����
//             }
//             else
//             {
//                 controller.height = Mathf.Lerp(controller.height, standingHeight, Time.deltaTime * 10);
//             }
//         }

//     }

//     // �̵� �Լ�
//     public void OnMove(InputValue value)
//     {
//         moveInput = value.Get<Vector2>();
//     }

//     // ���� ���� �Լ� �߰� ����
//     public void OnJump(InputValue value)
//     {
//         // ��ư�� ���Ȱ�, ���� ������� ���� ����
//         if (value.isPressed && controller.isGrounded)
//         {
//             playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
//         }
// =======
//         // 키보드 입력 받기
//         float x = Input.GetAxis("Horizontal");
//         float z = Input.GetAxis("Vertical");

//         // 이동 방향 계산
//         Vector3 move = transform.right * x + transform.forward * z;

//         // **오류가 발생한 27번째 줄 부근의 핵심 수정 사항**
//         // controller 변수를 사용하여 캐릭터를 이동시킴
//         controller.Move(move * speed * Time.deltaTime);

//         // 점프 로직
//         if (Input.GetButtonDown("Jump") && isGrounded)
//         {
//             velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
//         }

//         // 중력 적용
//         velocity.y += gravity * Time.deltaTime;
//         controller.Move(velocity * Time.deltaTime);
// >>>>>>> Stashed changes
//     }


//     // ���� �ɱ� �Լ� �߰� ����
//     public void OnCrouch(InputValue value)
//     {
//         // isPressed�� ��ư�� �����ִ� ���� true, ���� false�� �˴ϴ�.
//         isCrouching = value.isPressed;
//     }

// }