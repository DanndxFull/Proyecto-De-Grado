using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEscenario : MonoBehaviour
{
    public static CurrentEscenario instanceEscenario;
    public Escenario escenario;

    private void Awake()
    {
        if (instanceEscenario == null)
        {
            instanceEscenario = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetCurrentEscenario(Escenario escenario)
    {
        this.escenario = escenario;
    }
}
