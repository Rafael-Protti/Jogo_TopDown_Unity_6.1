using UnityEngine;

public class Utils : MonoBehaviour
{
    /// <summary>
    /// Faz uma ORIGEM olhar para a direção de um OBJETO através de RIGIDBODY2D ou TRANSFORM.
    /// </summary>
    /// <param name="origem">Quem vai olhar</param>
    /// <param name="objeto">Para onde vai olhar</param>
    public static void OlharParaObjeto( Transform origem, Vector3 objeto )
    {
        Vector3 direcao = (objeto - origem.position).normalized;

        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg; //O y vem primeiro nesse comando.

        if (origem.GetComponent<Rigidbody2D>())
        {
            origem.GetComponent<Rigidbody2D>().rotation = angulo;
        }

        else
        {
            origem.eulerAngles = new Vector3(0, 0, angulo);
        }
        
    }
    public static void OlharParaObjeto(Transform origem, Transform objeto)
    {
        OlharParaObjeto(origem, objeto.position);
    }
}
