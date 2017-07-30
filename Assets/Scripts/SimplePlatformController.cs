using UnityEngine;

public class SimplePlatformController : MonoBehaviour {

    [HideInInspector]
    public bool IsFacingRight = true;

    public float MoveForce = 365f;
    public float MaxSpeed = 5f;
    public float JumpForce = 1000f;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    public AudioClip[] JumpSounds;

    private bool _isGrounded;
    private Animator _anim;
    private Rigidbody2D _rb;
    private AudioSource _audio;
    private bool _startJump = false;

    void Awake () {
        _audio = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        _isGrounded = Physics2D.Linecast(transform.position, GroundCheck.position, GroundLayer);

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _startJump = true;
        }
	}

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        _anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * _rb.velocity.x < MaxSpeed)
            _rb.AddForce(Vector2.right * h * MoveForce);

        if (Mathf.Abs(_rb.velocity.x) > MaxSpeed)
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -MaxSpeed, MaxSpeed), _rb.velocity.y);

        if ((h > 0 && !IsFacingRight) || (h < 0 && IsFacingRight))
            Flip();

        if (_startJump)
        {
            PlayJumpSound();

            _anim.SetTrigger("Jump");
            _rb.AddForce(new Vector2(0, JumpForce));
            _startJump = false;
        }
    }

    void PlayJumpSound()
    {
        if (JumpSounds.Length == 0) return;

        _audio.clip = JumpSounds[Random.Range(0, JumpSounds.Length)];
        _audio.Play();
    }

    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
