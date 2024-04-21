using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle_Of_Tanks_Lib.GameObjects;
using Battle_Of_Tanks_Lib.GameObjectFactories;

namespace Battle_Of_Tanks_Lib
{
    public static class MapManager
    {
        public static string[,] Reed(string filePath)
        {
            string[,] array = null;
            if (File.Exists(filePath))
            {
                // Читаем файл построчно
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int rowCount = 0;
                    int colCount = 0;

                    // Определяем количество строк и столбцов в файле
                    while ((line = reader.ReadLine()) != null)
                    {
                        rowCount++;
                        string[] values = line.Split('\t');
                        colCount = Math.Max(colCount, values.Length);
                    }

                    // Создаем двумерный массив для хранения значений
                    array = new string[rowCount, colCount];

                    // Снова открываем файл для считывания значений
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    int i = 0;

                    // Считываем и сохраняем значения в массив
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split('\t');
                        for (int j = 0; j < values.Length; j++)
                        {
                            array[i, j] = values[j];
                        }
                        i++;
                    }
                }
            }
            else
            {
                Debug.WriteLine("Файл не найден");
            }

            return array;
        }
        public static List<GameObject> Generate(string[,] objectDatas, int WindowWidth, int WindowHeight)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            (int Width, int Height) unit = (WindowWidth / objectDatas.GetLength(1), WindowHeight / objectDatas.GetLength(0));
            (int X, int Y) pos = (0, 0);
            for (int i = 0; i < objectDatas.GetLength(0); i++)
            {
                for (int j = 0;j < objectDatas.GetLength(1); j++)
                {
                    if (objectDatas[i, j] != "0")
                    {
                        GameObjectFactory gameObjectFactory = GameObjectFactory.GetFactory
                            (
                                objectDatas[i,j],
                                new Rectangle
                                (
                                    new Point
                                    (
                                        pos.X,
                                        pos.Y
                                    ),
                                    unit.Width,
                                    unit.Height
                                )
                            );
                        gameObjects.Add(gameObjectFactory.GetObject());
                    }
                    pos.X += unit.Width;
                }
                pos.X = 0;
                pos.Y += unit.Height;
            }

            return gameObjects;
        }
    }
}
