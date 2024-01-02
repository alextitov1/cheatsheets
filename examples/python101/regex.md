# [Regular Expressions](https://docs.python.org/3/howto/regex.html)
- what are all the four-letter words in a file?
- How many different error types are there in this error log?

## Links
[regex101](https://www.regex101.com)

[re](https://docs.python.org/3/library/re.html)

[regexcrossword](https://regexcrossword.com/)

```py
import re
re.search()
re.findall()
re.split()
re.sub()
```

## Special (meta) characters
### reserved characters
* .(dot) - any charecter `grep alex. /usr/share/dict/words`
### anchor charaters
* ^(circumflex) - begining of the line
* $ - end of the line
### literal characters
* [a]
* [1]
### wildcard characters
* [^a-zA-Z] - match characters aren't in the group
* |(pipe) - A|B, match either A or B
* *(star) - match 0 or more repetitions
### repetition qulifiers
* .* - matches all characters
* [a-z]* - matches all letters
* \+ - matches **one** or **more** occurences that comes before it
* ? - either **zero** or **one** occurrence
* [a-z]{5} - looking for letters that are repeated 5 times
* \w{5,} - range of five or more letters or numbers
### escaping characters
* \ 
* \w - matches any alphanumeric character - letters, numbers, underscores...
* \d - digits
* \s - whitespaces
* \b - word boundaries


## Capturing Groups
* () - groups
```py
result = re.search(r"^(\w*), (\w* \w\.)$", name)
print("{} {}".format(result[2], result[1]))
```
```py
re.sub(r"^([\w .-]*), ([\w .-]*)$", r"\2 \1", "Lovelace, Ada")
>>'Ada Lovelace'
```

## Examples
```py
import re
print(re.search(r"p.ng", "Pangaea", re.IGNORECASE))
```
```py
print(re.search(r"[^a-zA-Z0-9]way", "The end of the highway"))
```
```py
print(re.findall(r"cat|dog", "I like both cats and dogs"))
```
```py
print(re.search(r"o+l+", "goldfish"))
```
```py
print(re.search(r"p?each", "To each their own"))
```
```py
import re
def check_zip_code (text):
  result = re.search(r"[^^]\d{5}(-\d{4})?", text)
  return result != None

print(check_zip_code("The zip codes for New York are 10001 thru 11104.")) # True
print(check_zip_code("90210 is a TV show")) # False
print(check_zip_code("Their address is: 123 Main Street, Anytown, AZ 85258-0001.")) # True
print(check_zip_code("The Parliament of Canada is at 111 Wellington St, Ottawa, ON K1A0A9.")) # False
```
```py
import re
def check_time(text):
  pattern = "[1]?[0-9]:[0-5][0-9] ?[aA|pP][mM]"
  result = re.search(pattern, text)
  return result != None

print(check_time("12:45pm")) # True
print(check_time("9:59 AM")) # True
print(check_time("6:60am")) # False
print(check_time("five o'clock")) # False
```
```py
import re
def convert_phone_number(phone):
  result = re.sub(r"(\d{3})(-)(\d{3}-\d{4}\b)",r"(\1) \3",phone)
  return result

print(convert_phone_number("My number is 212-345-9999.")) # My number is (212) 345-9999.
print(convert_phone_number("Please call 888-555-1234")) # Please call (888) 555-1234
print(convert_phone_number("123-123-12345")) # 123-123-12345
print(convert_phone_number("Phone number of Buckingham Palace is +44 303 123 7300")) # Phone number of Buckingham Palace is +44 303 123 7300
```

