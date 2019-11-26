using UnityEngine;
using Rewired;

public class PlayerControls : MonoBehaviour
{
    //Components
    Rigidbody rBody;

    //Variables
    [SerializeField] private int playerID;
    [SerializeField] private Player player;

    Vector3 movement;

    public float speed = 6f;
    public float boostForce = 50;
    public float boostCooldown = 0.6f;
    float boostTimer = 0f;

    //DEBUG VARIABLES


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        player = ReInput.players.GetPlayer(playerID);
    }

    private void Update()
    {
        boostTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = player.GetAxis("MoveHorizontal");
        float moveVertical = player.GetAxis("MoveVertical");

        movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Move the player around the scene.
        Move(moveHorizontal, moveVertical);

        // Turn the player to face the mouse cursor.
        Turning();

        if (player.GetButtonDown("Boost") && boostTimer >= boostCooldown)
        {
            Boost();
        }
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        rBody.MovePosition(transform.position + movement);
    }

    void Turning()
    {

    }

    void Boost()
    {
        boostTimer = 0f;
        rBody.AddForce(movement * boostForce, ForceMode.Impulse);
        Debug.Log("Boost!");
    }

}
