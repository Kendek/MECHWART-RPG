using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;
    public VectorValue startingPosition;

    // Start is called before the first frame update
    void Start()
    {
       velocity = new Vector2(speed, speed);
       characterBody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        inputMovement = new Vector2 (
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }
    private void FixedUpdate()
    { 
        Vector2 delta = inputMovement * velocity * Time.deltaTime;
        Vector2 newPosition = characterBody.position + delta;
        characterBody.MovePosition(newPosition);
    }
}
