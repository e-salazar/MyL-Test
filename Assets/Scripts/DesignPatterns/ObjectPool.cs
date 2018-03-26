using Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns {
    public class ObjectPool<TObject> where TObject : MonoBehaviour, IPoolable<TObject> {
        public Stack<TObject> pool;
        public TObject prefab;
        private Transform parent;
        private bool isUI;

        public ObjectPool(int initialSize, TObject prefab, Transform parent) {
            pool = new Stack<TObject>();
            this.prefab = prefab;
            this.parent = parent;
            if(prefab.GetComponent<RectTransform>() == null) {
                this.isUI = false;
            }
            else {
                this.isUI = true;
            }
            for(int i = 0; i < initialSize; i++) {
                TObject objeto = Object.Instantiate(prefab.gameObject).GetComponent<TObject>();
                objeto.parentPool = this;
                objeto.Reset();
                objeto.gameObject.SetActive(false);
                objeto.transform.SetParent(parent, !isUI);
                pool.Push(objeto);
            }
        }

        public TObject New() {
            TObject objeto;
            if(pool.Count > 0) {
                objeto = pool.Pop();
            }
            else {
                objeto = Object.Instantiate(prefab.gameObject).GetComponent<TObject>();
                objeto.parentPool = this;
                //objeto.Reset();//Este reset se ejecuta luego del Awake, por lo que si hay alguna configuración que se establezca en el Awake, se pierde en el Reset (por ejemplo un escuchador de evento puesto en el Awake)
            }
            objeto.gameObject.SetActive(false);
            //objeto.gameObject.SetActive(true);

            return objeto;
        }
        public void Store(TObject objeto) {
            objeto.Reset();
            objeto.gameObject.SetActive(false);
            objeto.transform.SetParent(parent, !isUI);
            pool.Push(objeto);
        }
    }
}