using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.0f;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool isGrounded;

    public string enemyTag = "enemy";
    public string diken = "diken";

     public string enemyLayer = "düsman";
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        isGrounded = true;
    }
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        speed = 3.0f;
        _rb.velocity = new Vector2(speed * directionX, _rb.velocity.y);
        if (isGrounded && directionX > 0)
        {
            _animator.SetBool("walk", true);
            _spriteRenderer.flipX = false;
        }
        else if (isGrounded && directionX < 0)
        {
            _animator.SetBool("walk", true);
            _spriteRenderer.flipX = true;
        }
        else
            _animator.SetBool("walk", false);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            _animator.SetBool("walk", false);
            _rb.velocity = new Vector2(0f, 6f);
            _animator.SetBool("jump", true);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            _animator.SetBool("jump", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Temas edilen nesnenin etiketini kontrol et
        if (collision.CompareTag(enemyTag))
        {
            // Sahneyi yeniden başlat
            RestartScene();
        }
    }

    // Sahneyi yeniden başlatan fonksiyon
    private void RestartScene()
    {
        // Aktif sahnenin indeksini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Aktif sahneyi yeniden yükle
        SceneManager.LoadScene(currentSceneIndex);
    }

     // Düşman layer'ının adı
   

    private void OnTriggerEnter(Collider other)
    {
        // Temas eden nesnenin layer'ını kontrol et
        if (other.gameObject.layer == LayerMask.NameToLayer(enemyLayer))
        {
            // Temas edilen nesneyi yok et
            Destroy(other.gameObject);
        }
    }
   

}



