using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagnoser : MonoBehaviour
{
    //Components
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
