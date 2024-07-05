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
    
    public void Clear(int cat) {
        List<BtnSintoma> Listatemp = null;
        switch (cat) {
            case 1:
                Listatemp = Cat1Btns;
                break;
            case 2:
                Listatemp = Cat2Btns;
                break;
            case 3:
                Listatemp = Cat3Btns;
                break;
            case 4:
                Listatemp = Cat4Btns;
                break;
            case 5:
                Listatemp = Cat5Btns;
                break;
            case 6:
                Listatemp = Cat6Btns;
                break;
            case 7:
                Listatemp = Cat7Btns;
                break;
            case 8:
                Listatemp = Cat8Btns;
                break;
        }
        foreach (var btn in Listatemp) {
            btn.clear();
        }
    }

    public void SavCat(int cat) {
        //mark that the category has sintomas marcados
    }
}
