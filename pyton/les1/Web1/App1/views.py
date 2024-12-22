from django.http import HttpResponse
from django.shortcuts import render
from .models import  Order
from .calc_form import calcform
from .modelfrom import addorderform
# Create your views here.

students=[{"name":"aaa","tz":123456789,"kurs":{"tora":60,"navie":60}},
{"name":"bbb","tz":123456789,"kurs": {"tora":100,"navie":100}},
{"name":"ccc","tz":123456789,"kurs": {"tora":95,"navie":95}},
{"name":"ddd","tz":123456789,"kurs": {"tora":80,"navie":80}}]

def student_by_id(request,tz):
    student={}
    for s in students:
        if s['tz']==tz:
            student=s

    student['avg']=sum(students['kurs'].values())/len(student['kurs'])
    return render(request, 'orders.html', student)



def student_list(request):
    order=[]
    if request.method =='POST':
        category=request.POST.get("category")
        filter=request.POST.get("filter")

        if category=="client":
            order=Order.objects.filter(client__person__name=filter)

        elif category=="store":
           order=Order.objects.filter(store__address=filter)

        elif category=="orderDate":
            order=Order.objects.filter(orderDate=filter)


    data={
    'orderList':order
}
    return render(request, 'orders.html',data)

def about(request):
    #return HttpResponse("<h1 style='color:red'>Welcome to my site</h1>")
    return render(request, 'aboutUs.html')

def calc(request):
    if request.method == 'POST':
        s = calcform(request.POST)
        if s.is_valid():
          num1=s.cleaned_data['num1']
          num2 = s.cleaned_data['num2']
          option = s.cleaned_data['option']

        if option=='1':
            res=num1 +num2
        elif option == '2':
            res = num1 - num2
        elif option == '3':
            res = num1 * num2
        else:
            res = num1 / num2


        return HttpResponse(f"result {res}")
    s = calcform()
    data = {
        'calc_form': s
    }
    #return HttpResponse("<h1 style='color:red'>Welcome to my site</h1>")
    return render(request, 'calculator.html',data)


def Students(request):
    if request.method == 'POST':
        p = addorderform(request.POST)
        if p.is_valid():
            p.save()
    p = addorderform()
    # s = Order.objects.all()
    #s = StudentGrade.objects.filter(grade__gt = 90).filter(course__name = 'C#')
    data = {
        'name' : p,
        # 'store':s
    }
    return render(request, 'orders.html', data)
