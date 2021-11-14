using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //[Serializable]

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Nuevo Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] private int ID;

    [SerializeField] private string nombre;
    public string Nombre => nombre;

    [TextArea] [SerializeField] private string descripcion;
    public string Descripcion => descripcion;

    [SerializeField] private Sprite spriteFrente;
    [SerializeField] private Sprite spriteAtras;

    [SerializeField] private TipoPokemon tipo1;
    public TipoPokemon Tipo1 => tipo1;
    [SerializeField] private TipoPokemon tipo2;
    public TipoPokemon Tipo2 => tipo2;

    //Estadísticas
    [SerializeField] private int maxHP;
    [SerializeField] private int ataque;
    [SerializeField] private int defensa;
    [SerializeField] private int ataqueEspecial;
    [SerializeField] private int defensaEspecial;
    [SerializeField] private int velocidad;
    public int MaxHP => maxHP;
    public int Ataque => ataque;
    public int Defensa => defensa;
    public int AtaqueEspecial => ataqueEspecial;
    public int DefensaEspecial => defensaEspecial;
    public int Velocidad => velocidad;

    [SerializeField] private List<MovimientosAprendibles> movimientosAprendibles;
    public List<MovimientosAprendibles> MovimientosAprendibles => movimientosAprendibles;
}

public enum TipoPokemon
{
    None,
    Normal,
    Fuego,
    Agua,
    Planta,
    Eléctrico,
    Lucha,
    Hielo,
    Veneno,
    Tierra,
    Roca,
    Volador,
    Psiquico,
    Bicho,
    Fantasma,
    Dragon,
    Siniestro,
    Hada,
    Acero
}

[Serializable]
public class MovimientosAprendibles
{
    [SerializeField] private MovimientoBase movimiento;
    [SerializeField] private int nivel;
    public MovimientoBase Movimiento => movimiento;
    public int Nivel => nivel;
}