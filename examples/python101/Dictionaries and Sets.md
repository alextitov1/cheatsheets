declare a dictionary

dict = {}

animals = { "bears":10, "lions":1, "tigers":2 }

>animals["bears"] #You can access the values by referencing the key


## Operations
* len(dictionary) - Returns the number of items in the dictionary
* for key in dictionary - Iterates over each key in the dictionary
* for key, value in dictionary.items() - Iterates over each key,value pair in the dictionary
* if key in dictionary - Checks whether the key is in the dictionary
* dictionary[key] - Accesses the item with key key of the dictionary
* dictionary[key] = value - Sets the value associated with key

* del dictionary[key] - Removes the item with key key from the dictionary

## Methods
* dict.get(key, default) - Returns the element corresponding to key, or default if it's not present
* dict.items()
* dict.keys() - Returns a sequence containing the keys in the dictionary
* dict.values() - Returns a sequence containing the values in the dictionary
* dict.update(other_dictionary) - Updates the dictionary with the items coming from the other dictionary. Existing entries will be replaced; new entries will be added.
* dict.clear() - Removes all the items of the dictionary

[more](https://docs.python.org/3/library/stdtypes.html#mapping-types-dict)

# Set
```
a = set('hello world')
{'o', 'h', ' ', 'w', 'd', 'r', 'l', 'e'}
```

# examples
```py
def groups_per_user(group_dictionary):
	user_groups = {}
	# Go through group_dictionary
	for group, users in group_dictionary.items():
		# Now go through the users in the group
		for user in users:
			# Now add the group to the the list of
			# groups for this user, creating the entry
			# in the dictionary if necessary
			if user not in user_groups:
				user_groups[user] = [group]
			else:
				user_groups[user].append(group)	
	return(user_groups)

print(groups_per_user({"local": ["admin", "userA"],
		"public":  ["admin", "userB"],
		"administrator": ["admin"] }))
```