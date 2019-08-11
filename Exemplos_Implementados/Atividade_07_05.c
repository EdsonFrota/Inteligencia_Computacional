#include <stdio.h>
#include <time.h>                   /* Edson Frota - 201515412
                                     Engenharia de Computação */
int main ()
{
    srand(time(NULL));
    int i, aleatorio;
    float Score = 0;

    printf(" Gerar valores aleatorios: \n");
    scanf("%i",&aleatorio);

    int *Gene;
    Gene = (int*)malloc(aleatorio*sizeof(int));
    for(i=0; i<aleatorio; i++)
    {
        int x[i], y[i], z[i];
        int Custo[] = {7,6,1,2};
        int Risco[] = {1,3,9,1};
        int Valor[] = {10,20,15,15};
        int relase[] = {7,4};

        Gene[i] = rand() % aleatorio;

        x[i] = Custo[i] * Valor[i];
        y[i] = ((int)(sizeof(relase)/sizeof(relase[0]))) - (Gene[i] + 1);
        z[i] = Risco[i] * Gene[i];

        if(Gene[i] != 0)
        {
            Score = Score +((x[i]*y[i])-z[i]);
        }
    }
    printf(" \n %f \n", Score);

    return(0);
}
