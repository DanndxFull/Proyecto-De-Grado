using System.Collections.Generic;

[System.Serializable]

public class Escenarios
{
    public List<Escenario> escenarios;
    public Escenarios(List<Escenario> profiles)
    {
        this.escenarios = profiles;
    }

    public void AddProfile(string name, int[] nuevosEscenarios)
    {
        Escenario profile = new Escenario(name, nuevosEscenarios);
        escenarios.Add(profile);
    }

    public Escenario GetProfile(string name)
    {
        foreach (Escenario e in escenarios)
        {
            if (e.nombre == name)
            {
                return e;
            }
        }
        return null;
    }
    public List<Escenario> GetProfiles()
    {
        return escenarios;
    }

    public void UpdateNameStage(string name, string newName, int[] escenarios)
    {
        foreach (Escenario p in this.escenarios)
        {
            if (p.nombre == name)
            {
                p.nombre = newName;
                p.escenarios = escenarios;
            }
        }
    }

    public void UpdateEscenarios(string name, int[] escenarios)
    {
        foreach (Escenario p in this.escenarios)
        {
            if (p.nombre == name)
            {
                p.escenarios = escenarios;
            }
        }
    }

    public Escenarios DeleteProfile(string name)
    {
        foreach (Escenario p in escenarios)
        {
            if (p.nombre == name)
            {
                escenarios.Remove(p);
                return this;
            }
        }
        return null;
    }
}
