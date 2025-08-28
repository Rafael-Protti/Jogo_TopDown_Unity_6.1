using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float velocidade = 5;
    public float velocidadeMax = 5;

    Rigidbody2D rb;

    float horizontal;
    float vertical;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update() //Manter Inputs no Update comum.
    {
        PlayerInputs();
    }
    void FixedUpdate() //Física se faz no FixedUpdate. No Fixed não é necessário usar o *Time.deltaTime.
    {
        MovePlayer();
    }

    void PlayerInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        rb.linearVelocity = new Vector2(horizontal, vertical) * velocidade;
        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -velocidadeMax, velocidadeMax);
        rb.linearVelocityY = Mathf.Clamp(rb.linearVelocityY, -velocidadeMax, velocidadeMax);
    }
}
