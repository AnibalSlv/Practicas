from sklearn.datasets import load_digits
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
import matplotlib.pyplot as plt

# Cargar el dataset de dígitos
digits = load_digits()
X = digits.data
y = digits.target

# Dividir en entrenamiento y prueba
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Crear y entrenar el modelo
model = LogisticRegression(max_iter=1000)
model.fit(X_train, y_train)

# Evaluar el modelo
accuracy = model.score(X_test, y_test)
print(f"Precisión del modelo: {accuracy}")

# Mostrar una imagen de ejemplo
plt.gray()
plt.matshow(digits.images[0])
plt.title(f"Etiqueta: {digits.target[0]}")
plt.show()
