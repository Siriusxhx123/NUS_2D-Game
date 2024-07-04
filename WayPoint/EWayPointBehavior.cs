using UnityEngine;

public partial class EWayPointBehavior : MonoBehaviour 
{

    private int mNumHit = 0;
    private const int kHitsToDestroy = 4;
    private const float kWayPointEnergyLost = 0.8f;
    private bool mIsVisible = true;
    private GameObject mWayPointTemplate = null;

    private Vector2 mSpawnRegionMin, mSpawnRegionMax; 

    void Start ()
    { 
    }
	
	// Update is called once per frame
	void Update () 
    {
        SetVisible();
    }

    #region Trigger into chase or die
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerCheck(collision.gameObject);
    }

    private void TriggerCheck(GameObject g)
    {
        if (g.name == "Egg(Clone)")
        {
            mNumHit++;
            if (mNumHit < kHitsToDestroy)
            {
                Color c = GetComponent<Renderer>().material.color;
                c.a = c.a * kWayPointEnergyLost;
                GetComponent<Renderer>().material.color = c;
            } else
            {
                EThisWayPointIsHit();
            }
        }
    }

    private void EThisWayPointIsHit()
    {
        

        mWayPointTemplate = Resources.Load<GameObject>("Prefabs/E");

        // 确保生成边界有效
        mSpawnRegionMin = new Vector2(55, 55);
        mSpawnRegionMax = new Vector2(85, 85);

        EGenerateWayPoint();
        Destroy(gameObject);
    }
    #endregion  

    private void EGenerateWayPoint()
    { 
        GameObject p = GameObject.Instantiate(mWayPointTemplate) as GameObject;
        float x = Random.Range(mSpawnRegionMin.x, mSpawnRegionMax.x);
        float y = Random.Range(mSpawnRegionMin.y, mSpawnRegionMax.y);
        p.transform.position = new Vector3(x, y, 0f);
    }
    
    private void SetVisible()
    {
        Vector3 p = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.H))
        {
            mIsVisible = !mIsVisible;
        }

        if (mIsVisible)
        {
            p.z = 0;
        } 
        else
        {
            p.z = -20;
        }
        transform.localPosition = p;
    }  
}
