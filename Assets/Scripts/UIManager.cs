using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class UIManager : MonoBehaviour
{
    public Text timerText;
    public Text infoText;
    public GamePlayDialog GameDialog;
    [SerializeField ] private InputActionManager inputActionManager;

    private float timerValue = 0;
    private int collectedInfo;

    public int lossScene;

    public Toggle alligatorCheck;
    public Toggle toadCheck;
    public Toggle rabbitCheck;
    public Toggle bassCheck;
    public Toggle catCheck;
    public Toggle pythonCheck;
    public Toggle oilCheck;
    public Toggle litterCheck;
    public Toggle mangroovesCheck;

    public Slider alligatorMeter;
    public Slider toadMeter;
    public Slider rabbitMeter;
    public Slider bassMeter;
    public Slider catMeter;
    public Slider pythonMeter;
    public Text statusText;

    private int CurrentalligatorCount;
    private int CurrenttoadCount;
    private int CurrentrabbitCount;
    private int CurrentbassCount;
    private int CurrentcatCount;
    private int CurrentpythonCount;

    private int alligatorCountDay;
    private int toadCountDay;
    private int rabbitCountDay;
    private int bassCountDay;
    private int catCountDay;
    private int pythonCountDay;

    private int alligatorCountNight;
    private int toadCountNight;
    private int rabbitCountNight;
    private int bassCountNight;
    private int catCountNight;
    private int pythonCountNight;

    private int alligatorCountHurricane;
    private int toadCountHurricane;
    private int rabbitCountHurricane;
    private int bassCountHurricane;
    private int catCountHurricane;
    private int pythonCountHurricane;
    public static UIManager instance;

    //1 = danger 2 = warning 3 = neutral 4 = warning 5 = danger 

       public int setAligatorCount
       {
          get
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                return alligatorCountDay;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                return alligatorCountNight;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                return alligatorCountHurricane;
             }
             return CurrentalligatorCount;
          }
          set
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                alligatorCountDay = Mathf.Clamp(value, 0, 16);
                CurrentalligatorCount = alligatorCountDay;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                alligatorCountNight = Mathf.Clamp(value, 0, 16);
                CurrentalligatorCount = alligatorCountNight;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                alligatorCountHurricane = Mathf.Clamp(value, 0, 16);
                CurrentalligatorCount = alligatorCountHurricane;
                return;
             }
             CurrentalligatorCount = Mathf.Clamp(value, 0, 16);
          }
       }

       public int setToadCount
       {
          get
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                return toadCountDay;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                return toadCountNight;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                return toadCountHurricane;
             }
             return CurrenttoadCount;
          }
          set
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                toadCountDay = Mathf.Clamp(value, 0, 16);
                CurrenttoadCount = toadCountDay;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                toadCountNight = Mathf.Clamp(value, 0, 16);
                CurrenttoadCount = toadCountNight;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                toadCountHurricane = Mathf.Clamp(value, 0, 16);
                CurrenttoadCount = toadCountHurricane;
                return;
             }
             CurrenttoadCount = Mathf.Clamp(value, 0, 16);
          }
       }

       public int setRabbitCount
       {
          get
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                return rabbitCountDay;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                return rabbitCountNight;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                return rabbitCountHurricane;
             }
             return CurrentrabbitCount;
          }
          set
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                rabbitCountDay = Mathf.Clamp(value, 0, 16);
                CurrentrabbitCount = rabbitCountDay;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                rabbitCountNight = Mathf.Clamp(value, 0, 16);
                CurrentrabbitCount = rabbitCountNight;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                rabbitCountHurricane = Mathf.Clamp(value, 0, 16);
                CurrentrabbitCount = rabbitCountHurricane;
                return;
             }
             CurrentrabbitCount = Mathf.Clamp(value, 0, 16);
          }
       }

       public int setBassCount
       {
          get
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                return bassCountDay;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                return bassCountNight;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                return bassCountHurricane;
             }
             return CurrentbassCount;
          }
          set
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                bassCountDay = Mathf.Clamp(value, 0, 16);
                CurrentbassCount = bassCountDay;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                bassCountNight = Mathf.Clamp(value, 0, 16);
                CurrentbassCount = bassCountNight;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                bassCountHurricane = Mathf.Clamp(value, 0, 16);
                CurrentbassCount = bassCountHurricane;
                return;
             }
             CurrentbassCount = Mathf.Clamp(value, 0, 16);
          }
       }

       public int setCatCount
       {
          get
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                return catCountDay;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                return catCountNight;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                return catCountHurricane;
             }
             return CurrentcatCount;
          }
          set
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                catCountDay = Mathf.Clamp(value, 0, 16);
                CurrentcatCount = catCountDay;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                catCountNight = Mathf.Clamp(value, 0, 16);
                CurrentcatCount = catCountNight;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                catCountHurricane = Mathf.Clamp(value, 0, 16);
                CurrentcatCount = catCountHurricane;
                return;
             }
             CurrentcatCount = Mathf.Clamp(value, 0, 16);
          }
       }

       public int setPythonCount
       {
          get
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                return pythonCountDay;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                return pythonCountNight;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                return pythonCountHurricane;
             }
             return CurrentpythonCount;
          }
          set
          {
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TerrainTest")
             {
                pythonCountDay = Mathf.Clamp(value, 0, 16);
                CurrentpythonCount = pythonCountDay;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Night")
             {
                pythonCountNight = Mathf.Clamp(value, 0, 16);
                CurrentpythonCount = pythonCountNight;
                return;
             }
             if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hurricane")
             {
                pythonCountHurricane = Mathf.Clamp(value, 0, 16);
                CurrentpythonCount = pythonCountHurricane;
                return;
             }
             CurrentpythonCount = Mathf.Clamp(value, 0, 16);
          }
       }

       private bool onFirstLoadOfNight = false;
       private bool onFirstLoadOfHurricane = false;
       private bool onFirstLoadOfDay = false;

       public GameObject mainMenu;
       public GameObject animalMenu;
       public GameObject sceneMenu;
       public GameObject meterMenu;
       public GameObject finalMenu;
       private AnimalPool animalPool;
    private void Awake()
    {
        collectedInfo = 0;
        timerValue = 600;

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        

    }
    void Start()
    {
        SceneManager.sceneLoaded += setCorrectAnimalPopulation;
        animalPool = GameObject.FindGameObjectWithTag("Animal Pool").GetComponent<AnimalPool>();
        setAligatorCount = animalPool.aligators.Length;
        setToadCount = animalPool.toads.Length;
        setRabbitCount = animalPool.rabbits.Length;
        setBassCount = animalPool.bass.Length;
        setCatCount = animalPool.cats.Length;
        setPythonCount = animalPool.pythons.Length;
    }
    [HideInInspector]
    public int min = 0;
    public int sec = 0;
    private void Update()
    {
        timerValue -= Time.deltaTime;

        min = Mathf.FloorToInt(timerValue / 60);
        sec = Mathf.FloorToInt(timerValue % 60);
        timerText.text = "Time Left - " + string.Format("{0:00}:{1:00}", min, sec);

        infoText.text = collectedInfo.ToString() + "/9 Info Collected";
        alligatorMeter.value = setAligatorCount;
        toadMeter.value = setToadCount;
        rabbitMeter.value = setRabbitCount;
        bassMeter.value = setBassCount;
        catMeter.value = setCatCount;
        pythonMeter.value = setPythonCount;




       

        if (timerValue <= 0)
        {
            SceneManager.LoadScene(lossScene);
        }

        if (timerValue % 60 == 0)
        {
            //Destroy native animals\
            deSpawnBass();
            deSpawnAlligator();
            deSpawnRabbit();
            deSpawnToad();
        }


        



        // Adjust Animal Sliders according to value (5 states)

    }
    void FixedUpdate()
    {
        if(animalPool == null)
        {
            animalPool = GameObject.FindGameObjectWithTag("Animal Pool").GetComponent<AnimalPool>();
            return;
        }


        
        if(onFirstLoadOfHurricane == false && SceneManager.GetActiveScene().name == "Hurricane")
        {
             setAligatorCount = animalPool.returactiveAligator();
            setToadCount = animalPool.returactiveToad();
            setRabbitCount = animalPool.returactiveRabbit();
            setBassCount = animalPool.returactiveBass();
            setCatCount =   animalPool.returactiveCat();
            setPythonCount = animalPool.returactivePython();
            GameDialog.playerHurricaneSceneEntered();
            onFirstLoadOfHurricane = true;


        
        }
        if (onFirstLoadOfNight == false && SceneManager.GetActiveScene().name == "Night")
        {
            setAligatorCount = animalPool.returactiveAligator();
            setToadCount = animalPool.returactiveToad();
            setRabbitCount = animalPool.returactiveRabbit();
            setBassCount = animalPool.returactiveBass();
            setCatCount =   animalPool.returactiveCat();
            setPythonCount = animalPool.returactivePython();
            GameDialog.playerNightSceneEntered();
            onFirstLoadOfNight = true;

        }
        if (onFirstLoadOfDay == false && SceneManager.GetActiveScene().name == "TerrainTest")
        {

            setAligatorCount = animalPool.returactiveAligator();
            setToadCount = animalPool.returactiveToad();
            setRabbitCount = animalPool.returactiveRabbit();
            setBassCount = animalPool.returactiveBass();
            setCatCount =   animalPool.returactiveCat();
            setPythonCount = animalPool.returactivePython();
            Debug.Log("Day");
            Debug.Log(setAligatorCount);
            Debug.Log(setBassCount);
            Debug.Log(setRabbitCount);
            Debug.Log(setPythonCount);
            Debug.Log(setCatCount);
            Debug.Log(setToadCount);
            
            GameDialog.playerDaySceneEntered();
            onFirstLoadOfDay = true;


        }
        

        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            setToadCount +=1;
        }
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Animal Counts:");
                Debug.Log("Alligator Count: " + setAligatorCount);
                Debug.Log("Toad Count: " + setToadCount);
                Debug.Log("Rabbit Count: " + setRabbitCount);
                Debug.Log("Bass Count: " + setBassCount);
                Debug.Log("Cat Count: " + setCatCount);
                Debug.Log("Python Count: " + setPythonCount);
            }
        }
        RecieveChecklistInfo();
    }
    void setCorrectAnimalPopulation(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded " + scene.name);
        StartCoroutine(delayForAnimalpool(scene.name));
        
    }
    bool fixedDisabledInput = false;
    void LateUpdate()
    {
        if(SceneManager.GetActiveScene().name == "TerrainTest" && fixedDisabledInput == false)
        {
            inputActionManager.enabled = false;
            inputActionManager.enabled = true;
            fixedDisabledInput = true;
        }
        if(sec == 0 && min == 0)
        {
            SceneManager.LoadScene("Failed");
        }
    }
    IEnumerator delayForAnimalpool(string scene)
    {
        fixedDisabledInput = false;
        yield return new WaitForSeconds(2);
        if(scene == "TerrainTest" && onFirstLoadOfDay == true)
        {
            Debug.Log("Alligator Array Count: " + animalPool.aligators.Length);
            Debug.Log("Alligator Variable Count: " + alligatorCountDay);
            if(animalPool.aligators.Length != alligatorCountDay)
            {
                animalPool.SpawnAligator(alligatorCountDay); 
            }
            
            Debug.Log("Toad Array Count: " + animalPool.toads.Length);
            Debug.Log("Toad Variable Count: " + toadCountDay);
            if (animalPool.toads.Length != toadCountDay)
            {
                animalPool.SpawnToad(toadCountDay);
            }

            Debug.Log("Rabbit Array Count: " + animalPool.rabbits.Length);
            Debug.Log("Rabbit Variable Count: " + rabbitCountDay);
            if (animalPool.rabbits.Length != rabbitCountDay)
            {
                animalPool.SpawnRabbit(rabbitCountDay);
            }

            Debug.Log("Bass Array Count: " + animalPool.bass.Length);
            Debug.Log("Bass Variable Count: " + bassCountDay);
            if (animalPool.bass.Length != bassCountDay)
            {
                animalPool.SpawnBass(bassCountDay);
            }

            Debug.Log("Cat Array Count: " + animalPool.cats.Length);
            Debug.Log("Cat Variable Count: " + catCountDay);
            if (animalPool.cats.Length != catCountDay)
            {
                animalPool.SpawnCat(catCountDay);
            }

            Debug.Log("Python Array Count: " + animalPool.pythons.Length);
            Debug.Log("Python Variable Count: " + pythonCountDay);
            if (animalPool.pythons.Length != pythonCountDay)
            {
                animalPool.SpawnPython(pythonCountDay);
            }

        }
        if(scene == "Night" && onFirstLoadOfNight == true)
        {
            Debug.Log("Alligator Array Count: " + animalPool.aligators.Length);
            Debug.Log("Alligator Variable Count: " + alligatorCountNight);
            if (animalPool.aligators.Length != alligatorCountNight)
            {
                animalPool.SpawnAligator(alligatorCountNight);
            }

            Debug.Log("Toad Array Count: " + animalPool.toads.Length);
            Debug.Log("Toad Variable Count: " + toadCountNight);
            if (animalPool.toads.Length != toadCountNight)
            {
                animalPool.SpawnToad(toadCountNight);
            }

            Debug.Log("Rabbit Array Count: " + animalPool.rabbits.Length);
            Debug.Log("Rabbit Variable Count: " + rabbitCountNight);
            if (animalPool.rabbits.Length != rabbitCountNight)
            {
                animalPool.SpawnRabbit(rabbitCountNight);
            }

            Debug.Log("Bass Array Count: " + animalPool.bass.Length);
            Debug.Log("Bass Variable Count: " + bassCountNight);
            if (animalPool.bass.Length != bassCountNight)
            {
                animalPool.SpawnBass(bassCountNight);
            }

            Debug.Log("Cat Array Count: " + animalPool.cats.Length);
            Debug.Log("Cat Variable Count: " + catCountNight);
            if (animalPool.cats.Length != catCountNight)
            {
                animalPool.SpawnCat(catCountNight);
            }

            Debug.Log("Python Array Count: " + animalPool.pythons.Length);
            Debug.Log("Python Variable Count: " + pythonCountNight);
            if (animalPool.pythons.Length != pythonCountNight)
            {
                animalPool.SpawnPython(pythonCountNight);
            }

        }
        if(scene == "Hurricane" && onFirstLoadOfHurricane == true)
        {
            Debug.Log("Alligator Array Count: " + animalPool.aligators.Length);
            Debug.Log("Alligator Variable Count: " + alligatorCountHurricane);
            if (animalPool.aligators.Length != alligatorCountHurricane)
            {
                animalPool.SpawnAligator(alligatorCountHurricane);
            }

            Debug.Log("Toad Array Count: " + animalPool.toads.Length);
            Debug.Log("Toad Variable Count: " + toadCountHurricane);
            if (animalPool.toads.Length != toadCountHurricane)
            {
                animalPool.SpawnToad(toadCountHurricane);
            }

            Debug.Log("Rabbit Array Count: " + animalPool.rabbits.Length);
            Debug.Log("Rabbit Variable Count: " + rabbitCountHurricane);
            if (animalPool.rabbits.Length != rabbitCountHurricane)
            {
                animalPool.SpawnRabbit(rabbitCountHurricane);
            }

            Debug.Log("Bass Array Count: " + animalPool.bass.Length);
            Debug.Log("Bass Variable Count: " + bassCountHurricane);
            if (animalPool.bass.Length != bassCountHurricane)
            {
                animalPool.SpawnBass(bassCountHurricane);
            }

            Debug.Log("Cat Array Count: " + animalPool.cats.Length);
            Debug.Log("Cat Variable Count: " + catCountHurricane);
            if (animalPool.cats.Length != catCountHurricane)
            {
                animalPool.SpawnCat(catCountHurricane);
            }

            Debug.Log("Python Array Count: " + animalPool.pythons.Length);
            Debug.Log("Python Variable Count: " + pythonCountHurricane);
            if (animalPool.pythons.Length != pythonCountHurricane)
            {
                animalPool.SpawnPython(pythonCountHurricane);
            }

        }
    }
    void RecieveChecklistInfo()
    {
        // Recieve checklist info from Checklist.cs
        if(Checklist.Croc == true && alligatorCheck.isOn == false)
        {
            alligatorCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.toad == true && toadCheck.isOn == false)
        {
            toadCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.Rabbit == true && rabbitCheck.isOn == false)
        {
            rabbitCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.bass == true && bassCheck.isOn == false)
        {
            bassCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.cat == true && catCheck.isOn == false)
        {
            catCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.python == true && pythonCheck.isOn == false)
        {
            pythonCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.oil == true && oilCheck.isOn == false)
        {
            oilCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.litter == true && litterCheck.isOn == false)
        {
            litterCheck.isOn = true;
            collectedInfo++;
        }
        if(Checklist.mangroove == true && mangroovesCheck.isOn == false)
        {
            mangroovesCheck.isOn = true;
            collectedInfo++;
        }
        CheckIfChecklistIsDone();
    

    }
    private bool hasfoindEverything = false;
    void CheckIfChecklistIsDone()
    {
         if (collectedInfo == 9 && hasfoindEverything == false)
        {
            mainMenu.SetActive(false);
            animalMenu.SetActive(false);
            sceneMenu.SetActive(false);
            meterMenu.SetActive(false);
            finalMenu.SetActive(true);
            GameDialog.playObjectiveReached();
            hasfoindEverything = true;
        }
    }

    public void spawnAlligator()
    {
        animalPool.SpawnAligator();
        setAligatorCount += 1;
    }
    public void spawnToad()
    {
        animalPool.SpawnToad();
        setToadCount += 1;
    }
    public void spawnRabbit()
    {
        animalPool.SpawnRabbit();
        setRabbitCount += 1;
    }
    public void spawnBass()
    {
        animalPool.SpawnBass();
        setBassCount += 1;
    }
    public void spawnCat()
    {
        animalPool.SpawnCat();
        setCatCount += 1;
    }
    public void spawnPython()
    {
        animalPool.SpawnPython();
        setPythonCount += 1;
    }
    public void deSpawnAlligator()
    {
        animalPool.DeactiveAligator();
        setPythonCount -= 1;
    }
    public void deSpawnToad()
    {
        animalPool.DeactiveToad();
        setToadCount -= 1;
    }
    public void deSpawnRabbit()
    {
        animalPool.DeactiveRabbit();
        setRabbitCount -= 1;

    }
    public void deSpawnBass()
    {
        animalPool.DeactiveBass();
        setBassCount -= 1;
    }
    public void deSpawnCat()
    {
        animalPool.DeactiveCat();
        setCatCount -= 1;
    }
    public void deSpawnPython()
    {
        animalPool.DeactivePython();
        setPythonCount -= 1;
    }

    


}

