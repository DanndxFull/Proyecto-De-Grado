using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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
    [SerializeField] TextMeshProUGUI nombresEscenarios;

    [Header("Modificar Escenario")]
    [SerializeField] TMP_InputField nameFieldModificar;

    [Header("Eliminar Escenario")]
    [SerializeField] TMP_InputField nameFieldEliminar;


    string[] nombres =  { "Carritos Compra", "Carro y Vascula", "Prueba Fuerza", "Carrito de Juguete", 
        "Caida", "Pendulo", "Pendulo Estatico", "Plano Inclinado", "Resorte", "Resorte 2", "Polea", "Carro Inclinado"};

    Escenario currentEscenario;

    private void Awake()
    {
        currentEscenario = new Escenario();
    }

    private void OnEnable()
    {
        ResetEscenarios();
        ConsultarEscenarios();
    }

    private void ResetEscenarios()
    {
        foreach (TextMeshProUGUI t in names)
        {
            t.SetText("No Seleccionado");
        }
        nameCurrentStage.SetText("Escenario No Seleccionado");
        currentEscenario = new Escenario();
    }

    public void ChangeLevel()
    {
        if(nivelNombre.value == 12)
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
        if (nameFiedlCrear.text == null || nameFiedlCrear.text == "" || VerificateNotEmpty())
        {
            return;
        }

        currentEscenario.nombre = nameFiedlCrear.text;
        nameCurrentStage.text = currentEscenario.nombre;
        EscenarioManager.instance.CreateStage(currentEscenario);
        nameFiedlCrear.text = "";
    }

    public void ConsultarEscenarios()
    {
        EscenarioManager.instance.LoadStages();
        Escenarios escenarios = EscenarioManager.instance.currentEscenarios;
        nombresEscenarios.text = "";
        foreach (Escenario e in escenarios.escenarios)
        {
            nombresEscenarios.text += e.nombre + "\n";
        }        
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
        nameFiedlConsultar.text = "";
        CurrentEscenario.instanceEscenario.escenario = currentEscenario;
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
        nameFieldModificar.text = "";
    }

    public void EliminarEscenario()
    {
        if(nameFieldEliminar.text == null || nameFieldEliminar.text == "")
        {
            return;
        }

        EscenarioManager.instance.DeleteStage(nameFieldEliminar.text);
        nameFieldEliminar.text = "";
    }
}
