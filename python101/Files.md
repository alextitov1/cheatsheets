file descriptor - a token, generated by the OS, that allows programs to do more operations with the file

* [working with files](https://docs.python.org/3/library/functions.html#open)
* [os](https://docs.python.org/3/library/os.html)
* [os.path](https://docs.python.org/3/library/os.path.html)
## Reading Files
```py
file = open("spider.txt")
print(file.readline())
print(file.read())
file.close()
```

```py
with open("spider.txt") as file:
    print(file.readline())
```

## Iterating through Files
```py
with open("spider.txt") as file:
    for line in file:
        print(line.strip().upper())
```

```py
file = open("spider.txt)
lines = file.readline()
file.close()
lines.sort()
```

## Writing Files
```py
with open("novel.txt", "w") as file:
    file.write("It was a dark and stormy night")
```
* "r" - read only
* "w" - write only (overwrite the file)
* "a" - append
* "r+" - read-write

## Working with Files
```py
import os
os.remove("novel.txt")
os.rename("first_draft.txt, "final.txt")
os.path.exists("final.txt")
os.path.getsize("spider.txt")
os.path.getmtime("spider.txt")
os.path.abspath("spider.txt")
```

```py
import datetime
timestamp = os.path.getmtime("spider.txt")
datetime.datetime.fromtimestamp(timestamp)
```

## Directories
```py
import os
print(os.getcwd())
os.mkdir("new_dir")
os.chdir("new_dir")
os.rmdir("newer_dir")
os.listdir("dir")

fullname = os.path.join(dir,name)
os.path.isdir(fullname)
```
## csv files
[doc1](https://docs.python.org/3/library/csv.html)
[doc2](https://realpython.com/python-csv/)

### read a csv file
```py
import csv

f = open("csv_file.txt")
csv_f = csv.reader(f)
for row in csv_f:
    name, phone, role = row #unpacking
    print("Name: {}, Phone: {}, Role: {}".format(name, phone, role))
f.close()
```
### write a csv file

```py
import csv

host = [["workstation.local", "192.168.25.46"], ["webserver.cloud", "10.2.5.6"]]

with open('hosts.csv', 'w') as hosts_csv:
    writer = csv.writer(hosts_csv)
    writer.writerows(hosts)
```
### DictReader
```py
with open('software.csv') as software:
    reader = csv.DictReader(software)
    for row in reader:
        print(("{} has {} users").format(row["name"], row["users"]))
```
### DictWrite
```py
users = [{"name": "Sol Mansi", "username": "solm", "department": "IT infr"}]

keys = ["name", "username", "department"]
with open ('by_department.csv', 'w') as by_department:
    write = csv.DictWriter(by_deparment, fieldnames=keys)
    write.writeheader()
    write.writerows(users)
```


# Examples

```py
guests = open("guests.txt", "w")
initial_guests = ["Bob", "Andrea", "Manuel", "Polly", "Khalid"]

for i in initial_guests:
    guests.write(i + "\n")
    
guests.close()

new_guests = ["Sam", "Danielle", "Jacob"]

with open("guests.txt", "a") as guests:
    for i in new_guests:
        guests.write(i + "\n")

guests.close()

with open("guests.txt") as guests:
    for line in guests:
        print(line)

checked_out=["Andrea", "Manuel", "Khalid"]
temp_list=[]

with open("guests.txt", "r") as guests:
    for g in guests:
        temp_list.append(g.strip())

with open("guests.txt", "w") as guests:
    for name in temp_list:
        if name not in checked_out:
            guests.write(name + "\n")

guests_to_check = ['Bob', 'Andrea']
checked_in = []

with open("guests.txt","r") as guests:
    for g in guests:
        checked_in.append(g.strip())
    for check in guests_to_check:
        if check in checked_in:
            print("{} is checked in".format(check))
        else:
            print("{} is not checked in".format(check))
```

```py
#!/usr/bin/env python3
import csv

def read_employees(csv_file_location):
    csv.register_dialect('empDialect', skipinitialspace=True, strict=True)
    csv_f = csv.DictReader(open(csv_file_location), dialect = 'empDialect')
    employee_list = []
    for data in csv_f:
        employee_list.append(data)
    return employee_list

def process_data(employee_list):
    department_list = []
    for employee_data in employee_list:
        department_list.append(employee_data['Department'])
    department_data = {}
    for department_name in set(department_list):
        department_data[department_name] = department_list.count(department_name)
    return department_data

def write_report(dictionary, report_file):
    with open(report_file, "w+") as f:
        for k in sorted(dictionary):
            f.write(str(k)+':'+str(dictionary[k])+'\n')

employee_list = read_employees('/home/student-00-92334523e7d7/data/employees.csv')
dictionary = process_data(employee_list)
write_report(dictionary, '/home/student-00-92334523e7d7/test_report.txt')
```