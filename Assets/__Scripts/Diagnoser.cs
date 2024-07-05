using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Diagnoser : MonoBehaviour
{
    //Components
    [SerializeField] private DB_Condiciones _dbCondiciones;
    [SerializeField] private GameObject PanelResultado;
    [SerializeField] private TMP_Text text1, text2;
    private Condicion paciente = new Condicion(0, "Paciente");
    
    [SerializeField] private List<BtnSintoma> Cat1Btns = new List<BtnSintoma>();
    [SerializeField] private List<BtnSintoma> Cat2Btns = new List<BtnSintoma>();
    [SerializeField] private List<BtnSintoma> Cat3Btns = new List<BtnSintoma>();
    [SerializeField] private List<BtnSintoma> Cat4Btns = new List<BtnSintoma>();
    [SerializeField] private List<BtnSintoma> Cat5Btns = new List<BtnSintoma>();
    [SerializeField] private List<BtnSintoma> Cat6Btns = new List<BtnSintoma>();
    [SerializeField] private List<BtnSintoma> Cat7Btns = new List<BtnSintoma>();
    [SerializeField] private List<BtnSintoma> Cat8Btns = new List<BtnSintoma>();

    List<BtnSintoma> IndextoList(int id) {
        List<BtnSintoma> lista = null;
        switch (id) {
            case 1:
                lista = Cat1Btns;
                break;
            case 2:
                lista = Cat2Btns;
                break;
            case 3:
                lista = Cat3Btns;
                break;
            case 4:
                lista = Cat4Btns;
                break;
            case 5:
                lista = Cat5Btns;
                break;
            case 6:
                lista = Cat6Btns;
                break;
            case 7:
                lista = Cat7Btns;
                break;
            case 8:
                lista = Cat8Btns;
                break;
        }
        return lista;
    }
    public void Clear(int cat) {
        List<BtnSintoma> lista = IndextoList(cat);
        foreach (var btn in lista) {
            btn.clear();
        }
        paciente.deleteCat(cat);
    }

    public void Diagnostico() {
        int finalQty = 0;
        if (!paciente.isEmpty()) {
            PanelResultado.SetActive(true);
            int idEnfermedad = 1;
            float maxPercent = 0;
            float percent;
            int qty = 0;

            foreach (var condicion in _dbCondiciones.baseDeCondicions) {
                paciente.Comparar(condicion, out percent, out qty);
                if (percent > maxPercent) {
                    maxPercent = percent;
                    finalQty = qty;
                    idEnfermedad = condicion.getID();
                }
            }
            if (maxPercent >= 50) {
                text1.text =
                    $"Segun los sintomas seleccionados, se obtuvo un {maxPercent}% de similitud de sintomas para la condicion: \"{_dbCondiciones.baseDeCondicions[idEnfermedad - 1].nombre}\". Con {finalQty} sintomas de la enfermedad presentes en el paciente";
                text2.text = _dbCondiciones.baseDeCondicions[idEnfermedad - 1].recomendacion;
            }
            else {
                text1.text = "";
                text2.text = "No hubo coincidencia de sintomas suficientemente certera";
            }
            ClearAll();
            gameObject.SetActive(false);
        }
    }
    public void ClearAll() {
        for (int i = 1; i <= 8; i++) {
            Clear(i);
        }
    }
    public void SavCat(int cat) {
        List<Sintoma> listaSintomas = new List<Sintoma>();
        foreach (var btn in IndextoList(cat)) {
            if (btn.selected) {
                Sintoma sint = new Sintoma();
                sint.id = btn.SintomaID;
                listaSintomas.Add(sint);
            }
        }
        paciente.AddCategoria(new Categoria(cat, listaSintomas));
    }
}
