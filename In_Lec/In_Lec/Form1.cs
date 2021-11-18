using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace In_Lec
{
    public partial class Form1 : Form
    {
        Bitmap off;

        _3D_Model Cube = new _3D_Model();



        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.Load += new EventHandler(Form1_Load);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
   
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Rotation around x axis 
                case Keys.X:
                    Transformation.RotatX(Cube.L_3D_Pts, 1);
                    break;


                //TranslateX
                case Keys.Right:
                    Transformation.TranslateX(Cube.L_3D_Pts,5);
                    //Cube.TransX(5);
                    break;
                case Keys.Left:
                    Transformation.TranslateX(Cube.L_3D_Pts, -5);
                    //Cube.TransX(-5);
                    break;




                //TranslateY
                case Keys.Up:
                    Transformation.TranslateY(Cube.L_3D_Pts, -5);
                    //Cube.TransY(5);
                    break;
                case Keys.Down:
                    Transformation.TranslateY(Cube.L_3D_Pts, 5);
                    //Cube.TransY(-5);
                    break;


                //TranslateZ
                case Keys.Q:
                    Transformation.TranslateZ(Cube.L_3D_Pts, -5);
                    //Cube.TransZ(5);
                    break;
                case Keys.A:
                    Transformation.TranslateZ(Cube.L_3D_Pts, 5);
                    //Cube.TransZ(-5);
                    break;



                   //Transitional in all axis (X,Y,Z).
                case Keys.Space:
                    _3D_Point p1 = new _3D_Point(Cube.L_3D_Pts[Cube.L_Edges[2].i]);
                    _3D_Point p2 = new _3D_Point(Cube.L_3D_Pts[Cube.L_Edges[2].j]);
                    Transformation.RotateArbitrary(Cube.L_3D_Pts, p1, p2, 1);

                  //  Transformation.RotateArbitrary(Cube.L_3D_Pts, 5);
                    //Cube.RotateAroundEdge(2, 1);
                    break;
            }

            DrawDubble(this.CreateGraphics());
        }

        void CreateCube(_3D_Model M , float XS , float YS , float ZS)
        {
            float[] vert = 
                            { 
                                    300,300,300,
                                    300,300,500,
                                    100,300,500,
                                    100,300,300,
                                    300,100,300,
                                    300,100,500,
                                    100,100,500,
                                    100,100,300
                                
                            };


            _3D_Point pnn;
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                pnn = new _3D_Point(vert[j]+XS, vert[j + 1]+YS, vert[j + 2]+ZS);
                j += 3;
                M.AddPoint(pnn);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                5,6,
                                6,7,
                                7,4,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            j = 0;
            //Color[] cl = { Color.Red, Color.Yellow, Color.Black, Color.Blue };
            for (int i = 0; i < 12; i++)
            {
                M.AddEdge(Edges[j], Edges[j + 1], Color.Red); //cl[i % 4]);

                j += 2;
            }
        }

        void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width , this.ClientSize.Height);


            CreateCube(Cube , 100,100,0);



        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubble(e.Graphics);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);

            
            Cube.DrawYourSelf(g);
        }

        void DrawDubble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
