using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIControllerEscenarios : MonoBehaviour
{
    [SerializeField] GameObject UIESCENARIOS;
    
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
        "Caida", "Pendulo", "Pendulo Estatico", "Plano Inclinado", "Resorte", "Resorte 2", "Polea", 
        "Carro Inclinado","Distancia", "Distancia Esfera","Plataforma Resorte", "Fuerza Horizontal",
        "Resorte Humano","Sube y Baja"};

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
        if(nivelNombre.value == 18)
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
            ShortMessage.instanceMessage.ShowMessage("No se pudo crear el escenario porque no hay nombre del escenario o hay espacios vacios, " +
                "todo escenario debe tener nueve niveles", 2);
            return;
        }


        currentEscenario.nombre = nameFiedlCrear.text;
        nameCurrentStage.text = currentEscenario.nombre;
        EscenarioManager.instance.CreateStage(currentEscenario);
        UIESCENARIOS.SetActive(false);
        UIESCENARIOS.SetActive(true);
        nameFiedlCrear.text = "";
        ShortMessage.instanceMessage.ShowMessage("Se creo el escenario con exito", 2);
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
            ShortMessage.instanceMessage.ShowMessage("No se pudo consultar el escenario", 2);
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
            ShortMessage.instanceMessage.ShowMessage("No se pudo modificar el escenario", 2);
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
        ShortMessage.instanceMessage.ShowMessage("Se modifico el escenario con exito", 2);
    }

    public void EliminarEscenario()
    {
        if(nameFieldEliminar.text == null || nameFieldEliminar.text == "")
        {
            ShortMessage.instanceMessage.ShowMessage("No se pudo eliminar el escenario", 2);
            return;
        }

        EscenarioManager.instance.DeleteStage(nameFieldEliminar.text);
        nameFieldEliminar.text = "";
        ShortMessage.instanceMessage.ShowMessage("Se elimino el escenario con exito", 2);
    }
}
