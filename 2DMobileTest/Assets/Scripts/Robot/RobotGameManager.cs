using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGameManager : MonoBehaviour
{

    public GameObject head;
    public GameObject body;
    public GameObject leg;
    public GameObject handL;
    public GameObject handR;

    public GameObject mid;

    private List<GameObject> allparts = new List<GameObject>();

    private List<GameObject> inGameParts = new List<GameObject>();

    private float spawnTime1,spawnTime2,spawnTime3,spawnTime4,spawnTime5;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        allparts.Add(handL);
        allparts.Add(handR);
        allparts.Add(leg);
        allparts = shuffle(allparts);
        spawnTime1 = Random.Range(1,2);
        spawnTime2 = Random.Range(2.5f,3.5f);
        spawnTime3 = Random.Range(3.5f,4f);
        spawnTime4 = Random.Range(4.5f,5.3f);
        spawnTime5 = Random.Range(5.8f,6.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        customStart();
    }

    void customStart()
    {
    
        StartCoroutine(spawn(allparts[0],spawnTime1));
        StartCoroutine(spawn(allparts[1],spawnTime2));
        StartCoroutine(spawn(allparts[2],spawnTime3));
        StartCoroutine(spawn(allparts[3],spawnTime4));
        StartCoroutine(spawn(allparts[4],spawnTime5)); 
        
        Invoke("checkIfWin", 15);
        
    }


    IEnumerator spawn(GameObject part, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        spawnParts(part);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnParts(GameObject part)
    {
        GameObject current = Instantiate(part,(new Vector3()), transform.rotation);
        inGameParts.Add(current);
        Parts script = part.GetComponent<Parts>();
    }

    List<GameObject> shuffle(List<GameObject> List)
    {
        List<GameObject> newallparts = new List<GameObject>();
        int n = List.Count;
        newallparts.Add(body);        
        while(n > 0)
        {
            int k = Random.Range(0,n);
            GameObject temp = List[k];
            List.Remove(temp);
            newallparts.Add(temp);
            n = List.Count;        
        }
        newallparts.Add(head);
        return newallparts;
    }

    bool checkIfWin()
    {
        foreach (var item in inGameParts)
        {
        Parts script = item.GetComponent<Parts>();
            if(script.isInRange == false)
            {
                return false;
            }
        }
        return true;
    }
}
