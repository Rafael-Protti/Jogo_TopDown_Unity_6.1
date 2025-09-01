using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float velocidade = 5;
    public float velocidadeMax = 5;
    public Transform posicaoNPC;  

    Rigidbody2D rb;

    float horizontal;
    float vertical;
    bool cutscene = false;
    bool tecla = false;

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
        RotateMouse();
        Comando();
    }

    void PlayerInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        Vector2 movimento = new Vector2(horizontal, vertical); // impede que ao pressionar duas teclas (andar na diagonal) o personagem ande mais rápido.
        
        if (movimento.magnitude > 1)
        {
            movimento = movimento.normalized;
        }

        movimento *= velocidade;

        rb.linearVelocity = movimento;

        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -velocidadeMax, velocidadeMax);
        rb.linearVelocityY = Mathf.Clamp(rb.linearVelocityY, -velocidadeMax, velocidadeMax);
    }

    void Rotate()
    {
        if (vertical == 00 && horizontal == 0)
        {
            return; //se não entrar na condição do IF, a função inteira para de rodar.
        }
        float angulo = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg; //O y vem primeiro nesse comando.
        rb.rotation = angulo;   
    }

    void RotateMouse()
    {
        Vector3 posicaoMundoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Utils.OlharParaObjeto(transform, posicaoMundoMouse);
    }

    void Comando()
    {
        if (tecla = Input.GetKey(KeyCode.F))
        {
            cutscene = true;
        }

        if (tecla = Input.GetKey(KeyCode.G))
        {
            cutscene = false;
        }

        if (cutscene)
        {
            OlharNPC();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }

    }

    void OlharNPC()
    {
        Utils.OlharParaObjeto(transform, posicaoNPC);
    }
}
