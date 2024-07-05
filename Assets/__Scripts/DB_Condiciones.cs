using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Condiciones : MonoBehaviour {
    
    public List<Condicion> baseDeCondicions = new List<Condicion>();
    void Start() {
        var cond = new Condicion(1, "Resfriado Comun");
        var sint = new Sintoma();
        sint.id = 20101; 
        cond.AddSintoma(sint);
        sint.id = 20102; 
        cond.AddSintoma(sint);
        sint.id = 20103; 
        cond.AddSintoma(sint);
        sint.id = 20104; 
        cond.AddSintoma(sint);
        sint.id = 20105; 
        cond.AddSintoma(sint);
        sint.id = 40101; 
        cond.AddSintoma(sint);
        sint.id = 10102; 
        cond.AddSintoma(sint);
        
        baseDeCondicions.Add(cond);
        
        cond = new Condicion(2, "Gastroenteritis");
        sint.id = 30101; 
        cond.AddSintoma(sint);
        sint.id = 30102; 
        cond.AddSintoma(sint);
        sint.id = 30103; 
        cond.AddSintoma(sint);
        sint.id = 30104; 
        cond.AddSintoma(sint);
        sint.id = 30105; 
        cond.AddSintoma(sint);
        sint.id = 10102; 
        cond.AddSintoma(sint);
        
        baseDeCondicions.Add(cond);
        
        cond = new Condicion(3, "Anemia ferropénica");
        sint.id = 10103; 
        cond.AddSintoma(sint);
        sint.id = 10104; 
        cond.AddSintoma(sint);
        sint.id = 10105; 
        cond.AddSintoma(sint);
        sint.id = 10106; 
        cond.AddSintoma(sint);
        sint.id = 70105; 
        cond.AddSintoma(sint);
        sint.id = 70112; 
        cond.AddSintoma(sint);
        
        baseDeCondicions.Add(cond);
    }

}
