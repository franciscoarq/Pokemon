using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
public class ControladorJugador : MonoBehaviour
{
    private bool seMueve;

    public float velocidad;

    private Vector2 entrada;

    private Animator _animacion;

    public LayerMask capaObjetosSolidos, capaPokemon;

    private void Awake()
    {
        _animacion = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!seMueve)
        {
            //entrada.x = Input.GetAxisRaw("Horizontal");
            //entrada.y = Input.GetAxisRaw("Vertical");
            entrada = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (entrada.x != 0)
            {
                entrada.y = 0;
            }

            if (entrada != Vector2.zero)
            {
                _animacion.SetFloat("Mover X", entrada.x);
                _animacion.SetFloat("Mover Y", entrada.y);

                var posicionObjetivo = transform.position;
                posicionObjetivo.x += entrada.x;
                posicionObjetivo.y += entrada.y;

                if (EstaDisponible(posicionObjetivo))
                {
                    StartCoroutine(MoverHacia(posicionObjetivo));
                }
            }
        }
    }

    private void LateUpdate()
    {
        _animacion.SetBool("Se Mueve", seMueve);
    }

    IEnumerator MoverHacia(Vector3 destino)
    {
        seMueve = true;

        while (Vector3.Distance(transform.position, destino) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad*Time.deltaTime);
            yield return null;
        }

        transform.position = destino;

        seMueve = false;

        CheckearPokemon();

    }

    /// <summary>
    /// El método comprueba que la zona a la que queremos acceder esté disponible.
    /// </summary>
    /// <param name="objetivo">Zona a la que queremos acceder.</param>
    /// <returns>Devuelve true si el objetivo está disponible y false en caso contrario.</returns>
    private bool EstaDisponible(Vector3 objetivo)
    {
        if (Physics2D.OverlapCircle(objetivo, 0.2f, capaObjetosSolidos) != null)
        {
            return false;
        }

        return true;
    }

    private void CheckearPokemon()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, capaPokemon) != null)
        {
            if (Random.Range(0, 100) < 20)
            {
                Debug.Log("Empezar batalla");
            }
        }
    }
}
