using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform alvo;
    public float velocidade = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alvo = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (alvo == null)
        {
            return;
        }

        Vector3 direcao = alvo.position - transform.position;
        direcao = direcao.normalized;

        transform.position += direcao * velocidade * Time.deltaTime;

        Utils.OlharParaObjeto(transform, alvo);
    }
}
