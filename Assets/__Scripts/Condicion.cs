
using System.Collections.Generic;

public class Condicion {
    private string nombre;
    private int id;
    private List<Categoria> nodos = new List<Categoria>();

    public Condicion(int _id, string _nombre) {
        id = _id;
        nombre = _nombre;
    }
    void AddCategoria(Categoria cat) {
        if (!isCatAdded(cat.id)) {
            nodos.Add(cat);
        }
        else {
            deleteCat(id);
            nodos.Add(cat);
        }
    }
    
    void deleteCat(int id){
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
    //ListarSintomas()
}

class Categoria {
    private string nombre;
    public int id;
    private List<Sintoma> sintomas;

    public Categoria(string _nombre, int _id, List<Sintoma> sint) {
        nombre = _nombre;
        id = _id;
        sintomas = new List<Sintoma>(sint);
    }

    void ActualizarLista(List<Sintoma> sint) {
        sintomas = new List<Sintoma>(sint);
    }

    List<int> ListarSintomas() {
        List<int> lista = new List<int>();
        foreach (var sint in sintomas) {
            lista.Add(sint.id);
        }

        return lista;
    }
}

struct Sintoma {
    private string nombre;
    public int id;
}