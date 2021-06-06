using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TresEnRaya
{

    public partial class Form1 : Form
    {
        const int CPU = 0;
        const int HUMANO = 1;
        public int Tipojugador1;
        public int Tipojugador2;
        public string nombrejugador1;
        public string nombrejugador2;
        const int turnojug1 = 1;
        const int turnojug2 = 2;
        public int turno = turnojug1;


        public string[,] tablero;
        //public int nposicion;

        //las coordenadas de la matriz//
        int[] PosicionFilas = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
        int[] PosicionColumnas = new int[] { 0, 1, 2, 0, 1, 2, 0, 1, 2 };

        public Form1()
        {
            InitializeComponent();
            tablero = new string[3, 3];


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void buttonIniciaPartida_Click(object sender, EventArgs e)
        {
            if ((radioButtonCPUJug1.Checked) == true)
            {
                Tipojugador1 = CPU;
            }
            else
            {
                Tipojugador1 = HUMANO;
            }
            if ((radioButtonCPUJug2.Checked) == true)
            {
                Tipojugador2 = CPU;
            }
            else
            {
                Tipojugador2 = HUMANO;
            }
            nombrejugador1 = textBoxNombreJug1.Text;
            nombrejugador2 = textBoxNombreJug2.Text;
            turno = turnojug1;
            label1.Text = "Empieza el jugador " + nombrejugador1;

            this.button1.Text = "";
            this.button2.Text = "";
            this.button3.Text = "";
            this.button4.Text = "";
            this.button5.Text = "";
            this.button6.Text = "";
            this.button7.Text = "";
            this.button8.Text = "";
            this.button9.Text = "";

            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = " ";
                }
            }

        }


        public bool MovimientoValido(int posicion)
        {
            if (tablero[PosicionFilas[posicion - 1], PosicionColumnas[posicion - 1]] == " ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean MueveJugador1(int posicion)
        {
            if (MovimientoValido(posicion))
            {
                tablero[PosicionFilas[posicion - 1], PosicionColumnas[posicion - 1]] = "X";
                return true;

            }
            else
            {
                return false;
            }
        }

        public Boolean MueveJugador2(int posicion)
        {
            if (MovimientoValido(posicion))
            {
                tablero[PosicionFilas[posicion - 1], PosicionColumnas[posicion - 1]] = "O";
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool QuedanMovimientos()
        {
            int i, j;
            int n = 0;

            for (i = 0; i < tablero.GetLength(0); i++)
            {
                for (j = 0; j < tablero.GetLength(1); j++)
                {
                    if (tablero[i, j] == " ")
                    {
                        n++;
                    }
                }
            }
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool GanaJugador1()
        {
            int i;
            int cont = 0;
            for (i = 0; i < 3; i++)
            {

                if ((tablero[i, 0] == "X" && tablero[i, 1] == "X" && tablero[i, 2] == "X"))
                {
                    cont++;
                }

                if ((tablero[0, i] == "X" && tablero[1, i] == "X" && tablero[2, i] == "X"))
                {
                    cont++;
                }
            }
            if ((tablero[0, 0] == "X" && tablero[1, 1] == "X" && tablero[2, 2] == "X"))
            {
                cont++;
            }
            if ((tablero[0, 2] == "X" && tablero[1, 1] == "X" && tablero[2, 0] == "X"))
            {
                cont++;
            }
            if (cont > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool GanaJugador2()
        {
            int i;
            int cont = 0;
            for (i = 0; i < 3; i++)
            {

                if ((tablero[i, 0] == "O" && tablero[i, 1] == "O" && tablero[i, 2] == "O"))
                {
                    cont++;
                }

                if ((tablero[0, i] == "O" && tablero[1, i] == "O" && tablero[2, i] == "O"))
                {
                    cont++;
                }
            }
            if ((tablero[0, 0] == "O" && tablero[1, 1] == "O" && tablero[2, 2] == "O"))
            {
                cont++;
            }
            if ((tablero[0, 2] == "O" && tablero[1, 1] == "O" && tablero[2, 0] == "O"))
            {
                cont++;
            }
            if (cont > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void comprueba_movimiento(int posicion)
        {

            if (turno == turnojug1)
            {
                if (MueveJugador1(posicion))
                {
                    switch (posicion)
                    {
                        case 1:
                            button1.Text = "X";
                            break;
                        case 2:
                            button2.Text = "X";
                            break;
                        case 3:
                            button3.Text = "X";
                            break;
                        case 4:
                            button4.Text = "X";
                            break;
                        case 5:
                            button5.Text = "X";
                            break;
                        case 6:
                            button6.Text = "X";
                            break;
                        case 7:
                            button7.Text = "X";
                            break;
                        case 8:
                            button8.Text = "X";
                            break;
                        case 9:
                            button9.Text = "X";
                            break;
                    }

                    turno = turnojug2;
                    label1.Text = "Es el turno del jugador " + nombrejugador2;
                    if (Tipojugador2 == CPU)
                    {
                        Random r = new Random();
                        int n = r.Next(1, 9);
                        EventArgs arg = new EventArgs();

                        switch (n)
                        {
                            case 1:
                                button1_Click(this, arg);
                                break;
                            case 2:
                                button2_Click_1(this, arg);
                                break;
                            case 3:
                                button3_Click_1(this, arg);
                                break;
                            case 4:
                                button4_Click_1(this, arg);
                                break;
                            case 5:
                                button5_Click_1(this, arg);
                                break;
                            case 6:
                                button6_Click_1(this, arg);
                                break;
                            case 7:
                                button7_Click_1(this, arg);
                                break;
                            case 8:
                                button8_Click_1(this, arg);
                                break;
                            case 9:
                                button9_Click_1(this, arg);
                                break;
                        }
                    }
                    if (!QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
                    {
                        label1.Text = "Partida en tablas";
                    }
                    else
                    {
                        if (GanaJugador1())
                        {
                            label1.Text = "Gana Jugador " + nombrejugador1;
                        }
                        else
                        {
                            if (GanaJugador2())
                            {
                                label1.Text = "Gana Jugador " + nombrejugador2;
                            }
                        }

                    }
                }
                else
                {
                    label1.Text = "Casilla ocupada, elige otra casilla";

                    if (Tipojugador1 == CPU)
                    {
                        Random r2 = new Random();
                        int n2 = r2.Next(1, 9);
                        EventArgs arg2 = new EventArgs();

                        switch (n2)
                        {
                            case 1:
                                button1_Click(this, arg2);
                                break;
                            case 2:
                                button2_Click_1(this, arg2);
                                break;
                            case 3:
                                button3_Click_1(this, arg2);
                                break;
                            case 4:
                                button4_Click_1(this, arg2);
                                break;
                            case 5:
                                button5_Click_1(this, arg2);
                                break;
                            case 6:
                                button6_Click_1(this, arg2);
                                break;
                            case 7:
                                button7_Click_1(this, arg2);
                                break;
                            case 8:
                                button8_Click_1(this, arg2);
                                break;
                            case 9:
                                button9_Click_1(this, arg2);
                                break;
                        }
                    }
                }



            }
            else
            {
                if (MueveJugador2(posicion))
                {
                    switch (posicion)
                    {
                        case 1:
                            button1.Text = "O";
                            break;
                        case 2:
                            button2.Text = "O";
                            break;
                        case 3:
                            button3.Text = "O";
                            break;
                        case 4:
                            button4.Text = "O";
                            break;
                        case 5:
                            button5.Text = "O";
                            break;
                        case 6:
                            button6.Text = "O";
                            break;
                        case 7:
                            button7.Text = "O";
                            break;
                        case 8:
                            button8.Text = "O";
                            break;
                        case 9:
                            button9.Text = "O";
                            break;
                    }

                    turno = turnojug1;
                    label1.Text = "Es el turno del jugador " + nombrejugador1;

                    if (Tipojugador1 == CPU)
                    {
                        Random r = new Random();
                        int n = r.Next(1, 9);
                        EventArgs arg = new EventArgs();

                        switch (n)
                        {
                            case 1:
                                button1_Click(this, arg);
                                break;
                            case 2:
                                button2_Click_1(this, arg);
                                break;
                            case 3:
                                button3_Click_1(this, arg);
                                break;
                            case 4:
                                button4_Click_1(this, arg);
                                break;
                            case 5:
                                button5_Click_1(this, arg);
                                break;
                            case 6:
                                button6_Click_1(this, arg);
                                break;
                            case 7:
                                button7_Click_1(this, arg);
                                break;
                            case 8:
                                button8_Click_1(this, arg);
                                break;
                            case 9:
                                button9_Click_1(this, arg);
                                break;
                        }
                    }
                    if (!QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
                    {
                        label1.Text = "Partida en tablas";
                    }
                    else
                    {
                        if (GanaJugador1())
                        {
                            label1.Text = "Gana Jugador " + nombrejugador1;
                        }
                        else
                        {
                            if (GanaJugador2())
                            {
                                label1.Text = "Gana Jugador " + nombrejugador2;
                            }
                        }
                    }
                }
                else
                {
                    label1.Text = "Casilla ocupada, elige otra casilla";

                    if (Tipojugador2 == CPU)
                    {
                        Random r2 = new Random();
                        int n2 = r2.Next(1, 9);
                        EventArgs arg2 = new EventArgs();

                        switch (n2)
                        {
                            case 1:
                                button1_Click(this, arg2);
                                break;
                            case 2:
                                button2_Click_1(this, arg2);
                                break;
                            case 3:
                                button3_Click_1(this, arg2);
                                break;
                            case 4:
                                button4_Click_1(this, arg2);
                                break;
                            case 5:
                                button5_Click_1(this, arg2);
                                break;
                            case 6:
                                button6_Click_1(this, arg2);
                                break;
                            case 7:
                                button7_Click_1(this, arg2);
                                break;
                            case 8:
                                button8_Click_1(this, arg2);
                                break;
                            case 9:
                                button9_Click_1(this, arg2);
                                break;
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(1);
            }
            else
            {
                label1.Text = "Partida terminada";

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(2);
            }
            else
            {
                label1.Text = "Partida terminada";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(3);
            }
            else
            {
                label1.Text = "Partida terminada";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(4);
            }
            else
            {
                label1.Text = "Partida terminada";
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(5);
            }
            else
            {
                label1.Text = "Partida terminada";
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(6);
            }
            else
            {
                label1.Text = "Partida terminada";
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(7);
            }
            else
            {
                label1.Text = "Partida terminada";
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(8);
            }
            else
            {
                label1.Text = "Partida terminada";
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (QuedanMovimientos() && !(GanaJugador1()) && !(GanaJugador2()))
            {
                comprueba_movimiento(9);
            }
            else
            {
                label1.Text = "Partida terminada";
            }
        }
    }

}
