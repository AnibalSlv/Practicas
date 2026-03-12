import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns #permite graficar mejor
import numpy as np #? Sirve para datos numericos (se supone que tambien es un modelo)

#TODO REGRESION LINEAL
from sklearn.linear_model import LinearRegression #aqui es lo que vamos a utilizar para hacer el modelo de regresion lineal
from sklearn.model_selection import train_test_split #nos va a permitr dividir el conjunto de datos y el conjunto
#de entranimineto en el conjunto de testing y es que no es recomendable usar todos los datos de una vez para entrenar
from sklearn.metrics import root_mean_squared_error, r2_score #Para calificar nuestro modelo de regresion para ver que tan bueno es

#TODO REGRESION POLINOMICA
from sklearn.preprocessing import PolynomialFeatures #Esto nos permite ->
#convertir la variable independiente a los grados del polinomio que estas creando
#from sklearn.metrics import root_mean_squared_error, r2_score #?Solo que yo ya lo tengo asi que aja

#TODO SVRP
from sklearn.svm import SVR
#from sklearn.model_selection import train_test_split #?Tambien se importa esto y la r2
#from sklearn.metrics import root_mean_squared_error, r2_score #?Solo que yo ya lo tengo asi que aja

#TODO MANIPULACION DE LOS DATOS CATEGORICOS
from sklearn.preprocessing import OrdinalEncoder #?Esto nos va a servir para hacer la manipulacion de los datos categoricos
#!NO ES MUY RECOMENDADA, BUSCA EN MANIPULACION DE DATOS CATEGORICOS PARA QUE TE ENTERES

from sklearn.preprocessing import OneHotEncoder #?Esta si es mas recomendada para entrenar a la IA

#TODO ESCALAR DE VARIABLES (Es util para datos en una tabla en donnde su columna va de 7000 y en otra va de 0 a 1)
from sklearn.preprocessing import StandardScaler #? Junta los valores de la columna con numeros altos con la columna
#? Que tiene numeros bajos (porque por ejemplo puede que en esa columna vaya de 0 a 1) asi el algoritmo no se confunde

#TODO Arboles de Regresion
from sklearn.tree import DecisionTreeRegressor

#TODO Bosques aleatorios de regresion
from sklearn.ensemble import RandomForestRegressor

def anotaciones():
    data = pd.read_csv('A:/Python/ML/Datos/Advertising.csv')
    data = data.iloc[:, 1:] #Esto es para eliminar una columna que estaba como unanefine algo asi

    #print(data.info()) Esto es para saber la informacion de la df

    #print(data.columns) Para ver las columnas

    #cols = ['TV', 'Radio', 'Newspaper']
    """
    for col in cols:
        plt.plot(data[col], data['Sales'], 'ro') #Esto decimos: 
        
            #Quiero que obtengas los datos de data
            #Quiero que los datos se grafiquen en Sales
            #Usaras el color rojo y seran circulos
        
        plt.title('Ventas respecto a la publicidad en %s' % col)
        plt.show()
    """

    #X = data['TV'].values #Asi sacas los valores solamente 
    x = data['TV'].values.reshape(-1,1) #Asi es como sklean puede leer los datos porque esto hace que esten en una sola fila cada dato
    #Y eso es lo que quiere el porque si no se awuita y no furula
    y = data['Sales'].values #Aca no espera que le llegen en formato de matriz asi que da igual

    #Dividir el conjunto de datos entre entrenamiento y testing
    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2, random_state=42)

    #? Dividimos el conjunto de datos en entrenamiento y prueba usando train_test_split
    #? x → características o datos de entrada (lo que el modelo usa para aprender)
    #? y → etiquetas o respuestas correctas (lo que queremos que el modelo prediga)

    #TODO test_size=0.2 reserva el 20% de los datos para pruebas (y el 80% para entrenamiento)
    #TODO ⚠️ Usar un tamaño de prueba adecuado evita el sobreentrenamiento
    #    - Muy pocos datos de prueba pueden hacer que el modelo se adapte demasiado al entrenamiento
    #    - Lo ideal es usar entre el 20% y el 30% para testeo, según el tamaño total del conjunto

    # TODO 🔄 Sobreentrenamiento (overfitting) = el modelo aprende demasiado bien los datos de entrenamiento
    #    - Pierde capacidad de generalizar con nuevos datos
    #    - Especialmente crítico en conjuntos pequeños o muy limpios
    #!Esto lo escribi yo solo que la ia me ayudo a entender un poco mejor 

    #? random_state="cualquier numero" es como una semilla para que no sea tan aleatorio, se usa cuand otrabajas con mas gente, compartes
    #? datos o arreglas errores  en este caso lo use para tener los mismos datos que el tutorial que sigo

    #print(x_train.shape) Esto es importante para verificar los datos antes de comenzar el entrenamiento
    #print(x_test.shape)

    lin_reg = LinearRegression() #? Aqui preparas el modelo
    lin_reg.fit(x_train, y_train) #? Aqui empieza el entrenamiento y en los () pones los conjunto de datos de entrenamiento
    #x_train y_train esto para que le digas los datos que tiene que usar para entrenar (que son los que declaraste arriba)

    predict = lin_reg.predict(x_test) #esto es para predecir

    #print('Predicciones:{}, Reales: {}'.format(predict[:4], y_test[:4]))
    #envias las primeras 4 predicciones y las primeras 4 testeos
    #Esto es para ver que tan bien nos salio el modelo

    #TODO RMSE es para calificar el modelo
    rmse = root_mean_squared_error(y_test, predict)
    print('RMSE:', rmse) #Indica que tanto varia los datos de la prediccion con los reales
    #TODO R2 es para calificar el modelo
    print('R2:', r2_score(y_test, predict)) #Tiene valores de 0 a 1 y el 1 es el mas pro

    plt.plot(x_test, y_test, 'ro')
    plt.plot(x_test, predict)
    plt.show()

data = pd.read_csv('Datos/Advertising.csv') #! AQUI ES EL ERROR SOLO QUE AJA PON BIEN LA RUTA TONTO
data = data.iloc[:, 1:]

def modelos_simple(independiente):
    x = data[independiente].values.reshape(-1,1) 
    y = data['Sales'].values 
    
    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2, random_state=42)
    lin_reg = LinearRegression() #? Aqui preparas el modelo
    lin_reg.fit(x_train, y_train)
    predict = lin_reg.predict(x_test)
    
    print('Predicciones:{}, Reales: {}'.format(predict[:4], y_test[:4]))
    rmse = root_mean_squared_error(y_test, predict)
    print('RMSE:', rmse) 
    print('R2:', r2_score(y_test, predict))
    plt.plot(x_test, y_test, 'ro')
    plt.plot(x_test, predict)
    plt.show()
#modelos_simple("Radio")

def modelo_simple_regrsion_multiple():#Usar si ves que los datos no tienen mucho ruido si no, usar SVR
    #En otras palabras si no son datos complejos usa este, si no, usa el SVR
    x = data.drop(['Newspaper', 'Sales'], axis = 1).values #drop sirve para eliminar columnas, axis lo viste en pandas
    #No haces un reshape porque al hacer lo que estas haciendo ya devuelve la matriz que sirve
    y = data['Sales'].values 
        
    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2, random_state=42)
    lin_reg = LinearRegression() #? Aqui preparas el modelo
    lin_reg.fit(x_train, y_train)
    predict = lin_reg.predict(x_test)
        
    print('Predicciones:{}, Reales: {}'.format(predict[:4], y_test[:4]))
    rmse = root_mean_squared_error(y_test, predict)
    print('RMSE:', rmse) 
    print('R2:', r2_score(y_test, predict))
        
    sns.regplot(x = y_test, y = predict) 

    plt.show()
    #El "aura" (la linea mas clara que la del medio) es el intervalo de confianza osea el modelo predice donde suelen caer
    #los puntos, osea es como un margen de error por falta de precision pero te dice que suelen caer por esa zona los puntos 
#modelo_simple_regrsion_multiple()

def regresion_lineal_con_datos_que_claramente_no_puede_manejar():
    pos = [x for x in range(1,11)]
    post = ["Pasande de Desarrollo",
        "Desarrollador Junior",
        "Desarrollador Intermedio",
        "Desarrollador Senior",
        "Lider del Proyecto",
        "Gerente de Proyecto",
        "Arquitecto de SoftWare",
        "Director de Desarrollo",
        "Director de Tecnologia",
        "Director Ejecutivo (CEO)"]

    salary = [1200.0, 2500.0, 4000.0, 4800.0, 6500.0, 9000.0, 12820.0, 15000.0, 25000.0, 50000.0]

    data = {
        'position': post,
        'years': pos,
        'salary': salary
    }

    data = pd.DataFrame(data) #El diccionario es par poder hacer esto con pandas, osea poder convertirlo en una tabla

    x = data.iloc[:,1].values.reshape(-1,1)
    y = data.iloc[:,-1].values #le pones el -1 porque asi nos referimos a la ultima columna

    regression = LinearRegression()
    regression.fit(x, y) # no limitamos sus datos porque tenemos muy poquitos datos entonces no conviene

    print(data.head())

    plt.scatter(data['years'], data['salary'])
    plt.plot(x, regression.predict(x), color ="black")
    plt.show()
    #En este ejemplo se muestra como para estos casos no sirve regresion lineal porque en su linea marca 
    #Que pueden tener salarios negativos y que el ceo gana menos 
    print(regression.predict([[2]])) #!De hecho aqui ves que te dice que una persona que lleva trabajando 2 años
    #!Tiene sueldo en negativo
#regresion_lineal_con_datos_que_claramente_no_puede_manejar()

def modelo_regresion_polinomica(): #usar si ves que los datos tienen curvatura
    #1.-Para este modelo necesitas indicarle los grados que deberia de tener ese polinomio
    #2.-Al final tienes que convertir la variable independiente a los grados del polinomio que estas creando

    pos = [x for x in range(1,11)]
    post = ["Pasande de Desarrollo",
        "Desarrollador Junior",
        "Desarrollador Intermedio",
        "Desarrollador Senior",
        "Lider del Proyecto",
        "Gerente de Proyecto",
        "Arquitecto de SoftWare",
        "Director de Desarrollo",
        "Director de Tecnologia",
        "Director Ejecutivo (CEO)"]

    salary = [1200.0, 2500.0, 4000.0, 4800.0, 6500.0, 9000.0, 12820.0, 15000.0, 25000.0, 50000.0]

    data = {
        'position': post,
        'years': pos,
        'salary': salary
    }

    data = pd.DataFrame(data) #El diccionario es par poder hacer esto con pandas, osea poder convertirlo en una tabla

    x = data.iloc[:,1].values.reshape(-1,1)
    y = data.iloc[:,-1].values #le pones el -1 porque asi nos referimos a la ultima columna

    poly = PolynomialFeatures(degree=4) #Esto dice que quieres un polinomio de grado 3 #! Ajustar para mas precision
    #TODO se recomienda usar grados de 3 a 5 porque si aparecen datos nuevos con mas ruido puede actuar mal

    x_poly = poly.fit_transform(x) #Esto Transforma la variable independiente a el grado de polinomio que usamos
    #print(x_poly) #? Esto te regresara los valores de x con potencia desde 0 a 3 sirve como para ver los valores de x
    regression = LinearRegression()
    regression.fit(x_poly, y)

    predict = poly.fit_transform([[2]]) #TODO Asi podemos predecir el salario en 2 anos
    print(regression.predict(predict))

    y_pred = regression.predict(x_poly) #TODO Asi obtenemos el r2 
    print(r2_score(y, y_pred))

    plt.scatter(data['years'], data['salary'])
    plt.plot(x, regression.predict(x_poly), color ="black")
    plt.show()
#modelo_regresion_polinomica()

def modelo_SVR(): #Usar si ves que los datos tienen mucho ruido, si no, usar regresion multiple
    #En otras palabras si los datos no son complejos usar el multiple, si no, usar este
    #!Recuerda que este algoritmo usa datos de Tv y Newspapers porque estas borrando radio y sales de x
    x = data.drop(['Newspaper','Sales'], axis=1).values
    y = data['Sales'].values

    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2, random_state=42)

    svr = SVR(kernel="rbf") #? rbf es el valor por defecto hay otros, linear, etc, se tiene que elegir segun convenga
    svr.fit(x_train, y_train)

    y_pred = svr.predict(x_test)
    print("Reales:", y_test[:4], "Prediccion:", y_pred[:4]) #Aqui ponemos los primeros 4 de cada uno para ver los datos
    print(r2_score(y_test, y_pred)) 

    sns.regplot(x = y_test, y = y_pred) 

    plt.show()
#modelo_SVR()

#TODO APRENDIENDO A MANEJAR DATOS

dataCali = pd.read_csv('Datos/housing.csv')

def California_House_Price():
    #print(dataCali.head())
    #print(dataCali['ocean_proximity'].value_counts())

    #dataCali.hist(bins = 50, figsize=(20, 15))#?asi se hace un historama con 50 columna y un tamano de 20 X y 15 Y (pulgadas)
    #plt.tight_layout() #ajusta los espacios entre cada histogramada #?Personalmente lo veo mejor sin esto
    #plt.show()

    #Ahora vamos a hacer la grafica con plot

    dataCali.plot(kind = 'scatter', x = 'longitude', y = 'latitude', alpha = 0.4, s = dataCali['population']/100,
                  label = 'population', figsize=(15,7), c='median_house_value', cmap = plt.get_cmap('jet'),
                  colorbar = True) 
    """
        kind = el tipo de tabla
        x y = los valores
        alpha = la transparencia
        s = el tamaño de los puntos
        label = la etiqueta
        figsize = el tamaño del grafico
        c = los colores (el nombre media_house_value es de una columa que esta dentro de los datos)
        cmap = defines los colores que vas a usar en el grafico
        colobar = para tener la barra de color
    """
    plt.legend() # Para que se vea la leyenda
    plt.show() #Si te das cuenta da el mapa de california (buscalo en google maps si quieres)
#California_House_Price()

#TODO Correlacion (con sns)
def Correlacion_de_datos():
    #?En este caso queremos sacar la correlacion con medianh_house_value
    numericas = dataCali.select_dtypes(include='number') #!Asi se filtran los datos para que solo hayan numeros y no de error luego

    #plt.figure(figsize=(10, 5))
    #sns.heatmap(numericas.corr(), annot=True, cmap='coolwarm', fmt=".2f", linewidths=0.5)
    #plt.tight_layout() #?mientras mas rojo este mas correlacon (osea relacion) tiene

    corr_matrix = numericas.corr()
    print(corr_matrix['median_house_value'].sort_values(ascending=False)) #ordena los datos de manera ascendida
#Correlacion_de_datos() #! No hay que confiar mucho de lo que dice la correlacion a veces si puede mejorar la puntiacion
#!Con una combinacion de datos

#TODO Combinacion de atributos
def Combinacion_de_atributos():
    """
        - `rooms_per_houseold`: Representa el numero medio de habitaciones por hogar en una cierta area. Porpociona una medida de la densidad de la habitaciones en una vivienda promedio en esa area
        - `bedrooms_per_room`: Indica la proporcion de dormitorios respecto al numero total de habitaciones en una cierta area
        - `population_per_household`: Representa la densidad de poblacion promedio por hogar en una cierta area
    """

    dataCali['rooms_per_houseold'] = dataCali['total_rooms'] / dataCali['households']
    dataCali['bedrooms_per_room'] = dataCali['total_bedrooms'] / dataCali['total_rooms']
    dataCali['population_per_household'] = dataCali['population'] / dataCali['households']

    numericas = dataCali.select_dtypes(include='number')
    corr_matrix = numericas.corr()

    print(corr_matrix['median_house_value'].sort_values(ascending=False))
    #Segun estos datos el dato con mejor correlacion es rooms_per_houseold porque los demas estan en negativo
#Combinacion_de_atributos()

#TODO LIMPIEZA DE DATOS (limpieza y manejar atributos categoricos)
def parte1_de_limpieza_de_datos_explicacion_de_porque_no_poner_0_y_poner_NaN_o_Null():
    x = [1, 2, 3, np.nan]
    x1 = pd.Series(x) #?asi lo conviertes en una serie para simular una columna en un conjunto de datos

    print(x1.mean()) #calcular el promedio
    #?la serie elimina el valor faltante (que en este caso es np.nan) y se queda con el resto asi que el resultado aqui es 2
    
    #? Pero si en cambio
    x = [1, 2, 3, 0]
    x1 = pd.Series(x)

    print(x1.mean()) #da como resultado 1.5 porque si toma encuenta el 0
#parte1_de_limpieza_de_datos_explicacion_de_porque_no_poner_0_y_poner_NaN_o_Null()

def limpieza_de_datos():
    dataCali['total_bedrooms'].fillna(dataCali['total_bedrooms'].median(), inplace=True)
    """
        1.- Llamamos a la columna que queremos manipular
        2.- con fillna indicamos los valores con el que queremos rellenar los datos faltantes
        3.- inplace es para decir que si quieres cambiar la informacion original del conjunto de datos
        
        ?Se hace esto porque si pones print(dataCali.info()) te daras cuenta que total_bedrooms tiene menos datos que los demas
        !Lo pondria como ejm pero no aparece a diferencia del video asi que te lo explico aqui abajo
        Si tuvieramos otro dato que no estuviera completo tambien PERO tiene una correlacion negativa entonces no vale la pena
        Si en realiadad ni lo vamos a usar
    """
    print(dataCali.info())
#limpieza_de_datos()

#TODO MANIPULACION DE DATOS CATEGORICOS
def manipulacion_de_datos_categoricos_no_tan_recomendada():
    data_ocean = dataCali[['ocean_proximity']] #?se extrae como una lista para que la informacion al final se extraiga como un
    #?conjunto de datos y no como una serie
    ordinal_encoder = OrdinalEncoder() 
    data_ocean_encoder = ordinal_encoder.fit_transform(data_ocean) #!SUPONGO que aqui lo transformamos a datos "codificados"
    print(np.random.choice(data_ocean_encoder.ravel(), size=10))
    """
        1.- Decimos que queremos valores random de data_ocean_encoder
        2.- el .ravel() hace que data_ocean_encoder se transforme en un dato que pueda ser utilizado por np.random
        3.- size = 10 decimos que queremos 10 datos random de data_ocean_encoder
        
        !El problema de hacer esto es que si entrenamos a la IA con esto puede detectar los numeros (0,1,2,3 y 4) como
        !Valores lejanos o cercanos y eso no es bueno
    """   
#manipulacion_de_datos_categoricos_no_tan_recomendada()

def manipulacion_de_datos_categoricos_recomendada():
    data_ocean = dataCali[['ocean_proximity']] #?se extrae como una lista para que la informacion al final se extraiga como un
    #?conjunto de datos y no como una serie
    cat_encoder = OneHotEncoder()
    data_car_hot =  cat_encoder.fit_transform(data_ocean)
    #print(data_car_hot.toarray()) #?0 indica que no representa a la fila y 1 que si representa a la fila
    #osea 0. 0. 0. 1. 0. 1 representa que la columna de algun dato si se encuentra en la lista y 0 que no
    
    encoded_df = pd.DataFrame(data_car_hot.toarray(), columns= cat_encoder.get_feature_names_out())
    print(encoded_df) # con esto vemos datos categoricos
#manipulacion_de_datos_categoricos_recomendada()

#TODO Modelos de Ml
def algoritmos_de_ml():
    data_ocean = dataCali[['ocean_proximity']] #?se extrae como una lista para que la informacion al final se extraiga como un
    #?conjunto de datos y no como una serie
    cat_encoder = OneHotEncoder()
    data_car_hot =  cat_encoder.fit_transform(data_ocean)
    encoded_df = pd.DataFrame(data_car_hot.toarray(), columns= cat_encoder.get_feature_names_out())
    #Todo lo de arriba es de lo anterior

    
    y = dataCali['median_house_value'].values.reshape(-1,1)
    x = dataCali[[
        'median_income',
        'total_rooms',
        'housing_median_age',
        'households'
    ]]

    data1 = pd.concat([x, encoded_df], axis=1)
    print(data1.columns)
    x = data1.values
#algoritmos_de_ml()

def algoritmo_de_regresion_multiple():
    data_ocean = dataCali[['ocean_proximity']] #?se extrae como una lista para que la informacion al final se extraiga como un
    #?conjunto de datos y no como una serie
    cat_encoder = OneHotEncoder()
    data_car_hot =  cat_encoder.fit_transform(data_ocean)
    encoded_df = pd.DataFrame(data_car_hot.toarray(), columns= cat_encoder.get_feature_names_out())
    #Todo lo de arriba es de lo anterior

    
    y = dataCali['median_house_value'].values.reshape(-1,1)
    x = dataCali[[
        'median_income',
        'total_rooms',
        'housing_median_age',
        'households'
    ]]
    
    data1 = pd.concat([x, encoded_df], axis=1)
    x = data1.values
    
    x_train, x_test, y_train, y_test = train_test_split(x,y, test_size=0.2)
    #print(x_train.shape)
    #print(y_train.shape)
    
    lin_reg = LinearRegression()
    lin_reg.fit(x_train, y_train)
    
    y_pred = lin_reg.predict(x_test)
    r2 = r2_score(y_test, y_pred)
    
    print(r2) #? Para mejorar este algoritmo tenemos que hacer un metodo que es para que el modelo no se confuda con datos
    #?que van del 7000 al 1 por ejemplo porque piensa que son datos que tienen mucha diferencia cuando resulta 1 significa otra cosa
    #? Entonces con el siguiente metodo lo que hara es que 7000 y 1 no esten tan alejados esto mejora su precision
#algoritmo_de_regresion_multiple()

def escalar_de_variables():
    data_ocean = dataCali[['ocean_proximity']] #?se extrae como una lista para que la informacion al final se extraiga como un
    #?conjunto de datos y no como una serie
    cat_encoder = OneHotEncoder()
    data_car_hot =  cat_encoder.fit_transform(data_ocean)
    encoded_df = pd.DataFrame(data_car_hot.toarray(), columns= cat_encoder.get_feature_names_out())
    #Todo lo de arriba es de lo anterior

    
    y = dataCali['median_house_value'].values.reshape(-1,1)
    x = dataCali[[
        'median_income',
        'total_rooms',
        'housing_median_age',
        'households'
    ]]
    
    data1 = pd.concat([x, encoded_df], axis=1)
    x = data1.values
    
    sc_x = StandardScaler() #TODO ESTO ES LO NUEVO-----------------------------------------------------------------
    x = sc_x.fit_transform(x)
    
    x_train, x_test, y_train, y_test = train_test_split(x,y, test_size=0.2)
    #print(x_train.shape)
    #print(y_train.shape)
    
    lin_reg = LinearRegression()
    lin_reg.fit(x_train, y_train)
    
    y_pred = lin_reg.predict(x_test)
    r2 = r2_score(y_test, y_pred)
    print(r2)
#escalar_de_variables() #! En este caso no afecto mucho la mejora del modelo pero hay casos en lo que si lo mejora

#TODO MODELO DE ARBOLES Y BOSQUES ALEATORIOS
def modelo_de_arbol_de_regresion():
    data_ocean = dataCali[['ocean_proximity']]
    cat_encoder = OneHotEncoder()
    data_car_hot =  cat_encoder.fit_transform(data_ocean)
    encoded_df = pd.DataFrame(data_car_hot.toarray(), columns= cat_encoder.get_feature_names_out())
    Columnas = [
            'median_income',
            'total_rooms',
            'housing_median_age',
            'households',
            'latitude',
            'longitude'
        ]
    col_modelo = []
    y = dataCali['median_house_value'].values.reshape(-1,1)
    
    for col in Columnas:
        col_modelo.append(col)
        data1 = dataCali[col_modelo]
        data1 = pd.concat([data1, encoded_df], axis=1)
        x = data1.values
        
        x_train, x_test, y_train, y_test = train_test_split(x,y, test_size=0.2)
        #print(x_train.shape)
        #print(y_train.shape)
        
        tree = DecisionTreeRegressor() #TODO Todo es igual excepto aqui (osea cambiar line a decisionTreeRegressor)
        tree.fit(x_train, y_train) #TODO y excepto que estoy viendo como actua la puntuacion con cada dato anadido
        #TODO y que anadi mas datos para que analice xd
        y_pred = tree.predict(x_test)
        r2 = r2_score(y_test, y_pred)
    
        print(col_modelo, r2)
#Smodelo_de_arbol_de_regresion()

def modelo_de_bosque_aleatorio_de_regresion():
    data_ocean = dataCali[['ocean_proximity']]
    cat_encoder = OneHotEncoder()
    data_car_hot =  cat_encoder.fit_transform(data_ocean)
    encoded_df = pd.DataFrame(data_car_hot.toarray(), columns= cat_encoder.get_feature_names_out())
    Columnas = [
            'median_income',
            'total_rooms',
            'housing_median_age',
            'households',
            'latitude',
            'longitude'
        ]
    col_modelo = []
    y = dataCali['median_house_value'].values #TODO Y le quite el reshape a esto para que agarre bien el bosque (da error)
    
    for col in Columnas:
        col_modelo.append(col)
        data1 = dataCali[col_modelo]
        data1 = pd.concat([data1, encoded_df], axis=1)
        x = data1.values
        
        x_train, x_test, y_train, y_test = train_test_split(x,y, test_size=0.2)
        #print(x_train.shape)
        #print(y_train.shape)
        
        forest= RandomForestRegressor() #TODO Todo es igual excepto aqui (osea cambiar line a decisionTreeRegressor)
        forest.fit(x_train, y_train) 
        y_pred = forest.predict(x_test)
        r2 = r2_score(y_test, y_pred)
    
        print(col_modelo, r2)
#modelo_de_bosque_aleatorio_de_regresion() #! Su unico problema es que como usa mucho arboles si le ponemos muchas hojas 
#! Dile adios a tus recursos de la pc pq consume mucho PERO ES MUY PRECISO!!!!!!!!!!!!!

from ppadb.client import Client as AdbClient

# Conectamos Python con el servidor ADB que ya probaste
client = AdbClient(host="127.0.0.1", port=5037)
devices = client.devices()

if len(devices) == 0:
    print("No encontré el teléfono. Revisa el cable.")
    quit()

device = devices[0]

print(f"Conectado a: {device.serial}")

# --- ACCIONES ---

# 1. Presionar el botón de "Home" (Inicio)
print("Presionando botón Inicio...")
device.shell("input keyevent 3")

# 2. Hacer un clic en una coordenada (Cámbialas por unas de tu pantalla)
device.shell("input tap 500 1000") 

# 3. Escribir algo (asegúrate de tener un campo de texto abierto)
device.shell("input text 'Hola_Mundo'")