import pandas as pd
import matplotlib.pyplot as plt
import random #es para las ganancias ejm

df = pd.read_csv("dataset.csv", index_col='id') #Quitale el index_col="id" para ver la diferencia

#print(df.head()) #Te muestra las primerass 5 filas de la lista
#print(df.head(10)) #Te muesta las primeras 10 filas de la lista

#print(df.tail()) #Te muestra las ultimas 5 filas de la lista
#print(df.tail(10)) #Te muestra las ultimas 10 filas de la lista

#print(df.describe()) 
"""
    Caclcula:
    mean: Media
    std: Desviacion estandar
    mmin: Minimo
    25%: Percentil del 25%
    50%: Percentil del 50%
    75%: Percentil del 75%
    max: El valor maximo 
"""

#Si quieres que los datos con valores NaN no aparezcan o se cambien: (ejmplo df.head() aqui hay 2)

#df_filter= df.dropna() #Con esto borras las filas con algun dato NaN
#print(df_filter.head())

#df_filter = df.fillna("valor que cambia a los NaN") #Es lo que dice no hay mucho mas
#print(df_filter.head())

#df_filter = df.fillna({"retweets": 0, "mentions": -1}) #Asi cambias los valores de las columnas con datos NaN
#lo que esta dentro de "" son las filas y lo que esta despues de : son los valores (Es un diccionario)
#print(df_filter.head())

#print(df["full_text"]) #Asi haces que solo se muestre una columna ["Aqui va en el codigo"]
#print(df[["full_text", "favorites"]]) #asi haces para mostrasr mas de una columna (osea le pones una lista adentro de los [])

#print(df.iloc[0]) #asi filtras por filas lo que va dentro de los [] son los indices osea coo si fueran array
#print(df.iloc[0:3]) #aqui dices que quieres ver los datos en la posicion 0, 1 y 2
#print(df.iloc[[1, 2, 5]]) #asi dices que quieres ve los datos en la fila 2, 3 y 6 (recuerda que es como un array) osea
#Comineza por 0

#print(df.loc[[183721,183722]]) #si le quitas la i puedes filtrar por id
#print(df.loc[[183721,183722], ["favorites", "full_text"]]) #asi fultras por id y por columnas

#FILTRADO POR CONDICIONES

#print(df[df["favorites"] > 400]) #asi filtras por condiciones
#print(df[(df["favorites"] > 400) & (df["mentions"] > 20)]) #asi filtras por varias condiciones
"""
    Nota:
    como Pandas le vale poco la semantica de python entonces ahora son asi los operadores logicos:
    and: &
    or: |
"""
#print(df[df["full_text"].str.contains("programming")]) #asi filtras por palabra

#TRANSFORMACION DE DATOS (Creacion de columnas y operaciones)
#def calcularGanancias(retweets):
#    ganancias = retweets * random.randint(3, 5)
#    return ganancias

#df["ganancias"] = df["retweets"].apply(calcularGanancias)
#print(df.head(10))

"""
    Aqui suceden varias cosas:
    1.- en la funcion se esta haciendo (sabes lo que se esta haciendo sabes multiplicar)
    2.- luego al colocar df["ganancias"] estas colocando el nombre de la columna que quieres crear
    3.- despues del = estas diciendo que en la columna retweets .apply(funcion) se ejecute a todos los datos esa
    funcion
"""

#def popularidad(fila):
#    resultado = fila["followees"]/fila["followers"]
#    return resultado

#df["Popularidad"] = df.apply(popularidad, axis = 1)

#print(df.head())

"""
    Explicacion:
    1.- en la funcion asi accedes a las columnas del dataFrame
    2.- creamos una nueva columna llamada popularidad
    3.- le decimos a df (dataFrame) que aplique la funcion popularidad de inicio a fin
    4.- axis = 1 le especifica a  apply que la funcion debe de ser aplicada por cada fila de df
    lo de axis es debido a que estamos haciendo el apply en el dataFrame completo
"""

#AGRUPACION DE DATOS

#print(df.groupby("country").mean(numeric_only=True))

"""
    Se esta diciendo que:
    1.- en el dataFrame se van a unir todos los datos con el mismo valor en la columna country
    2.- .mean() es para calcular la media 
    3.- debido a que tambien hay textos en el df tienes que especificarle a mean que lo haga con los tipo numerico
    eso se hace con(numeric_only = True)
    Luego de hacer todo esto los datos agrupados pasaran a ser los nuevos identificadores en esa tabla
"""

#print(df.groupby("country").agg({
#    "followers": "sum",
#    "mentions": "mean",
#    "retweets": "max",
#}))

"""
    Aqui:
    1.- en vez de .mean se usa .agg (agregacion si no lo entendi mal)
    2.- esto nos permite hacer un diccionario y poder decir que hacer con cada columna que queramos
    2.1.- en followers estamos sumando todos sus valores
    2.2.- en mentions estamos sacandole la media
    2.3.- en retweets estamos sacando el valor maximo
"""

#grouped = df.groupby("country").agg({
#    "followers": "sum",
#    "mentions": "mean",
#    "retweets": "max",
#})

#print(grouped[grouped["followers"] > 5000])

"""
    Si guardamos eso en una variable luego podemos hacer operaciones de filtracion
"""

#COMO GRAFICAR LAS TABLAs

grouped = df.groupby("country").agg({
    "followers": "sum",
    "mentions": "mean",
    "retweets": "max",
})

#grouped["followers"].plot() #Asi lo puedes mostrar como un grafico de lineas
#grouped["followers"].plot(kind="bar") #Asi lo puedes mostrar como un grafico barras (hay muchos tipos)

#plt.show() #asi muestra los graficos

#df.plot(kind="scatter", x="favorites", y="retweets") #Asi podemos ver si hay relacion entre los datos es por el tipo de tabla
#que usa puntos 
#plt.show()

#COMO GUARDAR EN UN ARCHIVO CSV
grouped.to_csv("Aqui pones el nombre que quieres.csv") #Asi se guarda en un csv
grouped.to_json("Aqui pones el nombre que quieres.json") #Asi se guarda en un json
grouped.to_excel("Aqui pones el nombre que quieres.xlsx") #Asi se guarda en un xls
#y asi mismo eciste el .to_html, .to_sql, etc