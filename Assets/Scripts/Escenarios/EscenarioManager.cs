using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscenarioManager : MonoBehaviour
{
    Escenarios currentEscenarios; 

    public static EscenarioManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        LoadStages();
    }

    public void CreateStages()
    {
        List<Escenario> escenarios = new List<Escenario>();
        currentEscenarios = new Escenarios(escenarios);
        SaveManagerEscenario.SavePlayerProfile(currentEscenarios);
    }

    public void CreateStage(Escenario escenario)
    {
        currentEscenarios.AddProfile(escenario.nombre, escenario.escenarios);
        SaveManagerEscenario.SavePlayerProfile(currentEscenarios);
    }

    public void LoadStages()
    {
        currentEscenarios = SaveManagerEscenario.LoadPlayerProfile();
        if (currentEscenarios == null)
        {
            CreateStages();
        }
    }

    public Escenario LoadStage(string name)
    {
        currentEscenarios = SaveManagerEscenario.LoadPlayerProfile();
        if (currentEscenarios == null)
        {
            CreateStages();
        }
        return currentEscenarios.GetProfile(name);
    }

    public void UpdateStage(string name, int[] escenarios)
    {
        currentEscenarios.UpdateEscenarios(name, escenarios);
        SaveManagerEscenario.SavePlayerProfile(currentEscenarios);
    }
    public void UpdateStage(string name, string newName, int[] escenarios)
    {
        currentEscenarios.UpdateNameStage(name,newName, escenarios);
        SaveManagerEscenario.SavePlayerProfile(currentEscenarios);
    }
}
