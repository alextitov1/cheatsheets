```py
raise - to check for conditions that we expect to happen during normal execution
assert - verify situations that arent expected but that might cause our code to misbehave 
```
```py
def validate_user(username, mainlen):
    assert type(username) == str, "username must be a string"
    if minlen < 1:
        raise ValueError("minlen must be at least 1")
    if len(username) < minlen:
        return False
    if not username.isalnum():
        return False
    return True
```
```py
```