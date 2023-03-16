[System.Serializable]
public class Escenario
{
    public string nombre;
    public int[] escenarios = new int[4];

    public Escenario()
    {
        this.nombre = "";
        this.escenarios = new int[4] { -1,-1,-1,-1};
    }
    public Escenario(string nombre, int[] nuevosEscenarios)
    {
        this.nombre = nombre;
        this.escenarios = nuevosEscenarios;
    }

    public Escenario(Escenario escenario)
    {
        escenarios = escenario.escenarios;
    }
}
