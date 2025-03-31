using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bool isJumping = Input.GetButtonDown("Jump");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Horizontal movement
        transform.Translate(horizontal * Time.deltaTime * MoveSpeed, 0, 0);
        
        // Jump force
        if (isJumping)
        {
            _rigidBody.AddForce(Vector2.up * JumpForce);
            _animator.SetFloat("Vertical", Mathf.Abs(vertical));
        }
        
        //Animation update
        _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        
        
        //Flipping sprite
        if (horizontal > 0)
            _spriteRenderer.flipX = false;
        else if (horizontal < 0)
            _spriteRenderer.flipX = true;
        
    }
}
