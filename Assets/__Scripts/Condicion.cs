
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Condicion {
    private string nombre;
    private int id;
    private List<Categoria> nodos = new List<Categoria>();

    public Condicion(int _id, string _nombre) {
        id = _id;
        nombre = _nombre;
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
    //compararSintomas()
    public string ListarSintomas() {
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