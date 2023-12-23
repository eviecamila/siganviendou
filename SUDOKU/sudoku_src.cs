using System;
public class sudoku_src
{
    public char[][] _grid;

    public sudoku_src(char[][] grid)
    {
        _grid = grid;
    }

    public bool IsValid()
    {
        return filassonvalidas() 
            && columnassonvalidas() 
            && cuadradosvalidos();
    }

    bool filassonvalidas()
    {
        return validar(getnumfila);
    }

    bool columnassonvalidas()
    {
        return validar(getnumcolumna);
    }

    bool cuadradosvalidos()
    {
        return validar(getnumcuadrante);
    }

    bool validar(Func<int, int, int> numeros)
    {
        for (var fila = 0; fila < 9; fila++)
        {
            var numerosusados = new bool[10];
            for (var columna = 0; columna < 9; columna++)
            {
                var num = numeros(fila, columna);
                if (num != 0 && numerosusados[num] == true)
                {
                    return false;
                }

                numerosusados[num] = true;
            }
        }

        return true;
    }

    int getnumfila(int fila, int columna)
    {
        return Tonum(_grid[fila][columna]);
    }

    int getnumcolumna(int fila, int columna)
    {
        return Tonum(_grid[columna][fila]);
    }

    int getnumcuadrante(int bloque, int index)
    {
        var columna = 3 * (bloque % 3) + index % 3;
        var fila = index / 3 + 3 * (bloque / 3);
        return Tonum(_grid[fila][columna]);
    }

    int Tonum(char c)
    {
        if (c == ' ')
            return 0;
        return (int)(c - '0');
    }
}