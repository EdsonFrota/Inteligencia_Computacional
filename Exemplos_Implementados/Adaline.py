from math import exp 
import numpy as np
import matplotlib.pyplot as plt
from random import random

def main():
    x = np.array([[1, 1],
                  [1, 0],
                  [0, 1],
                  [0, 0]])
    d = [1, -1, -1, -1]
    w, bias = Adaline(epocas=100, Epsilon=.000001, alpha=.1, x=x, d=d)
    Plotar(w[0], w[1], bias, "Porta lógica AND com Adaline")

def Tangente_Hiperbolica(f):
    return (exp(f) - exp(-(f))) / (exp(f) + exp(-(f)))


def Adaline(epocas, Epsilon, alpha, x, d):
    w = [random(), random()]
    bias = np.array([random()])
    
    t = 0
    
    Erro_Medio_Quad = 1

    while t < epocas and Erro_Medio_Quad > Epsilon :
        
        edson = []
        junior = []
        
        for i in range(len(x)):
            
            f = 0
            for j in range(len(x[i])):
                f += w[j] * x[i][j]  
            f += bias
            y = Tangente_Hiperbolica(f)
            
            edson.append(d[i] - y)     # ERRO
            junior.append(edson[i] ** 2)  # ERRO QUADRÁTICO

            for k in range(len(w)):
                w[k] += alpha * edson[i] * x[i][k]
            bias += alpha * edson[i]
        
        Erro_Medio_Quad = (sum(junior)/len(junior))
        
        t += 1
    return w, bias

def Plotar(w1, w2, bias, title):
    xvals = np.arange(-1, 3, 0.01)
    newyvals = (((xvals * w2) * - 1) - bias) / w1
    plt.plot(xvals, newyvals, 'r-')
    plt.title(title)
    plt.xlabel('X1')
    plt.ylabel('X2')
    plt.axis([-1, 2, -1, 2])
    plt.plot([0, 1, 0], [0, 0, 1], 'b^')
    plt.plot([1], [1], 'go')
    plt.xticks([0, 1])
    plt.yticks([0, 1])
    plt.show()


if __name__ == '__main__':
    main()

