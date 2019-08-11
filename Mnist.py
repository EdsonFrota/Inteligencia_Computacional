from __future__ import print_function

import tensorflow as tf
import matplotlib.pyplot as plt
import numpy as np

from tensorflow.keras.datasets import mnist
from tensorflow.keras.models import Sequential
from tensorflow.keras.layers import Dense, Dropout
from tensorflow.keras.optimizers import RMSprop,SGD
from tensorflow.keras.regularizers import l1

batch_size = 128
num_classes = 10
epochs = 200

# Obtendo os conjuntos de treino e teste
(x_train, y_train), (x_test, y_test) = mnist.load_data()

# Pegando apenas alguns exemplos por uma questão de memória
x_train = x_train[:10000,:,:]
y_train = y_train[:10000]
x_test = x_test[:1000,:,:]
y_test  = y_test[:1000]

# Transformando as matrizes em vetores unidimensionais
x_train = x_train.reshape(10000, 784)
x_test = x_test.reshape(1000, 784)
x_train = x_train.astype('float32')
x_test = x_test.astype('float32')

# Normalizando os valores para o intervalo [0,1]
x_train /= 255
x_test /= 255

# convertendo os vetores das classes em matrizes de classificação binárias
y_train = tf.keras.utils.to_categorical(y_train, num_classes)
y_test = tf.keras.utils.to_categorical(y_test, num_classes)

# Definição da arquitetura do modelo
model = Sequential()
# adicione aqui as camadas do modelo

model = tf.keras.models.Sequential()
model.add(tf.keras.layers.Dense(300, input_dim=784, activation='relu'))
model.add(tf.keras.layers.Dense(300, activation='tanh'))
model.add(tf.keras.layers.Dense(10, activation='softmax'))

# Fim - Definição da arquitetura do modelo

model.summary()

model.compile(loss='categorical_crossentropy',
              optimizer=tf.train.AdamOptimizer(),
              metrics=['accuracy'])

#optimizer=SGD(0.01)
# Treinamento do modelo optimizer=tf.train.AdamOptimizer(learning_rate=0.01),
H = model.fit(  x_train, y_train,
                batch_size=batch_size,
                epochs=epochs,
                verbose=1,
                validation_data=(x_test, y_test))

# Avaliação do modelo no conjunto de teste
score = model.evaluate(x_test, y_test, verbose=1)

print('Test loss:', score[0])
print('Test accuracy:', score[1])
'''
# plotando 'loss' e 'accuracy' para os datasets 'train' e 'test'
plt.figure()
#plt.plot(np.arange(0,epochs), H.history["loss"], label="train_loss")
#plt.plot(np.arange(0,epochs), H.history["val_loss"], label="val_loss")
plt.plot(np.arange(0,epochs), H.history["acc"], label="train_acc")
plt.plot(np.arange(0,epochs), H.history["val_acc"], label="val_acc")
plt.title("Acurácia")
plt.xlabel("Épocas #")
plt.ylabel("Loss/Accuracy")
plt.legend()
plt.show()'''
model.save('final_model.h5')