using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento
{
    private MovimientoBase _base;
    private int _pp;

    public MovimientoBase Base
    {
        get => _base;
        set => _base = value;
    }

    public int Pp
    {
        get => _pp;
        set => _pp = value;
    }

    public Movimiento(MovimientoBase mBase)
    {
        Base = mBase;
        Pp = mBase.PP;
    }
}
