using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllers : MonoBehaviour
{
    public float moveSpeed = 2f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;

    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
    Vector2 movementInput;  //Vector2 Hướng X Y
    Rigidbody2D rb;

    //Add animation cho chuyển động nhân vật
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //If movement input is not 0, try to move
        //Đoạn code sau là giúp cho việc di chuyển mượt hơn khi gặp các collisions
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);
            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }
            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        //Set direction of sprite to sang hướng ngược lại
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(        //Hàm Cast() được gọi từ RigidBody2D được dùng để kiểm tra va chạm
                direction,  //Kiểm tra hướng va chạm của nhân vật theo trục X, Y (giá trị dao động -1 1 theo WSAD) --> này là nút di chuyển nhập từ bàn phím
                movementFilter, //Định rõ các điều kiện và thiết lập khi nào và làm thế nào va chạm sẽ được xác định
                castCollision,  //Lưu trữ thông tin chi tiết về các va chạm được tìm thấy sau khi rb.Cast hoàn tất.
                moveSpeed * Time.fixedDeltaTime + collisionOffset//The amount to cast equal to the movement plus an offset 
            );

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            //. MovePosition: là phương thức dùng để di chuyển đối tượng đến vị trí mới
            //Vị trí hiện tại + hướng di chuyển nhập từ bàn phím * tốc độ nhân vật * tgian giữa các khung cố định
            return true;
        }
        else
        {
            return false;
        }
    }

    //Character Movement
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
        if (movementInput != Vector2.zero)
        {
            animator.SetFloat("XDirection", movementInput.x);
            animator.SetFloat("YDirection", movementInput.y);
        }

    }
}
