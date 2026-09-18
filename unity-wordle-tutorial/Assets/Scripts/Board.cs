using UnityEngine;
using UnityEngine.InputSystem;

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

    private Row[] rows;

    private int rowIndex;
    private int columnIndex;

    private void Awake()
    {
        rows = GetComponentsInChildren<Row>();
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
        if (columnIndex >= rows[rowIndex].tiles.Length)
        {
            //submit row...
        }
        else
        {
            if (Keyboard.current != null)
            {
                foreach (var key in Keyboard.current.allKeys)
                {
                    if (key.wasPressedThisFrame)
                    {
                        string keyName = key.displayName;

                        // check that it's a letter from 'A' to 'Z'
                        if (keyName.Length == 1 && char.IsLetter(keyName[0]))
                        {
                            char letter = char.ToUpper(keyName[0]);

                            if (letter >= 'A' && letter <= 'Z')
                            {
                                rows[rowIndex].tiles[columnIndex].SetLetter(letter);
                                columnIndex++;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

}
