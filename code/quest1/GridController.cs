//摧毁防火墙游戏

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private bool[,] grid = new bool[5, 5]; // 存储方格状态的二维数组
    public Sprite Bad;
    public Sprite Good;
    public bool isGameSuccessful = false;
    void Start()
    {
        InitializeGrid(); // 初始化网格状态
        UpdateGridVisuals(); // 更新网格的视觉表示
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                // 点击到了一个方格，提取其坐标
                string[] coordinates = hit.collider.gameObject.name.Split('.');
                int x = int.Parse(coordinates[0]) - 1;
                int y = int.Parse(coordinates[1]) - 1;

                ToggleSquare(x, y); // 处理点击逻辑
            }
        }
    }

    void InitializeGrid()
    {
        // 设置所有方格为亮起状态
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                grid[i, j] = true;
            }
        }

        // 设置特定方格为暗状态
        grid[0, 0] = grid[0, 1] = grid[0, 3] = grid[0, 4] = false;
        grid[2, 0] = grid[2, 1] = grid[2, 3] = grid[2, 4] = false;
        grid[3, 4] = false;
        grid[4, 0] = grid[4, 1] = false;
    }

    void ToggleSquare(int x, int y)
    {
        // 切换被点击方格的状态
        grid[x, y] = !grid[x, y];

        // 切换相邻方格的状态
        ToggleAdjacentSquares(x, y);

        // 更新网格的视觉表示
        UpdateGridVisuals();

        // 检查游戏是否获胜
        CheckForWin();
    }

    void ToggleAdjacentSquares(int x, int y)
    {
        // 切换上方格的状态（如果存在）
        if (x > 0) grid[x - 1, y] = !grid[x - 1, y];
        // 切换下方格的状态（如果存在）
        if (x < 4) grid[x + 1, y] = !grid[x + 1, y];
        // 切换左方格的状态（如果存在）
        if (y > 0) grid[x, y - 1] = !grid[x, y - 1];
        // 切换右方格的状态（如果存在）
        if (y < 4) grid[x, y + 1] = !grid[x, y + 1];
    }

    void UpdateGridVisuals()
    {
        // 遍历每个方格并根据grid数组的状态更新它们的视觉表示

        for(int x = 0; x < 5; x++){

            for(int y = 0; y < 5; y++){

                GameObject square = GameObject.Find(x + 1 + "." + (y + 1));
                if(square != null){

                    SpriteRenderer sr = square.GetComponent<SpriteRenderer>();
                    if(sr != null){

                        sr.sprite = grid[x, y] ? Bad : Good;
                    }
                }
            }
        }
    }

    void CheckForWin()
    {
        // 检查是否所有方格都亮起
        foreach (bool state in grid)
        {
            if (!state) return; // 如果发现一个暗的方格，提早结束函数
        }
        isGameSuccessful = true;
        Debug.Log("游戏胜利！"); // 如果所有方格都亮起，游戏胜利
    }
}
