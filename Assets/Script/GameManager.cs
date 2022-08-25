using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStart = false;

    public static GameManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    IntArr IntArr15(int[,]a, int num)
    {
        return new IntArr(new int[] { a[num, 0], a[num, 1], a[num, 2], a[num, 3], a[num, 4], a[num, 5], a[num, 6], a[num, 7], a[num, 8], a[num, 9], a[num, 10], a[num, 11], a[num, 12], a[num, 13], a[num, 14] });
    }

    [SerializeField]
    GameObject S;
    [SerializeField]
    GameObject E;


    int SplitArray(bool x,float mouseP)//x축인지 y축인지, 마우스포인트위치
    {

        float a, b, c, d;
        int e;
        a = x ? S.transform.position.x : S.transform.position.y;
        b = x ? E.transform.position.x : E.transform.position.y;
        e = x ? 15 : 9;

        c = b - a;
        d = c / e;//4/*나눌만큼*/;

        if(mouseP >= a)//마우스 포인트가 에디터 창 최소값보다 크다면
        {
            for (int i = 0; i < e;i++)
            {
                a = a + d;
                if (mouseP <= a)
                {
                    return i;
                }
            }
        }

        return -1;

    }

    #region 스테이지 배열
    int[,] stage1 = new int[9, 15] { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                  {1, 0, 0, 0, 5, 0, 0, 2, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1 },
                                  {1, 0, 0, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

    int[,] stage2 = new int[9, 15] { {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                                  {0, 1, 5, 0, 1, 1, 0, 0, 1, 1, 3, 0, 6, 1, 0 },
                                  {0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0 },
                                  {0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0 },
                                  {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                                  {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                                  {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                                  {0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                                  {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 } };

    int[,] stage3 = new int[9, 15] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                  {1, 5, 0, 0, 2, 0, 4, 0, 0, 0, 0, 6, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 4, 0, 0, 1 },
                                  {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };

    int[,] stage4 = new int[9, 15] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                  {1, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };

    int[,] stage5 = new int[9, 15] { {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                  {1, 5, 0, 8, 0, 0, 0, 1, 0, 0, 0, 6, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                  {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };


    int[,] stage6 = new int[9, 15] { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

    #endregion



    [SerializeField]
    GameObject[] BlockPrefab;


    [SerializeField]
    GameObject[] Blocks;

    int EditorChooseBlock;

    private void EditDraw()
    {
        Vector3 vec = new Vector3(0,0,0);
        float xa, xb, xc, xd;
        float ya, yb, yc, yd;

        xa = S.transform.position.x;
        xb = E.transform.position.x;
        xc = xb - xa;
        xd = xc / 15;

        ya = S.transform.position.y;
        yb = E.transform.position.y;
        yc = yb - ya;
        yd = yc / 9;

        xa += xd / 2;
        ya += yd / 2;

        Transform[] b = Blocks[0].GetComponentsInChildren<Transform>();
        for (int i = 1; i < b.Length; i++)
        {
            Destroy(b[i].gameObject);
        }


        for (int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 15; j++)
            {
                vec = new Vector3(xa+xd*j,ya+yd*i,0);
                for (int k = 1; k <= 8; k++) //0 빈공간  1 블럭  2 고정공격블럭  3 총공격블럭  4 중력블럭  5 시작문  6 나가는문  7 점프업 물약  8 더블점프 물약
                {
                    if (stage6[i, j] == k)
                    {
                        Instantiate(BlockPrefab[k-1], vec, Quaternion.identity).transform.parent = Blocks[0].transform;
                    }
                }
                
            }
        }
    }

    void StageDraw(int[,] stage)
    {
        Vector3 vec = new Vector3(0, 0, 0);
        //-7  -4  7  4

        int a = -7, b = -4;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                vec = new Vector3(a + j, b + i, 0);
                for (int k = 1; k <= 8; k++) //0 빈공간  1 블럭  2 고정공격블럭  3 총공격블럭  4 중력블럭  5 시작문  6 나가는문  7 점프업 물약  8 더블점프 물약
                {
                    if (stage[i, j] == k && (k == 1))
                    {
                        Instantiate(BlockPrefab[k - 1], vec, Quaternion.identity).transform.parent = Blocks[0].transform;
                    }

                    if (stage[i, j] == k && (k == 2 || k == 3 || k == 4 || k == 5 || k == 6 || k == 7 || k == 8))
                    {
                        Instantiate(BlockPrefab[k - 1], vec, Quaternion.identity).transform.parent = Blocks[1].transform;
                    }
                }
                                         
            }
        }
    }


    public void EditorLoad()
    {
        GameData loadData = SaveSystem.Load("data");

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                stage6[i, j] = loadData.blocks[i].intArr[j];
            }
        }
    }
    void EditorSave()
    {
        GameData character = new GameData();
        character.blocks = new IntArr[] { IntArr15(stage6, 0), IntArr15(stage6, 1), IntArr15(stage6, 2), IntArr15(stage6, 3), IntArr15(stage6, 4), IntArr15(stage6, 5), IntArr15(stage6, 6), IntArr15(stage6, 7), IntArr15(stage6, 8) };

        SaveSystem.Save(character, "data");
    }
    

    void Eraser()
    {
        int num = 0;
        while (num < 2) 
        {

            Transform[] b = Blocks[num].GetComponentsInChildren<Transform>();
            for (int i = 1; i < b.Length; i++)
            {
                Destroy(b[i].gameObject);
            }
            num++;
        }
    }

    void SingleBlock(int EditorChooseBlock)//에디터에서 플레이어나 보물상자는 하나만 있게 하기 위해서 캐릭터나 보물상자를 만들면 기존에 있던것이 사라지고 만들어 진다
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                if (stage6[i, j] == EditorChooseBlock)
                {
                    stage6[i, j] = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);

        Debug.Log("X"+SplitArray(true,pos.x));
        Debug.Log("Y" + SplitArray(false, pos.y));


        if (Input.GetMouseButtonDown(0) && isEditorMode)
        {
            if(SplitArray(true, pos.x) != -1 && SplitArray(false, pos.y) != -1)
            {
                if(EditorChooseBlock == 5 || EditorChooseBlock == 6)
                {
                    SingleBlock(EditorChooseBlock);
                }
                stage6[SplitArray(false, pos.y), SplitArray(true, pos.x)] = EditorChooseBlock;
            }
            
            EditDraw();
        }




        if (Input.GetMouseButtonDown(0) && gameStart == false)
        {
            gameStart = true;
        }


    }


    [SerializeField]
    GameObject StartPanel;
    [SerializeField]
    GameObject StagePanel;
    [SerializeField]
    GameObject GamePanel;
    [SerializeField]
    GameObject EditorPanel;
    [SerializeField]
    GameObject DeadPanel;
    [SerializeField]
    GameObject ClearPanel;



    [SerializeField]
    GameObject OptionButton;
    [SerializeField]
    GameObject OptionPanel;

    [SerializeField]
    GameObject[] EditorMode;


    [HideInInspector]
    public int CurrentStage = 0;

    bool isEditorMode = false;

    public void ToStartBtn()
    {
        StartPanel.SetActive(false);
        StagePanel.SetActive(true);
    }

    public void SelectStageBtn(int num)
    {
        CurrentStage = num;
        Eraser();
        StageDraw(num == 1 ? stage1 : num == 2 ? stage2 : num == 3 ? stage3 : num == 4? stage4 : num == 5? stage5 : stage6);
        StagePanel.SetActive(false);
        GamePanel.SetActive(true);
        OptionButton.SetActive(true);

        gameStart = false;
    }



    public void OptionBtn()
    {
        Time.timeScale = OptionPanel.activeSelf ? 1 : 0;
        OptionPanel.SetActive(!OptionPanel.activeSelf);
    }

    


    public void HomeBtn()
    {
        Time.timeScale = 1;
        gameStart = false;

        StagePanel.SetActive(true);
        GamePanel.SetActive(false);
        EditorPanel.SetActive(false);
        DeadPanel.SetActive(false);
        ClearPanel.SetActive(false);

        OptionButton.SetActive(false);
        OptionPanel.SetActive(false);
    }

    public void RestartBtn()
    {
        Time.timeScale = 1;
        gameStart = false;

        SelectStageBtn(CurrentStage);

        OptionPanel.SetActive(false);

        DeadPanel.SetActive(false);
        ClearPanel.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Dead()
    {
        Time.timeScale = 0;
        DeadPanel.SetActive(true);
    }

    public void Clear()
    {
        Time.timeScale = 0;
        ClearPanel.SetActive(true);
    }

    public void EditorModeBtn()
    {
        Eraser();
        isEditorMode = true;
        EditorMode[0].SetActive(true);
        EditorMode[1].SetActive(true);
        StagePanel.SetActive(false);
        EditorLoad();
        EditDraw();
        GamePanel.SetActive(true);
        EditorChooseBlock = 1;
        Time.timeScale = 0;
    }

    public void EditorChooseBtn(int num)
    {
        if(num == 10)
        {
            isEditorMode = false;
            EditorSave();

            EditorMode[0].SetActive(false);
            EditorMode[1].SetActive(false);
            

            HomeBtn();

            return;
        }
        EditorChooseBlock = num;

    }


    public void TestBtn()
    {
        //PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage")+1);
        PlayerPrefs.DeleteAll();
    }
}
