public class Metodo {
	int[][] Matriz_Requisitos = { { 10, 10, 5 }, { 8, 10, 6 }, { 6, 4, 8 }, { 5, 9, 1 }, { 7, 7, 5 }, { 8, 6, 2 },
			{ 6, 6, 4 }, { 9, 8, 3 }, { 6, 7, 5 }, { 5, 9, 1 } };

	int[] Risco = { 3, 6, 2, 6, 4, 8, 9, 7, 6, 6 };
	double[] Custo = { 60.0, 40.0, 40.0, 30.0, 20.0, 20.0, 25.0, 70.0, 50.0, 20.0 };

	int Clientes = 3;
	int _T_Relases = 3;
	int _Requisitos = 10;
	double _Relese = 125.0;

	int[] _Importancia = new int[10];

	int Erro(int[] x) {
		int a;
		double[] Preco_Relase = new double[3];

		double erro = 0.0;
		for (a = 0; a < 3; a++) {
			Preco_Relase[a] = 0.0;
		}

		for (a = 0; a < 10; a++) { // _Requisitos = 10
			if (x[a] == 3) {
				Preco_Relase[2] += Custo[a];
			}

			if (x[a] == 2) {
				Preco_Relase[1] += Custo[a];
			}

			if (x[a] == 1) {
				Preco_Relase[0] += Custo[a];
			}
		}

		for (a = 0; a < 3; a++) {
			if (Preco_Relase[a] > _Relese) {
				erro += Preco_Relase[a] - _Relese;
			}
		}
		return ((int) erro);
	}

	boolean _Fx_(int[] x) {
		int a;
		double[] Preco_Relase = new double[3];
		int boss = 0;

		for (a = 0; a < 3; a++) {
			Preco_Relase[a] = 0.0;
		}

		for (a = 0; a < 10; a++) {// _Requisitos = 10
			if (x[a] == 3) {
				Preco_Relase[2] += Custo[a];
			}

			if (x[a] == 2) {
				Preco_Relase[1] += Custo[a];
			}

			if (x[a] == 1) {
				Preco_Relase[0] += Custo[a];
			}
		}

		for (a = 0; a < 3; a++) {
			if (Preco_Relase[a] > _Relese) {
				boss = 1;
			}
		}
		if (boss == 0) {
			return (true);
		}
		return (false);
	}

	int _FIT_(int[] x) {

		int Score = 0, a, b, y;
		int[] _R_Cliente = { 3, 4, 2 };

		for (a = 0; a < 10; a++) {// _Requisitos = 10
			_Importancia[a] = 0;
			for (b = 0; b < Clientes; b++) {
				_Importancia[a] += _R_Cliente[b] * Matriz_Requisitos[a][b];
			}
		}

		for (a = 0; a < 10; a++) {// _Requisitos = 10
			if (x[a] == 0) {
				y = 0;
			} else {
				y = 1;
				Score += _Importancia[a] * (3 - x[a] + 1) - (Risco[a] * x[a]) * y;
			}
		}

		if (this._Fx_(x) == true) {
			return (Score);
		} else {
			return (Score / this.Erro(x));
		}
	}
}