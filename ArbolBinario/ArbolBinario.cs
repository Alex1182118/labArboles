﻿using System;
using System.Collections.Generic; using System.Linq; using System.Threading.Tasks;

namespace ArbolBinario
{
    public class ArbolBinario<T> 
    {
        private Nodo<T> Root;          public void CreateTree(string newkey, T valor)         {             if (Root == null) //Si el arbol esta vacio lo crea
            {
                //Recibe un nuevo nodo, tipo Nodo, que contiene la informacion 
                Nodo<T> newnode = new Nodo<T>();                 newnode.Informacion = valor; //Se le asigna la informacion                 newnode.nombre = newkey;                 Root = newnode; //La raiz es igual al primer nodo
            }             else
            {                 AddNode(valor, newkey, Root); //Si ya existe una raiz, se va a agregar nodo
            }         }          private void AddNode(T valor, string newkey, Nodo<T> nodo)
        {              Nodo<T> nodoadd = nodo;             if ((String.Compare(newkey, nodoadd.nombre, StringComparison.CurrentCultureIgnoreCase) == 1))//Si el nombre del nodo alfabeticamente es menor a la raiz, o al valor que recursivamente haya tomado, lo agrega a la iz)
            {                 if (nodoadd.Izquierda == null) //Si esta vacio a la izquierda lo agrega
                {                     Nodo<T> nuevoNodo = new Nodo<T>();                     nuevoNodo.Informacion = valor;                     nuevoNodo.nombre = newkey;                     nodoadd.Izquierda = nuevoNodo;                 }                 else                 {                     AddNode(valor, newkey, nodoadd.Izquierda);//Si hay un nodo a la izquierda regresa a la funcion 
                }             }             else             {                 if (nodoadd.Derecha == null)                 {                     Nodo<T> nuevoNodo = new Nodo<T>();                     nuevoNodo.Informacion = valor;                     nuevoNodo.nombre = newkey;                     nodoadd.Derecha = nuevoNodo;                 }                 else                 {                     AddNode(valor, newkey, nodo.Derecha);                 }             }         }

        public Nodo<T> Buscar(string medicamento)
        {
            foreach (Nodo<T> nodo in RecorridoInorder(Root))
            {
                Medicamento actual = (Medicamento)(Object)nodo.nombre;
                if (actual.Nombre.Equals(medicamento))
                    return nodo;
            }
            return null;

        }

        public IEnumerable<Nodo<T>> RecorridoPreorder(Nodo<T> nodo)
        {

            if (nodo.Izquierda != null)
            {
                foreach (Nodo<T> nodoIzqActual in RecorridoPreorder(nodo.Izquierda))
                    yield return nodoIzqActual;
                //Va a agarrar la raiz el sub arbor
                // SE va a ir por todo el lado izquierdo
                //Recorrido preorden
                //yield hace el cast al hacer el return
            }
            else if (nodo.Derecha != null)
            {
                foreach (Nodo<T> nodoDerechoActual in RecorridoPreorder(nodo.Derecha))
                    yield return nodoDerechoActual;
            }
        }

        public IEnumerable<Nodo<T>> RecorridoInorder(Nodo<T> nodo)
        {

            if (nodo != null)
            {
                RecorridoInorder(nodo.Izquierda);
                yield return nodo;
                RecorridoInorder(nodo.Derecha);
            }
        }
        public IEnumerable<Nodo<T>> RecorridoPostOrder(Nodo<T> nodo)
        {

            if (nodo != null)
            {
                RecorridoPostOrder(nodo.Izquierda);
                RecorridoPostOrder(nodo.Derecha);
                yield return nodo;

            }
        }

    }
}
}
