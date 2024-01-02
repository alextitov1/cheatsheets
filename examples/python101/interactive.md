```py
name = imput("Please enter your name: ")
print("Hello, " name)
```

## read system variables
```py
#!/usr/bin/env python3
import os

print("HOME: " + os.environ.get("HOME", ""))
```

## get arguments
```py
#!/usr/bin/env python3
import sys

print(sys.argv)
```