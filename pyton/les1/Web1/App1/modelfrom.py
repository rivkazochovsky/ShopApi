from django import forms
from .models import Order

class addorderform(forms.ModelForm):
    class Meta:
        model = Order
        fields =['client', 'store','orderDate']