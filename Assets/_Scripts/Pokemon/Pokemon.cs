using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    private PokemonBase _base;
    private int _nivel;
    private List<Movimiento> _movimientos;
    public List<Movimiento> Movimientos
    {
        get => _movimientos;
        set => _movimientos = value;
    }

    //Vida actual del pokemon
    private int _hp;
    public int HP
    {
        get => _hp;
        set => _hp = value;
    }

    public Pokemon(PokemonBase pkmnBase, int pkmnNivel)
    {
        _base = pkmnBase;
        _nivel = pkmnNivel;

        _hp = _base.MaxHP;

        _movimientos = new List<Movimiento>();

        foreach (var movimientoAprendible in _base.MovimientosAprendibles)
        {
            if (movimientoAprendible.Nivel <= _nivel)
            {
                _movimientos.Add(new Movimiento(movimientoAprendible.Movimiento));
            }

            if (_movimientos.Count > 4)
            {
                break;
            }
        }
    }

    public int MaxHP => Mathf.FloorToInt((_base.MaxHP*_nivel)/100.0f)+10;
    public int Ataque => Mathf.FloorToInt((_base.Ataque*_nivel)/100.0f)+1;
    public int Defensa => Mathf.FloorToInt((_base.Defensa*_nivel)/100.0f)+1;
    public int AtaqueEspecial => Mathf.FloorToInt((_base.AtaqueEspecial*_nivel)/100.0f)+1;
    public int DefensaEspecial => Mathf.FloorToInt((_base.DefensaEspecial*_nivel)/100.0f)+1;
    public int Velocidad => Mathf.FloorToInt((_base.Velocidad*_nivel)/100.0f)+1;
}
