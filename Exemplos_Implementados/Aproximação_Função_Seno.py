from keras.models import Sequential
from keras.layers import Dense
import numpy
import random

# split into input (X) and output (Y) variables
X1 = numpy.arange(0, 10.8, 0.01)
Y1 = numpy.sin(X1)
D = []
for i in range(0,len(X1)):
    D.append([X1[i],Y1[i]])
    
random.shuffle(D)
X=[]
Y=[]
for i in range(0, len(D)):
    X.append(D[i][0])
    Y.append(D[i][1])
    
# create model
model = Sequential()
model.add(Dense(200, input_dim=1, activation='relu'))
model.add(Dense(16, activation='sigmoid'))
model.add(Dense(1, activation='linear'))

# Compile model
model.compile(loss='mean_squared_error', optimizer='SGD', metrics=['mean_squared_error'])

import matplotlib.pyplot as plt
Xt = numpy.arange(0.0,12.0,0.4)

# Fit the model and shows the result
for i in range(1,50):
    model.fit(X, Y, epochs=25, batch_size=50, verbose=0)

    Yt = numpy.sin(Xt)
    predictions = model.predict(Xt)
    sai = []
    for pred in predictions:
        sai.append(pred[0])
    plt.clf()
    plt.plot(Xt, Yt, 'b', Xt, sai, 'r--')
    plt.ylabel('Y / Predicted Value '+str(i))
    plt.xlabel('X Value')
    plt.draw()
    plt.pause(0.001)
 #   plt.show(block=False)