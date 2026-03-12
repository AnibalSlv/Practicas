from django.http import HttpResponse

# Create your views here.
def hello(request, username):
    print(username)
    return HttpResponse("<h1>Good night %s<h1>" %username) #Agarra como
#si fuese html

def about(request):
    return HttpResponse("Texto de ejemplo: como puedes ver en el link si es /about se muestra y si es sin /about se muestra normal es como el inicio")