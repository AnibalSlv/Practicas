from django.urls import path
from myapp import views

urlpatterns = [
    path('', views.hello),
    path('about/', views.about),
    path('hello/<str:username>', views.hello),
]