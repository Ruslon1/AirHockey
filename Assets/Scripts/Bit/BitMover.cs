using UnityEngine;

public class BitMover : MonoBehaviour
{
    protected void Move(Vector3 position, Rigidbody2D rigidbody)
    {
        rigidbody.MovePosition(position);
    }

    protected void MoveHorizontally(Vector3 position, Rigidbody2D rigidbody)
    {
        var nextPosition = transform.position;
        nextPosition.x = position.x;
        rigidbody.MovePosition(nextPosition);
    }
}