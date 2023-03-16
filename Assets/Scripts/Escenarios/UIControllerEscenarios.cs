using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControllerEscenarios : MonoBehaviour
{
    [Header("Selector Niveles")]
    [SerializeField] TMP_Dropdown nivelNumero, nivelNombre;
    [SerializeField] List<TextMeshProUGUI> names;
    [SerializeField] TextMeshProUGUI nameCurrentStage;

    [Header("Crear Escenario")]
    [SerializeField] TMP_InputField nameFiedlCrear;

    [Header("Consultar Escenario")]
    [SerializeField] TMP_InputField nameFiedlConsultar;

    [Header("Modificar Escenario")]
    [SerializeField] TMP_InputField nameFieldModificar;

    string[] nombres =  { "Carritos Compra", "Carritos y Vascula", "Prueba Fuerza", "Carrito de Juguete" };

    Escenario currentEscenario;

    private void Awake()
    {
        currentEscenario = new Escenario();
    }

    public void ChangeLevel()
    {
        if(nivelNombre.value == 4)
        {
            currentEscenario.escenarios[nivelNumero.value] = -1;
            names[nivelNumero.value].text = "No Seleccionado";
        }
        else
        {
            if (VerificateNotDuplicated())
            {
                return;
            }

            names[nivelNumero.value].text = nombres[nivelNombre.value];
            currentEscenario.escenarios[nivelNumero.value] = nivelNombre.value;
        }
    }

    public void ResetCurrentEscenario()
    {
        currentEscenario = new Escenario();
    }

    public bool VerificateNotDuplicated()
    {
        foreach (int i in currentEscenario.escenarios)
        {
            if (i == nivelNombre.value)
                return true;
        }
        return false;
    }

    public bool VerificateNotEmpty()
    {
        Debug.Log("Hay espacios Vacios");
        foreach (int i in currentEscenario.escenarios)
        {
            if (i == -1)
                return true;
        }
        return false;
    }

    public void CreateEscenario()
    {
        Debug.Log("Empezando a crear");
        if (nameFiedlCrear.text == null || nameFiedlCrear.text == "" || VerificateNotEmpty())
        {
            return;
        }

        currentEscenario.nombre = nameFiedlCrear.text;
        Debug.Log("Empezando a crear1");
        nameCurrentStage.text = currentEscenario.nombre;
        Debug.Log("Empezando a crear2");
        EscenarioManager.instance.CreateStage(currentEscenario);
        Debug.Log("Escenario Creado Con Exito");
    }

    public void ConsultarEscenario()
    {
        if (nameFiedlConsultar.text == null || nameFiedlConsultar.text == "")
        {
            return;
        }

        currentEscenario = EscenarioManager.instance.LoadStage(nameFiedlConsultar.text);
        if(currentEscenario == null)
        {
            Debug.Log("Escenario Consultado Sin Exito");
            return;
        }
        nameCurrentStage.text = currentEscenario.nombre;
        int index = 0;
        foreach (int i in currentEscenario.escenarios)
        {
            names[index].text = nombres[i];
            index++;
        }
        Debug.Log("Escenario Consultado Con Exito");
    }

    public void ModificarEscenario()
    {
        if (VerificateNotEmpty())
        {
            return;
        }

        if(nameFieldModificar.text == null || nameFieldModificar.text == "")
        {
            EscenarioManager.instance.UpdateStage(currentEscenario.nombre,currentEscenario.escenarios);
        }
        else
        {
            EscenarioManager.instance.UpdateStage(currentEscenario.nombre, nameFieldModificar.text, currentEscenario.escenarios);
        }
    }
}
