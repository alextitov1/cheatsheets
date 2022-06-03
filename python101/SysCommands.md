# [Subprocess](https://docs.python.org/3/library/subprocess.html)
```py
import subprocess
subprocess.run(["host", "8.8.8.8"], capture_output=True)
print(result.returncode)
print(result.stdout.decode().split())
```