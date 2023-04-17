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
        if (VerificateNotEmpty(escenario))
        {
            this.escenario = null;
        }
        else
        {
            this.escenario = escenario;
        }
    }

    public bool VerificateNotEmpty(Escenario escenario)
    {
        Debug.Log("Hay espacios Vacios");
        foreach (int i in escenario.escenarios)
        {
            if (i == -1)
                return true;
        }
        return false;
    }

}
