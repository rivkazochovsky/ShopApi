from django import forms


class calcform(forms.Form):
    num1 = forms.IntegerField( label="num1:")
    num2 = forms.IntegerField( label="num2:")
    #is_urgent = forms.BooleanField(label="Urgent Mail", required=False)
    option = forms.ChoiceField(choices={'1':'+', '2':'-', '3':'*', '4':'/'}, required=True, initial=1 )