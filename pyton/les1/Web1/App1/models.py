from django.db import models

    # Create your models here.

class Person(models.Model):
    tz = models.CharField(max_length=10, primary_key=True)
    name = models.CharField(max_length=50)
    age=models.IntegerField(max_length=120)

    def __str__(self):
        return f"{self.tz}: {self.name}"

class Mocher(models.Model):
    person = models.OneToOneField(Person, on_delete=models.CASCADE, primary_key=True)
    salary = models.IntegerField()

    def __str__(self):
        return f"{self.person.name}"

class Store(models.Model):
    id = models.AutoField(primary_key=True)
    mocher = models.ForeignKey(Mocher, on_delete=models.DO_NOTHING)
    address=models.CharField(max_length=50)

    def __str__(self):
        return f"{self.address} by {self.mocher.person.name}"
class Client(models.Model):
    person = models.OneToOneField(Person, on_delete=models.CASCADE, primary_key=True)
    stores = models.ManyToManyField(Store, through="Order")

    def __str__(self):
        return f"{self.person.name}"


class Order(models.Model):
    client = models.ForeignKey(Client, on_delete=models.DO_NOTHING)
    store = models.ForeignKey(Store, on_delete=models.DO_NOTHING)
    orderDate = models.DateField()

    def __str__(self):
        return f"{self.store.address} by {self.client.person.name} on {self.orderDate}"