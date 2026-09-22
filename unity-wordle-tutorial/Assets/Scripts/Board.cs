using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    //private static readonly KeyCode[] SUPPORTED_KEYS = new KeyCode[]
    //{
    //    KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F,
    //    KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L,
    //    KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R,
    //    KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
    //    KeyCode.Y, KeyCode.Z,
    //};

    private static readonly string[] SEPARATOR = new string[] { "\r\n", "\r", "\n" };

    private Row[] rows;
    private int rowIndex;
    private int columnIndex;

    private string[] solutions;
    private string[] validWords;
    private string word;

    [Header("Tiles")]
    public Tile.State emptyState;
    public Tile.State occupiedState;
    public Tile.State correctState;
    public Tile.State wrongSpotState;
    public Tile.State incorrectState;

    [Header("UI")]
    public TextMeshProUGUI invalidWordText;
    public Button newWordButton;
    public Button tryAgainButton;

    private void Awake()
    {
        rows = GetComponentsInChildren<Row>();
    }

    private void Start()
    {
        LoadData();
        NewGame();
    }

    public void NewGame()
    {
        ClearBoard();
        SetRandomWord();

        enabled = true;
    }

    public void TryAgain()
    {
        ClearBoard();

        enabled = true;
    }

    private void LoadData()
    {
        TextAsset textFile = Resources.Load("official_wordle_all") as TextAsset;
        //validWords = textFile.text.Split('\n');
        validWords = textFile.text.Split(SEPARATOR, System.StringSplitOptions.None);

        textFile = Resources.Load("official_wordle_common") as TextAsset;
        //solutions = textFile.text.Split('\n');
        solutions = textFile.text.Split(SEPARATOR, System.StringSplitOptions.None);
    }

    private void SetRandomWord()
    {
        word = solutions[Random.Range(0, solutions.Length)];
        word = word.ToLower().Trim();
    }

    //private void Update()
    //{
    //    for (int i = 0; i < SUPPORTED_KEYS.Length; i++ )
    //    {
    //        if (Input.GetKeyDown(SUPPORTED_KEYS[i]))
    //        {
    //            rows[rowIndex].tiles[columnIndex].SetLetter((char)SUPPORTED_KEYS[i]);
    //            columnIndex++;
    //            break;
    //        }
    //    }
    //}

    private void Update()
    {
        Row currentRow = rows[rowIndex];

        if (Keyboard.current == null) return;

        //if (Input.GetKeyDown(KeyCode.Backspace))
        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            columnIndex = Mathf.Max(columnIndex - 1, 0);
            currentRow.tiles[columnIndex].SetLetter('\0');
            currentRow.tiles[columnIndex].SetState(emptyState);

            invalidWordText.gameObject.SetActive(false);
        }
        else if (columnIndex >= currentRow.tiles.Length)
        {
            //if (Input.GetKeyDown(KeyCode.Return))
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame)
            {
                SubmitRow(currentRow);
            }
        }
        else
        {
            foreach (var key in Keyboard.current.allKeys)
            {
                if (key.wasPressedThisFrame)
                {
                    string keyName = key.displayName;
                 
                    if (keyName.Length == 1 && char.IsLetter(keyName[0]))
                    {
                        char letter = char.ToLower(keyName[0]);
                     
                        if (letter >= 'a' && letter <= 'z')
                        {
                            currentRow.tiles[columnIndex].SetLetter(letter);
                            currentRow.tiles[columnIndex].SetState(occupiedState);
                            columnIndex++;
                            break;
                        }
                    }
                }
            }
        }
    }

    private void SubmitRow(Row row)
    {
        if (!IsValidWord(row.word))
        {
            invalidWordText.gameObject.SetActive(true);
            return;
        }
        
        string remaining = word;

        for (int i = 0; i < row.tiles.Length; i++)
        {
            Tile tile = row.tiles[i];

            if (tile.letter == word[i])
            {
                tile.SetState(correctState);

                remaining = remaining.Remove(i, 1);
                remaining = remaining.Insert(i, " ");
            } else if (!word.Contains(tile.letter))
            {
                tile.SetState(incorrectState);
            }
        }

        for(int i = 0; i < row.tiles.Length; i++)
        {
            Tile tile = row.tiles[i];

            if (tile.state != correctState && tile.state != incorrectState)
            {
                if(remaining.Contains(tile.letter))
                {
                    tile.SetState(wrongSpotState);

                    int index = remaining.IndexOf(tile.letter);
                    remaining = remaining.Remove(index, 1);
                    remaining = remaining.Insert(index, " ");
                } else
                {
                    tile.SetState(incorrectState);
                }
            }
        }

        if (HasWon(row))
        {
            enabled = false;
        }
             
        rowIndex++;
        columnIndex = 0;

        if (rowIndex >= rows.Length)
        {
            enabled = false;
        }
    }

    private void ClearBoard()
    {
        for (int row = 0; row < rows.Length; row++)
        {
            for (int col = 0; col < rows[row].tiles.Length; col++)
            {
                rows[row].tiles[col].SetLetter('\0');
                rows[row].tiles[col].SetState(emptyState);
            }
        }

        rowIndex = 0;
        columnIndex = 0;
    }

    private bool IsValidWord(string word)
    {
        for (int i = 0; i < validWords.Length; i++)
        {
            //if (validWords[i] == word)
            if (string.Equals(word, validWords[i], System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private bool HasWon(Row row)
    {
        for (int i = 0; i < row.tiles.Length; i++)
        {
            if (row.tiles[i].state != correctState)
            {
                return false;
            }
        }

        return true;
    }

    private void OnEnable()
    {
        tryAgainButton.gameObject.SetActive(false);
        newWordButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        tryAgainButton.gameObject.SetActive(true);
        newWordButton.gameObject.SetActive(true);
    }
}


