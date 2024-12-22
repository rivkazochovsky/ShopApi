from django.contrib import admin
from django.urls import path, include
from .import views


urlpatterns = [
path("orders/", views.Students),
path("<int:id>", views.student_by_id),
path("about", views.about,name='aboutUs'),
path("calc", views.calc)

    ]