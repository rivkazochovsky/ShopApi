from django.contrib import admin
from . import models
# Register your models here.
admin.site.register(models.Person)
admin.site.register(models.Client)
admin.site.register(models.Mocher)
admin.site.register(models.Store)
admin.site.register(models.Order)
