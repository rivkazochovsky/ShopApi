from django.http import HttpResponse
from django.shortcuts import render
def home(req):
    return HttpResponse("<h2 style='color:pink'>hello user!!!</h2>")

def homePage(request):
    #return HttpResponse("<h1 style='color:red'>Welcome to my site</h1>")
    return render(request, 'home.html')

# def map(req):
#     return HttpResponse("<h1>this is israel map</h1>")