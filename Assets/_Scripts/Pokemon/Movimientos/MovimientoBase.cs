using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movimiento", menuName = "Pokemon/Nuevo Movimiento")]
public class MovimientoBase : ScriptableObject
{
    [SerializeField] private string nombre;
    public string Nombre => nombre;

    [TextArea] [SerializeField] private string descripcion;
    public string Descripcion => descripcion;

    [SerializeField] private TipoPokemon tipo;
    [SerializeField] private int poder;
    [SerializeField] private int presicion;
    [SerializeField] private int pp;
    public TipoPokemon Tipo => tipo;
    public int Poder => poder;
    public int Presicion => presicion;
    public int PP => pp;
}
