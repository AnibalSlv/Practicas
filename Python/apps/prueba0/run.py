from flask import Flask, render_template
app = Flask(__name__) #!Asi sabe donde buscar los archivos html, js, css, img, etc

#! {{ ... }} → imprime valores.
#! {% ... %} → instrucciones de control (for, if, etc.).
#! Esto es para html solo que no me deja ponerlo como comentario jaja

@app.route('/') 
def index():
    cursos = ["python","hmtl","sql","js"]
    data={
        "titulo": "index",
        "saludo": "Buenos dias mundo",
        "cursos": cursos,
        "numero_curso": len(cursos)
    }
    #?Lo que dice def index() es para que se pueda comunicar con html
    #return '<h1>Buenas noches mundo<h1>' #Puedes poner como si huera html osea <h1><h2> etc
    return render_template('index.html', data=data)

if __name__ == '__main__':
    #? Si visitas http://localhost:5000/usuario/Ana, la respuesta será "Hola, Ana!".
    #? Ojo poninedo ('/usuario/Ana') y poniendo que diga hola ana claro
    app.run(debug=True, port=5000) 
    #? El debug=True hace que se puedan ver los cambios a tiempo real
    #!RECUERDA QUITARLO CUANDO TERMINES DE HACER EL PROYECTO
    #? El port es para poner en un puerto el puerto por defecto es 5000