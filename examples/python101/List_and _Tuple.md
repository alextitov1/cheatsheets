# Lists
declare a list
list = []
```
list = ["This", "is", "a", "list"]
```
something **in** the list
list[0]

### list.append("New data") 
### list.insert(0, "New data")
### list.remove("element")
### list.pop("index")
### list.sort()
### list.reverse()
### list.clear()
### list.copy() - creates a copy of the list
### list.extend(other_list) - append


<br>

# Tuples
declare a tuple
tuple = () #parentheses

var1, var2, var3 = tuple # this unpack the tuple


>`enumerate()` function takes a list as a parameter and returns a tuple for each element in the list
```py
index, element in enumerate(elements)
```

### List Comprehensions
```
>>> list = [x*7 for x in range(1,11)]
>>> print(list)
[7, 14, 21, 28, 35, 42, 49, 56, 63, 70]
```
```py
def odd_numbers(n):
	return [x for x in range(1,n+1) if x % 2 != 0]
```
# Examples

```py
filenames = ["program.c", "stdio.hpp", "sample.hpp", "a.out", "math.hpp", "hpp.out"]
# Generate newfilenames as a list containing the new filenames
# using as many lines of code as your chosen method requires.
newfilenames = [x.replace("hpp","h") if x.endswith("hpp") else x for x in filenames]

print(newfilenames) 
```

```py
def highlight_word(sentence, word):
	return( " ".join([x.upper() if x == word else x for x in sentence.split()]))

print(highlight_word("Have a nice day", "nice"))
print(highlight_word("Shhh, don't be so loud!", "loud"))
print(highlight_word("Automating with Python is fun", "fun"))
```

# final lab

```py
#Begin Portion 1#
import random

class Server:
    def __init__(self):
        """Creates a new server instance, with no active connections."""
        self.connections = {}

    def add_connection(self, connection_id):
        """Adds a new connection to this server."""
        connection_load = random.random()*10+1
        # Add the connection to the dictionary with the calculated load
        self.connections[connection_id] = connection_load

    def close_connection(self, connection_id):
        """Closes a connection on this server."""
        # Remove the connection from the dictionary
        del self.connections[connection_id]

    def load(self):
        """Calculates the current load for all connections."""
        total = 0
        # Add up the load for each of the connections
        total = sum(self.connections.values())
        return total

    def __str__(self):
        """Returns a string with the current load of the server"""
        return "{:.2f}%".format(self.load())
    
#End Portion 1#
#Begin Portion 2#
class LoadBalancing:
    def __init__(self):
        """Initialize the load balancing system with one server"""
        self.connections = {}
        self.servers = [Server()]

    def add_connection(self, connection_id):
        """Randomly selects a server and adds a connection to it."""
        server = random.choice(self.servers)
        # Add the connection to the dictionary with the selected server
        self.connections[connection_id] = server
        # Add the connection to the server
        server.add_connection(connection_id)
        self.ensure_availability()
        pass

    def close_connection(self, connection_id):
        """Closes the connection on the the server corresponding to connection_id."""
        # Find out the right server
        server = self.connections[connection_id]
        # Close the connection on the server
        server.close_connection(connection_id)
        # Remove the connection from the load balancer
        del self.connections[connection_id]

    def avg_load(self):
        """Calculates the average load of all servers"""
        # Sum the load of each server and divide by the amount of servers
        sum1 = 0
        for server in self.servers:
            sum1 += sum(server.connections.values())
        return sum1 / len(self.servers)

    def ensure_availability(self):
        """If the average load is higher than 50, spin up a new server"""
        if self.avg_load() > 50:
            self.servers.append(Server())
        pass

    def __str__(self):
        """Returns a string with the load for each server."""
        loads = [str(server) for server in self.servers]
        return "[{}]".format(",".join(loads))
#End Portion 2#

for connection in range(020):
    l.add_connection(connection)
print(l)

print(l.avg_load())

l = LoadBalancing()
l.add_connection("fdca:83d2::f20d")
print(l.avg_load())


```