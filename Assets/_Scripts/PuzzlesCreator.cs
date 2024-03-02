using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class PuzzlesCreator : MonoBehaviour
    {
        [SerializeField] private Texture2D puzzleImage;
        [SerializeField] private int puzzlePiecesX = 4;
        [SerializeField] private int puzzlePiecesY = 4;

        [SerializeField] private GameObject puzzlePiecePrefab;
        
        public List<GameObject> Puzzles { get; private set; } = new List<GameObject>();
        
        private void Start()
        {
            GeneratePuzzle(16);
        }

        public void GeneratePuzzle(float puzzlePiececCount)
        {
            foreach (var puzzle in Puzzles)
            {
                Destroy(puzzle);    
            }
            
            if(puzzlePiececCount <= 0 || puzzlePiececCount % 2 != 0) return;
            
            // Получаем размеры каждого пазла
            int pieceWidth = puzzleImage.width / puzzlePiecesX;
            int pieceHeight = puzzleImage.height / puzzlePiecesY;

            // Разделяем картинку на пазлы
            for (int i = 0; i < (int)puzzlePiececCount/2; i++)
            {
                for (int j = 0; j < (int)puzzlePiecesY/2; j++)
                {
                    // Вырезаем кусок из оригинальной картинки
                    Texture2D pieceTexture = new Texture2D(pieceWidth, pieceHeight);
                    pieceTexture.SetPixels(puzzleImage.GetPixels(i * pieceWidth, j * pieceHeight, pieceWidth, pieceHeight));
                    pieceTexture.Apply();
                    
                    // Создаем пазл
                    GameObject puzzlePiece = Instantiate(puzzlePiecePrefab, new Vector3(i, j, 0), Quaternion.identity);
                    puzzlePiece.transform.parent = transform;
                    puzzlePiece.transform.localScale = new Vector3(1, 1, 1);
                    puzzlePiece.GetComponent<Renderer>().material.mainTexture = pieceTexture;
                    
                    Puzzles.Add(puzzlePiece);
                }
            }
        }
    }
}