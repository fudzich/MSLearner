using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASLDictionary : MonoBehaviour
{
    [SerializeField]
    private GameObject a;

    [SerializeField]
    private GameObject b;

    [SerializeField]
    private GameObject c;

    [SerializeField]
    private GameObject d;

    [SerializeField]
    private GameObject e;

    [SerializeField]
    private GameObject f;

    [SerializeField]
    private GameObject g;

    [SerializeField]
    private GameObject h;

    [SerializeField]
    private GameObject i;

    [SerializeField]
    private GameObject j;

    [SerializeField]
    private GameObject k;

    [SerializeField]
    private GameObject l;

    [SerializeField]
    private GameObject m;

    [SerializeField]
    private GameObject n;

    [SerializeField]
    private GameObject o;

    [SerializeField]
    private GameObject p;

    [SerializeField]
    private GameObject q;

    [SerializeField]
    private GameObject r;

    [SerializeField]
    private GameObject s;

    [SerializeField]
    private GameObject t;

    [SerializeField]
    private GameObject u;

    [SerializeField]
    private GameObject v;

    [SerializeField]
    private GameObject w;

    [SerializeField]
    private GameObject x;

    [SerializeField]
    private GameObject y;

    [SerializeField]
    private GameObject z;

    public Dictionary<string, List<GameObject>> ASLwords = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        ASLwords["apple"] = new List<GameObject> { a, p, p, l, e };
        ASLwords["book"] = new List<GameObject> { b, o, o, k };
        ASLwords["cat"] = new List<GameObject> { c, a, t };
        ASLwords["dog"] = new List<GameObject> { d, o, g };
        ASLwords["hello"] = new List<GameObject> { h, e, l, l, o };
        ASLwords["thank"] = new List<GameObject> { t, h, a, n, k };
        ASLwords["please"] = new List<GameObject> { p, l, e, a, s, e };
        ASLwords["goodbye"] = new List<GameObject> { g, o, o, d, b, y, e };
        ASLwords["yes"] = new List<GameObject> { y, e, s };
        ASLwords["no"] = new List<GameObject> { n, o };
        
    }
}
