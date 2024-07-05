
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Condicion {
    public string nombre;
    private int id;
    private List<Categoria> nodos = new List<Categoria>();
    public string recomendacion;
    
    public bool isEmpty() {
        if (nodos.Count > 0) {
            return false;
        }
        return true;
    }
    public Condicion(int _id, string _nombre) {
        id = _id;
        nombre = _nombre;
    }

    public int getID() {
        return id;
    }
    public void AddCategoria(Categoria cat) {
        if (!isCatAdded(cat.id)) {
            nodos.Add(cat);
        }
        else {
            deleteCat(cat.id);
            nodos.Add(cat);
        }
    }
    
    public void Comparar(Condicion cond, out float percent, out int number) {
        number = 0;
        var sintomas1 = new List<int>();
        var sintomas2 = new List<int>();
        sintomas1 = this.ListarSintomas();
        sintomas2 = cond.ListarSintomas();
        
        foreach (var id in sintomas1) {
            if (sintomas2.Contains(id)) {
                number++;
            }
        }
        
        percent = 100 * (float)number / (sintomas2.Count + (sintomas1.Count - number)/2);
    }
    public void AddSintoma(Sintoma sint) {
        int catId = (sint.id - sint.id % 1000) / 10000;
        if (!isCatAdded(catId)) {
            var sintomas = new List<Sintoma>();
            sintomas.Add(sint);
            var newCat = new Categoria(catId, sintomas);
            AddCategoria(newCat);
        }
        else {
            foreach (var cat in nodos) {
                if (cat.id == catId) {
                    cat.AddSintoma(sint);
                    return;
                }
            }
        }
    }
    public void deleteCat(int id){
        foreach (var cat in nodos) {
            if (cat.id == id) {
                nodos.Remove(cat);
                return;
            }
        }
    }
    bool isCatAdded(int id) {
        foreach (var cat in nodos) {
            if (cat.id == id) {
                return true;
            }
        }

        return false;
    }
    public List<int> ListarSintomas() {
        List<int> ids = new List<int>();
        foreach (var cat in nodos) {
            foreach (var idSint in cat.ListarSintomas()) {
                ids.Add(idSint);
            }
        }
        return ids;
    }
    public string ImprimirSintomas() {
        StringBuilder str = new StringBuilder("");
        str.Clear();
        foreach (var cat in nodos) {
            foreach (var idSint in cat.ListarSintomas()) {
                str.Append(" ");
                str.Append(idSint);
            }
        }

        return str.ToString();
    }
}

public class Categoria {
    private string nombre;
    public int id;
    private List<Sintoma> sintomas;

    public Categoria(int _id, List<Sintoma> sint) {
        id = _id;
        sintomas = new List<Sintoma>(sint);
    }

    public void AddSintoma(Sintoma newSint) {
        sintomas.Add(newSint);
    }

    void ActualizarLista(List<Sintoma> sint) {
        sintomas = new List<Sintoma>(sint);
    }

    public List<int> ListarSintomas() {
        List<int> lista = new List<int>();
        foreach (var sint in sintomas) {
            lista.Add(sint.id);
        }

        return lista;
    }
}

public struct Sintoma {
    private string nombre;
    public int id;

    
}