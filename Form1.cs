using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labirintusHázi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int startX; //kezdőpozíció
        int startY; //végpozíció

        bool sikeresimport = false;

        int[][] maze; //az alaplabirintus

        int[][] maze_themaux; //a themaux labirintus felépítése
        int[][] maze_toThemDir; //a themaux labirintus utolsó irányainak tárolására
        int[][] maze_lasThemDir;

        int[][] maze_rekurziv; //a rekurzív (mélységi) labirintus felépítése

        int[][] maze_random; //a random labirintus felépítése

        int[][] maze_szelessegi; //a szélességi labirintus felépítése

        bool finished_themaux = true;
        bool finished_themaux_succes = true;
        bool finished_rekurziv = true;
        bool finished_random = true;
        bool finished_szelessegi = true;

        Int64 steps_themaux;
        Int64 steps_rekurziv;
        Int64 steps_random;
        Int64 steps_szelessegi;

        int megjelenitett = 0; //a megjelenített 0-alap 1-themaux 2-rekurziv 3-random 4-szelessegi

        Graphics grafika;
        Bitmap tartalom;

        Random r;
        int thX = 0;
        int thY = 0;

        int delay = 100;

        private void biztos()
        {
            const string message =
        "Biztosan importált labirintus nélkül indítasz keresést? Bizonyos keresési módoknál ez végtelen ciklushoz vezet";
            const string caption = "Futtatás importálás nélkül?";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ... 
            if (result == DialogResult.No)
            {
                importLab();
            }
        }

        private void elfelejt(int[][] ezt)
        {
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    ezt[i][j] = 6;
                }
            }
        }

        private void szelessegi() // 7 épp ott, 6 még nincs kifejtve, >=11 már bejárt, 0 van út arra, 1 fal van ott
        {
            int steps = 11; //a kifejtés száma 11-es eltolással, hogy ne zavarjam meg a számokat
            bool nincsujanapalatt = false; //megadja, hogy jutottam e előrébb a körben
            while (!finished_szelessegi) //amíg el nem jut a célig
            {

                if (delay != 999)
                {
                    lépésszámToolStripMenuItem.Text = "Lépések száma: " + Convert.ToString(steps_szelessegi);
                    Megjelenit(maze_szelessegi);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(delay);                    
                }
                nincsujanapalatt = false;               

                for (int i = 0; i < 40; i++)
                {
                    for (int j = 0; j < 40; j++) //itt a belső részt fejtem ki
                    {
                        if (maze_szelessegi[i][j] == 7)
                        {
                            steps_szelessegi++;
                            
                            if (i < 39)
                            {                                
                                    if (maze_szelessegi[i + 1][j] == 6) //és még nincs kifejtve valami által már
                                    {
                                        maze_szelessegi[i + 1][j] = maze[i + 1][j]; //kifejtem a kifejthető elemeket
                                    }                                
                            }

                            if (i > 0)
                            {  
                                    if (maze_szelessegi[i - 1][j] == 6) //és még nincs kifejtve valami által már
                                    {
                                        maze_szelessegi[i - 1][j] = maze[i - 1][j]; //kifejtem a kifejthető elemeket
                                    }
                            }

                            if (j > 0)
                            {
                                    if (maze_szelessegi[i][j - 1] == 6) //és még nincs kifejtve valami által már
                                    {
                                        maze_szelessegi[i][j - 1] = maze[i][j - 1]; //kifejtem a kifejthető elemeket
                                    }
                            }

                            if (j < 39)
                            {
                                    if (maze_szelessegi[i][j + 1] == 6) //és még nincs kifejtve valami által már
                                    {
                                        maze_szelessegi[i][j + 1] = maze[i][j + 1]; //kifejtem a kifejthető elemeket
                                    }
                            }
                        }
                    }
                }                

                for (int i = 0; i < 40; i++) //megnézem, hogy kifejtettem e a célt
                {
                    for (int j = 0; j < 40; j++)
                    {
                        if (maze_szelessegi[i][j] == 9)
                        {
                            finished_szelessegi = true;

                            for (int m = 0; m < 40; m++)
                            {
                                for (int z = 0; z < 40; z++)
                                {
                                    if (maze_szelessegi[m][z] == 7)
                                    {
                                        maze_szelessegi[m][z] = steps;
                                    }
                                    if (maze_szelessegi[m][z] == 0)
                                    {
                                        maze_szelessegi[m][z] = 7;
                                    }
                                }
                            }

                            int x = i;
                            int y = j;
                            while ( x != startX || y != startY)
                            {
                                if (x != 0)
                                {
                                    if (maze_szelessegi[x - 1][y] == steps)
                                    {
                                        maze_szelessegi[x - 1][y] = 5;
                                        steps--;
                                        x = x - 1;
                                    }
                                }
                                if (x != 39)
                                {
                                    if (maze_szelessegi[x + 1][y] == steps)
                                    {
                                        maze_szelessegi[x + 1][y] = 5;
                                        steps--;
                                        x = x + 1;
                                    }
                                }
                                if (y != 0)
                                {
                                    if (maze_szelessegi[x][y-1] == steps)
                                    {
                                        maze_szelessegi[x][y - 1] = 5;
                                        steps--;
                                        y = y - 1;
                                    }
                                }
                                if (y != 39)
                                {
                                    if (maze_szelessegi[x][y+1] == steps)
                                    {
                                        maze_szelessegi[x][y+1] = 5;
                                        steps--;
                                        y = y + 1;
                                    }
                                }                                
                            }

                            Megjelenit(maze_szelessegi);
                            MessageBox.Show("Szélességi keresés befejezve");
                        }                        
                    }
                }

                if (!finished_szelessegi) //ha nem fejtettem ki a célt, akkor a következő körhöz előkészítem az adatokat
                {
                    for (int i = 0; i < 40; i++)
                    {
                        for (int j = 0; j < 40; j++)
                        {
                            if (maze_szelessegi[i][j] == 7)
                            {
                                maze_szelessegi[i][j] = steps;
                            }
                            if (maze_szelessegi[i][j] == 0)
                            {
                                maze_szelessegi[i][j] = 7;
                                nincsujanapalatt = true;
                            }
                        }
                    }
                    steps++;
                    if (!nincsujanapalatt)//ha nincsujanapalatt, akkor meghalt a keresés, nincs új kifejthető elem, végtelen ciklust kapok
                    {
                        finished_szelessegi = true;
                        Megjelenit(maze_szelessegi);
                        MessageBox.Show("Szélességi keresés elbukott");
                    }
                }
                //következő körre előkészítés vége, ami eddig ki volt fejtve, nyugtázom, ami nem azzal folytatom amit elkezdtem
                
                

            }//megtaláltam a célt ha ideértem
        }

        private void random() //7 éppen ott, 0 út, 1 fal
        {
            int irany = 0;
            int helyzetX = 0;
            int helyzetY = 0;

            while (!finished_random)
            {
                steps_random++;
                if (steps_random > 5000000)
                {
                    finished_random = true;
                }
                if (delay != 999)
                {
                    lépésszámToolStripMenuItem.Text = "Lépések száma: " + Convert.ToString(steps_random);
                    Megjelenit(maze_random);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(delay);
                }

                
                for (int i = 0; i < 40; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        if (maze_random[i][j] == 7)
                        {
                            helyzetX = i;
                            helyzetY = j;
                            if (i < 39)
                            {
                                {
                                    maze_random[i + 1][j] = maze[i + 1][j]; //kifejtem a kifejthető elemeket
                                    if (maze_random[i + 1][j] == 9)
                                    {
                                        finished_random = true;
                                    }
                                }
                            }

                            if (i > 0)
                            {
                                {
                                    maze_random[i - 1][j] = maze[i - 1][j]; //kifejtem a kifejthető elemeket
                                    if (maze_random[i - 1][j] == 9)
                                    {
                                        finished_random = true;
                                    }
                                }
                            }

                            if (j > 0)
                            {
                                {
                                    maze_random[i][j - 1] = maze[i][j - 1]; //kifejtem a kifejthető elemeket
                                    if (maze_random[i][j - 1] == 9)
                                    {
                                        finished_random = true;
                                    }
                                }
                            }

                            if (j < 39)
                            {
                                {
                                    {
                                        maze_random[i][j + 1] = maze[i][j + 1]; //kifejtem a kifejthető elemeket
                                        if (maze_random[i][j + 1] == 9)
                                        {
                                            finished_random = true;
                                        }
                                    }
                                }
                            }
                        }

                        
                    }
                }

                if (!finished_random)
                {

                    irany = r.Next(10000) % 4;

                    if (irany == 0) //fel
                    {
                        if (helyzetY < 39)
                        {
                            if (maze_random[helyzetX][helyzetY + 1] == 0)
                            {
                                maze_random[helyzetX][helyzetY + 1] = 7;
                                maze_random[helyzetX][helyzetY] = 0;
                            }
                        }
                    }
                    if (irany == 1) //le
                    {
                        if (helyzetY > 0)
                        {
                            if (maze_random[helyzetX][helyzetY - 1] == 0)
                            {
                                maze_random[helyzetX][helyzetY - 1] = 7;
                                maze_random[helyzetX][helyzetY] = 0;
                            }
                        }
                    }
                    if (irany == 2) //jobbra
                    {
                        if (helyzetX < 39)
                        {
                            if (maze_random[helyzetX + 1][helyzetY] == 0)
                            {
                                maze_random[helyzetX + 1][helyzetY] = 7;
                                maze_random[helyzetX][helyzetY] = 0;
                            }
                        }
                    }
                    if (irany == 3) //balra
                    {
                        if (helyzetX > 0)
                        {
                            if (maze_random[helyzetX - 1][helyzetY] == 0)
                            {
                                maze_random[helyzetX - 1][helyzetY] = 7;
                                maze_random[helyzetX][helyzetY] = 0;
                            }
                        }
                    }
                }
                else
                {
                    Megjelenit(maze_random);
                    if (steps_random > 5000000)
                    {
                        MessageBox.Show("Véletlen keresés befejezve találat hiányában");
                    }
                    else
                    {
                        MessageBox.Show("Véletlen keresés befejezve");
                    }
                }//ha nincs vége, akkor átadom a terepet a következő körnek, és átlépek oda, ahova gondoltam, vagy épp sehova
            }//befejeződött
        } //

        bool rekurziv(int x, int y) // 0 út, 1 fal, 7 jelenleg kifejtés alatt, 5 már kifejtve és jó
        {
            steps_rekurziv++;
            if (delay != 999)
            {                
                lépésszámToolStripMenuItem.Text = "Lépések száma: " + Convert.ToString(steps_rekurziv);
                int pivot = maze_rekurziv[x][y];
                maze_rekurziv[x][y] = 7;
                Megjelenit(maze_rekurziv);
                Application.DoEvents();
                System.Threading.Thread.Sleep(delay);
                maze_rekurziv[x][y] = pivot;
            }

            if (maze[x][y] == 9) { maze_rekurziv[x][y] = 9;  return true; }
            if (maze[x][y] == 1 || maze_rekurziv[x][y] == 11 || maze_rekurziv[x][y] == 5) return false;

            if (maze_rekurziv[x][y] == 6)
            {
                maze_rekurziv[x][y] = 11;
            }
            

            if (x != 0)
            {
                if (rekurziv(x - 1, y))
                {
                    maze_rekurziv[x][y] = 5;
                    return true;
                }                
            }

            if (x != 39)
            {
                if (rekurziv(x + 1, y))
                {
                    maze_rekurziv[x][y] = 5;
                    return true;
                }
            }

            if (y != 0)
            {
                if (rekurziv(x, y-1))
                {
                    maze_rekurziv[x][y] = 5;
                    return true;
                }
            }

            if (y != 39)
            {
                if (rekurziv(x, y+1))
                {
                    maze_rekurziv[x][y] = 5;
                    return true;
                }
            }

            return false;
        }

        private void themaux() //6 még nincs kifejtve, >10 jártam ott, 
        {
            thX = startX;
            thY = startY;
            int i;
            int j;
            int direction = 5;
            int directionlast = 7;

            while (!finished_themaux)
            {
                steps_themaux++;
                if (delay != 999)
                {
                    
                    lépésszámToolStripMenuItem.Text = "Lépések száma: " + Convert.ToString(steps_themaux);
                    int pivot = maze_themaux[thX][thY];
                    maze_themaux[thX][thY] = 7;                    
                    Megjelenit(maze_themaux); 
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(delay);
                    maze_themaux[thX][thY] = pivot;
                }

                i = thX;
                j = thY;
                direction = 0;
/*kivenni*/     int loli = maze_lasThemDir[i][j];
                if (maze_themaux[i][j] >= 10000)
                {
                }
                else
                {
                    maze_themaux[i][j] = 10000;
                }
                

                if (i < 39)
                {
                    if (maze_themaux[i + 1][j] == 6) //és még nincs kifejtve valami által már
                    {
                        maze_themaux[i + 1][j] = maze[i + 1][j]; //kifejtem a kifejthető elemeket                        
                    }

                    if (maze_themaux[i + 1][j] == 1 || maze_themaux[i + 1][j] == 11111) //ha fal van arra, vagy lehetetlen út
                    {
                        if (maze_themaux[i][j] / 1000 % 10 == 0)
                        {
                            maze_themaux[i][j] += 1000; //arra már nem mehetünk
                        }
                    }
                    else if (maze_themaux[i + 1][j] == 0)
                    {
                        direction += 5;
                    }

                    if (maze_themaux[i + 1][j] == 9)
                    {
                        finished_themaux = true;
                        finished_themaux_succes = true;
                    }
                }
                else //ha eleve a szélén vagyunk
                {
                    if (maze_themaux[i][j] / 1000 % 10 == 0)
                    {
                        maze_themaux[i][j] += 1000; //nem mehetünk szélebbre
                    }
                }

                if (i > 0)
                {
                    if (maze_themaux[i - 1][j] == 6) //és még nincs kifejtve valami által már
                    {
                        maze_themaux[i - 1][j] = maze[i - 1][j]; //kifejtem a kifejthető elemeket
                    }
                    if (maze_themaux[i - 1][j] == 1 || maze_themaux[i - 1][j] == 11111) //ha arra fal van, vagy lehetetlen út
                    {
                        if (maze_themaux[i][j] / 10 % 10 == 0)
                        {
                            maze_themaux[i][j] += 10;
                        }
                    }
                    else if (maze_themaux[i - 1][j] == 0)
                    {
                        direction += 7;
                    }
                    if (maze_themaux[i - 1][j] == 9)
                    {
                        finished_themaux = true;
                        finished_themaux_succes = true;
                    }
                }
                else
                {
                    if (maze_themaux[i][j] / 10 % 10 == 0)
                    {
                        maze_themaux[i][j] += 10;
                    }
                }

                if (j > 0)
                {
                    if (maze_themaux[i][j - 1] == 6) //és még nincs kifejtve valami által már
                    {
                        maze_themaux[i][j - 1] = maze[i][j - 1]; //kifejtem a kifejthető elemeket
                    }
                    if (maze_themaux[i][j - 1] == 1 || maze_themaux[i][j - 1] == 11111)
                    {
                        if (maze_themaux[i][j] / 1 % 10 == 0)
                        {
                            maze_themaux[i][j] += 1;
                        }
                    }
                    else if (maze_themaux[i][j - 1] == 0)
                    {
                        direction += 8;
                    }
                    if (maze_themaux[i][j - 1] == 9)
                    {
                        finished_themaux = true;
                        finished_themaux_succes = true;
                    }
                }
                else
                {
                    if (maze_themaux[i][j] / 1 % 10 == 0)
                    {
                        maze_themaux[i][j] += 1;
                    }
                }

                if (j < 39)
                {
                    if (maze_themaux[i][j + 1] == 6) //és még nincs kifejtve valami által már
                    {
                        maze_themaux[i][j + 1] = maze[i][j + 1]; //kifejtem a kifejthető elemeket
                    }
                    if (maze_themaux[i][j + 1] == 1 || maze_themaux[i][j + 1] == 11111)
                    {
                        if (maze_themaux[i][j] / 100 % 10 == 0)
                        {
                            maze_themaux[i][j] += 100;
                        }
                    }
                    else if (maze_themaux[i][j + 1] == 0)
                    {
                        direction += 6;
                    }
                    if (maze_themaux[i][j + 1] == 9)
                    {
                        finished_themaux = true;
                        finished_themaux_succes = true;
                    }
                }
                else
                {
                    if (maze_themaux[i][j] / 100 % 10 == 0)
                    {
                        maze_themaux[i][j] += 100;
                    }
                }

/*ha megállna*/ if (maze_themaux[i][j] == 11111) //nincs lehetőség egyik irányba se menni (pontosabban értelmetlen)
                {//ha megszorulna véletlenül
                    while (maze_themaux[thX][thY] == 11111 && !finished_themaux)
                    {
                        if (delay != 999)
                        {
                            int pivot = maze_themaux[thX][thY];
                            maze_themaux[thX][thY] = 7;
                            Megjelenit(maze_themaux);
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(delay);
                            maze_themaux[thX][thY] = pivot;
                        }
                        
                        if (thX == startX && thY == startY)
                        {
                            finished_themaux = true;
                            MessageBox.Show("A Thémaux megoldás elbukott");
                        }
        /*ivenni*/      int lol = maze_lasThemDir[thX][thY]; //kivenni!!!
                        if (maze_lasThemDir[thX][thY] >= 10) 
                        { 
                            maze_lasThemDir[thX][thY] = maze_lasThemDir[thX][thY] / 10;
                            maze_lasThemDir[thX][thY]--;
                        }
                        if (maze_lasThemDir[thX][thY] % 10 == 0)
                        {
                            thX--;
                        }
                        else if (maze_lasThemDir[thX][thY] %10 == 1)
                        {
                            thY--;
                        }
                        else if (maze_lasThemDir[thX][thY] %10 == 2)
                        {
                            thX++;
                        }
                        else if (maze_lasThemDir[thX][thY] %10 == 3)
                        {
                            thY++;
                        }
                            /*
                        else if (maze_toThemDir[thX][thY] %10 == 0)
                        {
                            thX--;
                        }
                        else if (maze_toThemDir[thX][thY] %10 == 1)
                        {
                            thY--;
                        }
                        else if (maze_toThemDir[thX][thY] %10 == 2)
                        {
                            thX++;
                        }
                        else if (maze_toThemDir[thX][thY] %10 == 3)
                        {
                            thY++;
                        }
                             */
                        
                    }                    
                }

/*iránybeli döntések*/
                if (!finished_themaux)
                {
                    if (direction == 0 )
                    {                        
                        direction = r.Next(10000) % 4;
                    }
                    else if (direction >= 11)
                    {
                        if (i < 39)
                        {
                            if (maze_themaux[i + 1][j] == 0)
                            {
                                direction = 0;
                            }
                        }
                        if (i > 0)
                        {
                            if (maze_themaux[i - 1][j] == 0)
                            {
                                direction = 2;
                            }
                        }
                        if (j > 0)
                        {
                            if (maze_themaux[i][j - 1] == 0)
                            {
                                direction = 3;
                            }
                        }
                        if (j < 39)
                        {
                            if (maze_themaux[i][j + 1] == 0)
                            {
                                direction = 1;
                            }
                        }
                        else
                        {
                            if (((maze_themaux[i][j] / 1000) % 10) == 0)
                            {
                                direction = 0;
                            }
                            if (((maze_themaux[i][j] / 100) % 10) == 0)
                            {
                                direction = 1;
                            }
                            if (((maze_themaux[i][j] / 10) % 10) == 0)
                            {
                                direction = 2;
                            }
                            if (((maze_themaux[i][j] / 1) % 10) == 0)
                            {
                                direction = 3;
                            }
                        }
                    }
                    else
                    {
                        direction = direction - 5;
                    }
//Elmozdulás irányok alapján
                    if (direction == 0 && ((maze_themaux[i][j] / 1000) % 10) == 0 &&directionlast != 0)
                    {
                       
                            maze_themaux[i][j] += 1000;
                            thX++;
                            directionlast = 2;
                            if (maze_toThemDir[i + 1][j] == 6)
                            {
                                maze_toThemDir[i + 1][j] = 0;
                            }
                            if (maze_lasThemDir[i + 1][j] == 6)
                            {
                                maze_lasThemDir[i + 1][j] = 0;
                            }
                            {
                                maze_lasThemDir[i + 1][j] =maze_lasThemDir[i + 1][j] + 1;
                                maze_lasThemDir[i + 1][j] *= 10;
                            }
                        


                    }
                    else if (direction == 1 && ((maze_themaux[i][j] / 100) % 10) == 0 && directionlast != 1)
                    {
                        
                            maze_themaux[i][j] += 100;
                            thY++;
                            directionlast = 3;
                            if (maze_toThemDir[i][j + 1] == 6)
                            {
                                maze_toThemDir[i][j + 1] = 1;
                            }
                            if (maze_lasThemDir[i][j+ 1] == 6)
                            {
                                maze_lasThemDir[i][j + 1] = 0;
                            }
                            {
                                maze_lasThemDir[i][j + 1] =  maze_lasThemDir[i][j + 1] + 2;
                                maze_lasThemDir[i][j + 1] *= 10;
                            }
                    }
                    else if (direction == 2 && ((maze_themaux[i][j] / 10) % 10) == 0 && directionlast != 2)
                    {
                        
                            maze_themaux[i][j] += 10;
                            thX--;
                            directionlast = 0;
                            if (maze_toThemDir[i - 1][j] == 6)
                            {
                                maze_toThemDir[i - 1][j] = 2;
                            }
                            if (maze_lasThemDir[i - 1][j] == 6)
                            {
                                maze_lasThemDir[i - 1][j] = 0;
                            }
                            {
                                maze_lasThemDir[i - 1][j] =  maze_lasThemDir[i - 1][j] + 3;
                                maze_lasThemDir[i - 1][j] *= 10;
                            }
                    }
                    else if (direction == 3 && ((maze_themaux[i][j] / 1) % 10) == 0 && directionlast != 3)
                    {
                        
                            maze_themaux[i][j] += 1;
                            thY--;
                            directionlast = 1;
                            if (maze_toThemDir[i][j - 1] == 6)
                            {
                                maze_toThemDir[i][j - 1] = 3;
                            }
                            if (maze_lasThemDir[i][j - 1] == 6)
                            {
                                maze_lasThemDir[i][j - 1] = 0;
                            }
                            {
                                maze_lasThemDir[i][j - 1] = maze_lasThemDir[i][j - 1]+ 4;
                                maze_lasThemDir[i][j - 1] *= 10;
                            }
                    }
                    else if (direction == 0 && ((maze_themaux[i][j] / 1000) % 10) == 0)
                    {
                        maze_themaux[i][j] += 1000;
                        thX++;
                        directionlast = 2;
                        if (maze_toThemDir[i + 1][j] == 6)
                        {
                            maze_toThemDir[i + 1][j] = 0;
                        }
                        if (maze_lasThemDir[i + 1][j] == 6)
                        {
                            maze_lasThemDir[i + 1][j] = 0;
                        }
                        {
                            maze_lasThemDir[i + 1][j] = maze_lasThemDir[i + 1][j]+ 1;
                            maze_lasThemDir[i + 1][j] *= 10;
                        }
                    }
                    else if (direction == 1 && ((maze_themaux[i][j] / 100) % 10) == 0)
                    {
                        maze_themaux[i][j] += 100;
                        thY++;
                        directionlast = 3;
                        if (maze_toThemDir[i][j + 1] == 6)
                        {
                            maze_toThemDir[i][j + 1] = 1;
                        }
                        if (maze_lasThemDir[i][j + 1] == 6)
                        {
                            maze_lasThemDir[i][j + 1] = 0;
                        }
                        {
                            maze_lasThemDir[i][j + 1] = maze_lasThemDir[i][j + 1]+ 2;
                            maze_lasThemDir[i][j + 1] *= 10;
                        }
                    }
                    else if (direction == 2 && ((maze_themaux[i][j] / 10) % 10) == 0)
                    {
                        maze_themaux[i][j] += 10;
                        thX--;
                        directionlast = 0;
                        if (maze_toThemDir[i - 1][j] == 6)
                        {
                            maze_toThemDir[i - 1][j] = 2;
                        }
                        if (maze_lasThemDir[i - 1][j] == 6)
                        {
                            maze_lasThemDir[i - 1][j] = 0;
                        }
                        {
                            maze_lasThemDir[i - 1][j] = maze_lasThemDir[i - 1][j]+ 3;
                            maze_lasThemDir[i - 1][j] *= 10;
                        }
                    }
                    else if (direction == 3 && ((maze_themaux[i][j] / 1) % 10) == 0)
                    {
                        maze_themaux[i][j] += 1;
                        thY--;
                        directionlast = 1;
                        if (maze_toThemDir[i][j - 1] == 6)
                        {
                            maze_toThemDir[i][j - 1] = 3;
                        }
                        if (maze_lasThemDir[i][j - 1] == 6)
                        {
                            maze_lasThemDir[i][j - 1] = 0;
                        }
                        {
                            maze_lasThemDir[i][j - 1] = maze_lasThemDir[i][j - 1] + 4;
                            maze_lasThemDir[i][j - 1] *= 10;
                        }
                    }
                }
//Ha sikeresen befejeződött
                else if (finished_themaux_succes)
                {

                    while (thX != startX || thY != startY)
                    {
                        maze_themaux[thX][thY] = 5;
                        if (delay != 999)
                        {
                            int pivot = maze_themaux[thX][thY];
                            maze_themaux[thX][thY] = 7;
                            Megjelenit(maze_themaux);
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(delay);
                            maze_themaux[thX][thY] = pivot;
                        }                       

                        if (maze_toThemDir[thX][thY] == 0)
                        {
                            thX--;
                        }
                        else if (maze_toThemDir[thX][thY] == 1)
                        {
                            thY--;
                        }
                        else if (maze_toThemDir[thX][thY] == 2)
                        {
                            thX++;
                        }
                        else if (maze_toThemDir[thX][thY] == 3)
                        {
                            thY++;
                        }
                    }
                    maze_themaux[thX][thY] = 5;
                    

                    Megjelenit(maze_themaux);
                    MessageBox.Show("A Thémaux algoritmus befejezve");
                }



            }
                   


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            lépésszámToolStripMenuItem.Text = "Lépések száma";
            r = new Random();

            maze = new int[40][];
            maze_themaux = new int[40][];
            maze_random = new int[40][];
            maze_rekurziv = new int[40][];
            maze_szelessegi = new int[40][];
            maze_toThemDir = new int[40][];
            maze_lasThemDir = new int[40][];

            for (int i = 0; i < 40; i++)
            {
                maze[i] = new int[40];
                maze_themaux[i] = new int[40];
                maze_random[i] = new int[40];
                maze_rekurziv[i] = new int[40];
                maze_szelessegi[i] = new int[40];
                maze_toThemDir[i] = new int[40];
                maze_lasThemDir[i] = new int[40];
            }

            for (int i = 0; i < 40; i++)
            {
                for (int k = 0; k < 40; k++)
                {
                    maze_themaux[i][k] = 6;
                    maze_rekurziv[i][k] = 6;
                    maze_random[i][k] = 6;
                    maze_szelessegi[i][k] = 6;
                    maze_toThemDir[i][k] = 6;
                    maze_lasThemDir[i][k] = 6;
                }
            }
            this.Text = "Labirintus feltérképező";
            Form1_Resize(sender, e);
        }

        void importLab()
        {
            openFileDialog1.Filter = "CSV fájl (*.csv) |*.csv|TXT fájl (*.txt)|*.txt|Minden fájl (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);


                string flow = sr.ReadToEnd();
                sr.Close();

                flow = flow.Substring(flow.IndexOf('\n') + 1);
                flow = flow.Substring(flow.IndexOf(';') + 1);
                for (int i = 0; i < 40; i++)
                {                    
                    for (int k = 0; k < 40; k++)
                    {
                        //maze[i][k] = Convert.ToInt32(Convert.ToString(flow.Substring(0,flow.IndexOf(';'))));
                        maze[i][k] = Convert.ToInt32(Convert.ToString(flow[0]));
                        flow = flow.Substring(flow.IndexOf(';') + 1);

                        if (maze[i][k] == 4)
                        {
                            startX = i;
                            startY = k;
                        }

                        //MessageBox.Show(Convert.ToString(maze[i][k]));
                    }
                    //flow = flow.Substring(flow.IndexOf('\n') + 1);

                } sikeresimport = true;
                elfelejt(maze_toThemDir);
                elfelejt(maze_random);
                elfelejt(maze_rekurziv);
                elfelejt(maze_szelessegi);
                elfelejt(maze_themaux);
                elfelejt(maze_lasThemDir);
                Megjelenit(maze);


            }

        }

        public void megrajzol(int[][] ezt)
        {
            int CELLSIZE = pictureBox1.Width / 40;

            int xsize = 40 * CELLSIZE;
            int ysize = 40 * CELLSIZE;

            tartalom = new Bitmap(xsize, ysize);
            grafika = Graphics.FromImage(tartalom);

            grafika.Clear(Color.Aqua);

            Pen fal = new Pen(Color.Black,CELLSIZE);
            Pen ut = new Pen(Color.White,CELLSIZE);
            Pen start = new Pen(Color.Red, CELLSIZE);
            Pen fin = new Pen(Color.Green, CELLSIZE);
            Pen bejart = new Pen(Color.Gray, CELLSIZE);
            Pen emberke = new Pen(Color.Purple, CELLSIZE);
            Pen nyerout = new Pen(Color.Green, CELLSIZE);
            Pen homaly = new Pen(Color.Brown, CELLSIZE);
            
            for (int i = 0; i < 40; ++i)
                for (int j = 0; j < 40; ++j)
                {
                    int room = ezt[j][i];

                    if (room == 0)
                    {
                        grafika.DrawLine(ut, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    if (room == 1)
                    {
                        grafika.DrawLine(fal, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    if (room == 4)
                    {
                        grafika.DrawLine(start, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    if (room == 9)
                    {
                        grafika.DrawLine(fin, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    if (room == 7)
                    {
                        grafika.DrawLine(emberke, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    if (room > 10)
                    {
                        grafika.DrawLine(bejart, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    if (room == 5)
                    {
                        grafika.DrawLine(nyerout, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    if (room == 6)
                    {
                        grafika.DrawLine(homaly, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    if (room == 11111)
                    {
                        grafika.DrawLine(start, i * CELLSIZE, j * CELLSIZE + CELLSIZE / 2, (i + 1) * CELLSIZE, j * CELLSIZE + CELLSIZE / 2);
                    }
                    
                }
            
        }

        public void Megjelenit(int[][] ezt)
        {
            //bmp.Save("bitmapom.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            //a bitmap létrejön
            //a megjelenített 0-alap 1-themaux 2-rekurziv 3-random 4-szelessegi
            if (ezt == maze)
            {
                megjelenitett = 0;
                lépésszámToolStripMenuItem.Text = "Lépések száma";
            }
            else if (ezt == maze_themaux)
            {
                megjelenitett = 1;
                lépésszámToolStripMenuItem.Text = "Lépések száma: " + Convert.ToString(steps_themaux);
            }
            else if (ezt == maze_rekurziv)
            {
                megjelenitett = 2;
                lépésszámToolStripMenuItem.Text = "Lépések száma: " + Convert.ToString(steps_rekurziv);
            }
            else if (ezt == maze_random)
            {
                megjelenitett = 3;
                lépésszámToolStripMenuItem.Text = "Lépések száma: " + Convert.ToString(steps_random);
            }
            else if (ezt == maze_szelessegi)
            {
                megjelenitett = 4;
                lépésszámToolStripMenuItem.Text = "Lépések száma: " + Convert.ToString(steps_szelessegi);
            }

            megrajzol(ezt);
            pictureBox1.Image = tartalom;
        }

        private void importálásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importLab();
        }

        private void megoldásSzélességiKeresésselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!sikeresimport)
            {
                biztos();
            }
            steps_szelessegi = 0;
            finished_szelessegi = false;
            elfelejt(maze_szelessegi);
            maze_szelessegi[startX][startY] = 7;
            szelessegi();
            
        }

        private void megoldásRekurzívmélységiKeresésselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            steps_rekurziv = 0;
            if (!sikeresimport)
            {
                biztos();
            }
            finished_rekurziv = false;
            elfelejt(maze_rekurziv);
            finished_rekurziv = rekurziv(startX,startY);
            if (finished_rekurziv)
            {
                Megjelenit(maze_rekurziv); MessageBox.Show("Rekurzív mélységi keresés befejezve");
            }
            else
            {
                Megjelenit(maze_rekurziv); MessageBox.Show("Rekurzív mélységi keresés elbukott");
            }
            
        }

        private void megoldásVéletlenKeresésselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            steps_random = 0;
            if (!sikeresimport)
            {
                biztos();
            }
            elfelejt(maze_random);
            finished_random = false;
            maze_random[startX][startY] = 7;
            random();
            
        }

        private void megoldásThémauxKeresésévelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            steps_themaux = 0;
            if (!sikeresimport)
            {
                biztos();
            }
            elfelejt(maze_toThemDir);
            elfelejt(maze_themaux);
            elfelejt(maze_lasThemDir);
            finished_themaux = false;
            finished_themaux_succes = false;
            themaux();
            
        }

        private void alapLabirintusToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Megjelenit(maze);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {            
            pictureBox1.Height = this.Height - 100;
            pictureBox1.Width = this.Width - 50;

            if (pictureBox1.Height < pictureBox1.Width)
            {
                pictureBox1.Width = pictureBox1.Height;
            }
            else
            {
                pictureBox1.Height = pictureBox1.Width;
            }
            //a megjelenített 0-alap 1-themaux 2-rekurziv 3-random 4-szelessegi
            switch (megjelenitett)
            {
                case 0: { Megjelenit(maze); break; }
                case 1: { Megjelenit(maze_themaux); break; }
                case 2: { Megjelenit(maze_rekurziv); break; }
                case 3: { Megjelenit(maze_random); break; }
                case 4: { Megjelenit(maze_szelessegi); break; }
            }
            
            
            if (this.Height < this.Width)
            {
                this.Height = this.Width;
            }
            else
            {
                this.Width = this.Height;
            }

        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Megjelenit(maze_random);
        }

        private void themauxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Megjelenit(maze_themaux);
        }

        private void szélességiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Megjelenit(maze_szelessegi);
        }

        private void rekurzívmélységiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Megjelenit(maze_rekurziv);
        }

        private void nincsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delay = 999;
        }

        private void lassúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delay = 1000;
        }

        private void láthatóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delay = 300;
        }

        private void gyorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delay = 100;
        }

        private void eszméletlenGyorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delay = 10;
        }

        private void jelképesenLassítvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delay = 1;
        }

        private void keresésMegállításaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!finished_random || !finished_rekurziv || !finished_szelessegi || !finished_themaux)
            {
                const string message =
            "Biztosan leállítod a keresést?";
                const string caption = "Keresés leállítása?";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    finished_themaux = true;
                    finished_szelessegi = true;
                    finished_rekurziv = true;
                    finished_random = true;
                }
            }
            
        }

        private void lassítatlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delay = 0;
        }

        private void térképMentéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                saveFileDialog1.Filter = "Bitmap fájl (*.bmp) |*.bmp|Jpeg fájl (*.jpeg)|*.jpeg|Minden fájl (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.IndexOf('.'))=="bmp")
                    {
                        tartalom.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    else if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.IndexOf('.')) == "jpeg")
                    {
                        tartalom.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        tartalom.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All credits goes to Adam Benke");
        }


        
    }
}
