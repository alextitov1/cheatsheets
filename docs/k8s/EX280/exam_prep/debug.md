```sh
oc debug --to-namespace="default" \
  -- curl -sS --connect-timeout 5 http://10.8.0.138:8080
```

```sh
oc exec \
  deploy/long-load -- curl -s localhost:3000/hiccup?time=5
```